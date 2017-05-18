/*
 *   Mentalis.org Packet Monitor
 * 
 *     Copyright ?2003, The KPD-Team
 *     All rights reserved.
 *     http://www.mentalis.org/
 *
 *   Redistribution and use in source and binary forms, with or without
 *   modification, are permitted provided that the following conditions
 *   are met:
 *
 *     - Redistributions of source code must retain the above copyright
 *        notice, this list of conditions and the following disclaimer. 
 *
 *     - Neither the name of the KPD-Team, nor the names of its contributors
 *        may be used to endorse or promote products derived from this
 *        software without specific prior written permission. 
 *
 *   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 *   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 *   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
 *   FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL
 *   THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 *   INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 *   (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 *   SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 *   HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 *   STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 *   ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
 *   OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Org.Mentalis.Network.PacketMonitor {
	/// <summary>
	/// A class that intercepts IP packets on a specific interface.
	/// </summary>
	/// <remarks>
	/// This class only works on Windows 2000 and higher.
	/// </remarks>
	public class PacketMonitor {
		/// <summary>
		/// Initializes a new instance of the PacketMonitor class.
		/// </summary>
		/// <param name="ip">The interface on which to listen for IP packets.</param>
		/// <exception cref="NotSupportedException">The operating system does not support intercepting packets.</exception>
		public PacketMonitor(IPAddress ip) {
			// make sure the user runs this program on Windows NT 5.0 or higher
			if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version.Major < 5)
				throw new NotSupportedException("This program requires Windows 2000, Windows XP or Windows .NET Server!");
			// make sure the user is an Administrator
			if (!IsUserAnAdmin())
				throw new NotSupportedException("This program can only be run by administrators!");
			m_IP = ip;
			m_Buffer = new byte[65535];
		}
		/// <summary>
		/// Cleans up the unmanaged resources.
		/// </summary>
		~PacketMonitor() {
			Stop();
		}
		/// <summary>
		/// Starts listening on the specified interface.
		/// </summary>
		/// <exception cref="SocketException">An error occurs when trying to intercept IP packets.</exception>
		public void Start() {
			if (m_Monitor == null) {
				try {
					m_Monitor = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
					m_Monitor.Bind(new IPEndPoint(IP, 0));
                    byte[] outValue = BitConverter.GetBytes(0);
                    byte[] inValue = BitConverter.GetBytes(1);
                    m_Monitor.IOControl(IOControlCode.ReceiveAll, inValue, outValue);
                    m_Monitor.BeginReceive(m_Buffer, 0, m_Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
				} catch {
					m_Monitor = null;
					throw new SocketException();
				}
			}
		}
		/// <summary>
		/// Stops listening on the specified interface.
		/// </summary>
		public void Stop() {
			if (m_Monitor != null) {
				m_Monitor.Close();
				m_Monitor = null;
			}
		}
		/// <summary>
		/// Called when the socket intercepts an IP packet.
		/// </summary>
		/// <param name="ar">The asynchronous result.</param>
		private void OnReceive(IAsyncResult ar) {
			try {
				int received = m_Monitor.EndReceive(ar);
				try {
					if (m_Monitor != null) {
						byte[] packet = new byte[received];
						Array.Copy(Buffer, 0, packet, 0, received);
						OnNewPacket(new Packet(packet));
					}
				} catch {} // invalid packet; ignore
				m_Monitor.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
			} catch {
				Stop();
			}
		}
		/// <summary>
		/// The interface used to intercept IP packets.
		/// </summary>
		/// <value>An <see cref="IPAddress"/> instance.</value>
		public IPAddress IP {
			get {
				return m_IP;
			}
		}
		/// <summary>
		/// The buffer used to store incoming IP packets.
		/// </summary>
		/// <value>An array of bytes.</value>
		protected byte[] Buffer {
			get {
				return m_Buffer;
			}
		}
		/// <summary>
		/// Raises an event that indicates a new packet has arrived.
		/// </summary>
		/// <param name="p">The arrived <see cref="Packet"/>.</param>
		protected void OnNewPacket(Packet p) {
			if (NewPacket != null)
				NewPacket(this, p);
		}
		/// <summary>
		/// Holds all the listeners for the NewPacket event.
		/// </summary>
		public event NewPacketEventHandler NewPacket;
		// private variables
		private Socket m_Monitor;
		private IPAddress m_IP;
		private byte[] m_Buffer;
		private const int IOC_VENDOR = 0x18000000;
		private const int IOC_IN = -2147483648; //0x80000000; /* copy in parameters */
		private const int SIO_RCVALL = IOC_IN | IOC_VENDOR | 1;
		private const int SECURITY_BUILTIN_DOMAIN_RID = 0x20;
		private const int DOMAIN_ALIAS_RID_ADMINS = 0x220;
		/// <summary>
		/// Tests whether the current user is a member of the Administrator's group.
		/// </summary>
		/// <returns>Returns <b>true</b> if the user is a member of the Administrator's group, <b>false</b> if not.</returns>
		private bool IsUserAnAdmin() { 
			byte[] NtAuthority = new byte[6];
			NtAuthority[5] = 5; // SECURITY_NT_AUTHORITY
			IntPtr AdministratorsGroup;
			int ret = AllocateAndInitializeSid(NtAuthority, 2, SECURITY_BUILTIN_DOMAIN_RID, DOMAIN_ALIAS_RID_ADMINS, 0, 0, 0, 0, 0, 0, out AdministratorsGroup); 
			if (ret != 0) {
				if (CheckTokenMembership(IntPtr.Zero, AdministratorsGroup, ref ret) == 0) {
					ret = 0;
				} 
				FreeSid(AdministratorsGroup); 
			}

			return (ret != 0);
		}
		/// <summary>
		/// The AllocateAndInitializeSid function allocates and initializes a security identifier (SID) with up to eight subauthorities.
		/// </summary>
		/// <param name="pIdentifierAuthority">Pointer to a SID_IDENTIFIER_AUTHORITY structure, giving the top-level identifier authority value to set in the SID.</param>
		/// <param name="nSubAuthorityCount">Specifies the number of subauthorities to place in the SID. This parameter also identifies how many of the subauthority parameters have meaningful values. This parameter must contain a value from 1 to 8.</param>
		/// <param name="dwSubAuthority0">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority1">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority2">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority3">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority4">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority5">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority6">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority7">Subauthority value to place in the SID.</param>
		/// <param name="pSid">Pointer to a variable that receives the pointer to the allocated and initialized SID structure.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		[DllImport("advapi32.dll")]
		private extern static int AllocateAndInitializeSid(byte[] pIdentifierAuthority, byte nSubAuthorityCount, int dwSubAuthority0, int dwSubAuthority1, int dwSubAuthority2, int dwSubAuthority3, int dwSubAuthority4, int dwSubAuthority5, int dwSubAuthority6, int dwSubAuthority7, out IntPtr pSid);
		/// <summary>
		/// The CheckTokenMembership function determines whether a specified SID is enabled in an access token.
		/// </summary>
		/// <param name="TokenHandle">Handle to an access token. The handle must have TOKEN_QUERY access to the token. The token must be an impersonation token.</param>
		/// <param name="SidToCheck">Pointer to a SID structure. The CheckTokenMembership function checks for the presence of this SID in the user and group SIDs of the access token.</param>
		/// <param name="IsMember">Pointer to a variable that receives the results of the check. If the SID is present and has the SE_GROUP_ENABLED attribute, IsMember returns TRUE; otherwise, it returns FALSE.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		[DllImport("advapi32.dll")]
		private extern static int CheckTokenMembership(IntPtr TokenHandle, IntPtr SidToCheck, ref int IsMember);
		/// <summary>
		/// The FreeSid function frees a security identifier (SID) previously allocated by using the AllocateAndInitializeSid function.
		/// </summary>
		/// <param name="pSid">Pointer to the SID structure to free.</param>
		/// <returns>This function does not return a value.</returns>
		[DllImport("advapi32.dll")]
		private extern static IntPtr FreeSid(IntPtr pSid);
		// <summary>
		// Tests whether the current user is a member of the Administrator's group.
		// </summary>
		// <returns>Returns TRUE if the user is a member of the Administrator's group, FALSE if not.</returns>
		//[DllImport("shell32.dll")]
		//private extern static int IsUserAnAdmin();
	}
	/// <summary>
	/// Represents the method that will handle the NewPacket event.
	/// </summary>
	/// <param name="pm">The <see cref="PacketMonitor"/> that intercepted the <see cref="Packet"/>.</param>
	/// <param name="p">The newly arrived <see cref="Packet"/>.</param>
	public delegate void NewPacketEventHandler(PacketMonitor pm, Packet p);
}