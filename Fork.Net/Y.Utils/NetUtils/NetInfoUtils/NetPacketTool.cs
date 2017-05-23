using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Y.Utils.AppUtils;

namespace Y.Utils.NetUtils.NetInfoUtils
{
    /// <summary>
    /// A class that intercepts IP packets on a specific interface.
    /// </summary>
    /// <remarks>
    /// This class only works on Windows 2000 and higher.
    /// </remarks>
    public class NetPacketTool
    {
        /// <summary>
        /// Initializes a new instance of the PacketMonitor class.
        /// </summary>
        /// <param name="ip">The interface on which to listen for IP packets.</param>
        /// <exception cref="NotSupportedException">The operating system does not support intercepting packets.</exception>
        public NetPacketTool(IPAddress ip)
        {
            // make sure the user runs this program on Windows NT 5.0 or higher
            if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version.Major < 5)
                throw new NotSupportedException("This program requires Windows 2000, Windows XP or Windows .NET Server!");
            // make sure the user is an Administrator
            if (!PermissionTool.IsAdmin())
                throw new NotSupportedException("This program can only be run by administrators!");
            m_IP = ip;
            m_Buffer = new byte[65535];
        }
        /// <summary>
        /// Cleans up the unmanaged resources.
        /// </summary>
        ~NetPacketTool()
        {
            Stop();
        }
        /// <summary>
        /// Starts listening on the specified interface.
        /// </summary>
        /// <exception cref="SocketException">An error occurs when trying to intercept IP packets.</exception>
        public void Start()
        {
            if (m_Monitor == null)
            {
                try
                {
                    m_Monitor = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
                    m_Monitor.Bind(new IPEndPoint(IP, 0));
                    byte[] outValue = BitConverter.GetBytes(0);
                    byte[] inValue = BitConverter.GetBytes(1);
                    m_Monitor.IOControl(IOControlCode.ReceiveAll, inValue, outValue);
                    m_Monitor.BeginReceive(m_Buffer, 0, m_Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
                }
                catch
                {
                    m_Monitor = null;
                    throw new SocketException();
                }
            }
        }
        /// <summary>
        /// Stops listening on the specified interface.
        /// </summary>
        public void Stop()
        {
            if (m_Monitor != null)
            {
                m_Monitor.Close();
                m_Monitor = null;
            }
        }
        /// <summary>
        /// Called when the socket intercepts an IP packet.
        /// </summary>
        /// <param name="ar">The asynchronous result.</param>
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                int received = m_Monitor.EndReceive(ar);
                try
                {
                    if (m_Monitor != null)
                    {
                        byte[] packet = new byte[received];
                        Array.Copy(Buffer, 0, packet, 0, received);
                        OnNewPacket(new Packet(packet));
                    }
                }
                catch { } // invalid packet; ignore
                m_Monitor.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
            }
            catch
            {
                Stop();
            }
        }
        /// <summary>
        /// The interface used to intercept IP packets.
        /// </summary>
        /// <value>An <see cref="IPAddress"/> instance.</value>
        public IPAddress IP
        {
            get
            {
                return m_IP;
            }
        }
        /// <summary>
        /// The buffer used to store incoming IP packets.
        /// </summary>
        /// <value>An array of bytes.</value>
        protected byte[] Buffer
        {
            get
            {
                return m_Buffer;
            }
        }
        /// <summary>
        /// Raises an event that indicates a new packet has arrived.
        /// </summary>
        /// <param name="p">The arrived <see cref="Packet"/>.</param>
        protected void OnNewPacket(Packet p)
        {
            NewPacket?.Invoke(this, p);
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
    }
    /// <summary>
    /// Represents the method that will handle the NewPacket event.
    /// </summary>
    /// <param name="pm">The <see cref="PacketMonitor"/> that intercepted the <see cref="Packet"/>.</param>
    /// <param name="p">The newly arrived <see cref="Packet"/>.</param>
    public delegate void NewPacketEventHandler(NetPacketTool pm, Packet p);
    #region 相关模型
    /// <summary>
    /// The Network Control precedence designation is intended to be used within a network only. The actual use and control of that designation is up to each network. The Internetwork Control designation is intended for use by gateway control originators only. If the actual use of these precedence designations is of concern to a particular network, it is the responsibility of that network to control the access to, and use of, those precedence designations.
    /// </summary>
    public enum Precedence
    {
        Routine = 0,
        Priority = 1,
        Immediate = 2,
        Flash = 3,
        FlashOverride = 4,
        CRITICECP = 5,
        InternetworkControl = 6,
        NetworkControl = 7
    }
    /// <summary>
    /// The use of the Delay, Throughput, and Reliability indications may increase the cost (in some sense) of the service. In many networks better performance for one of these parameters is coupled with worse performance on another.
    /// </summary>
    public enum Delay
    {
        NormalDelay = 0,
        LowDelay = 1
    }
    /// <summary>
    /// The use of the Delay, Throughput, and Reliability indications may increase the cost (in some sense) of the service. In many networks better performance for one of these parameters is coupled with worse performance on another.
    /// </summary>
    public enum Throughput
    {
        NormalThroughput = 0,
        HighThroughput = 1
    }
    /// <summary>
    /// The use of the Delay, Throughput, and Reliability indications may increase the cost (in some sense) of the service. In many networks better performance for one of these parameters is coupled with worse performance on another.
    /// </summary>
    public enum Reliability
    {
        NormalReliability = 0,
        HighReliability = 1
    }
    /// <summary>
    /// This field indicates the next level protocol used in the data portion of the internet datagram.
    /// </summary>
    public enum Protocol
    {
        Ggp = 3,
        Icmp = 1,
        Idp = 22,
        Igmp = 2,
        IP = 4,
        ND = 77,
        Pup = 12,
        Tcp = 6,
        Udp = 17,
        Other = -1
    }
    /// <summary>
    /// Represents an IP packet.
    /// </summary>
    public class Packet
    {
        /// <summary>
        /// Initializes a new version of the Packet class.
        /// </summary>
        /// <param name="raw">The raw bytes of the IP packet.</param>
        /// <exception cref="ArgumentNullException"><paramref name="raw"/> is a null reference (<b>Nothing</b> in Visual Basic).</exception>
        /// <exception cref="ArgumentException"><paramref name="raw"/> represents an invalid IP packet.</exception>
        /// <remarks>The intercept time will be set to DateTime.Now.</remarks>
        public Packet(byte[] raw) : this(raw, DateTime.Now) { }
        /// <summary>
        /// Initializes a new version of the Packet class.
        /// </summary>
        /// <param name="raw">The raw bytes of the IP packet.</param>
        /// <param name="time">The time when the IP packet was intercepted.</param>
        /// <exception cref="ArgumentNullException"><paramref name="raw"/> is a null reference (<b>Nothing</b> in Visual Basic).</exception>
        /// <exception cref="ArgumentException"><paramref name="raw"/> represents an invalid IP packet.</exception>
        public Packet(byte[] raw, DateTime time)
        {
            if (raw == null)
                throw new ArgumentNullException();
            if (raw.Length < 20)
                throw new ArgumentException(); // invalid IP packet
            m_Raw = raw;
            m_Time = time;
            m_Version = (raw[0] & 0xF0) >> 4;
            m_HeaderLength = (raw[0] & 0x0F) * 4 /* sizeof(int) */;
            if ((raw[0] & 0x0F) < 5)
                throw new ArgumentException(); // invalid header of packet
            m_Precedence = (Precedence)((raw[1] & 0xE0) >> 5);
            m_Delay = (Delay)((raw[1] & 0x10) >> 4);
            m_Throughput = (Throughput)((raw[1] & 0x8) >> 3);
            m_Reliability = (Reliability)((raw[1] & 0x4) >> 2);
            m_TotalLength = raw[2] * 256 + raw[3];
            if (m_TotalLength != raw.Length)
                throw new ArgumentException(); // invalid size of packet
            m_Identification = raw[4] * 256 + raw[5];
            m_TimeToLive = raw[8];
            if (Enum.IsDefined(typeof(Protocol), (int)raw[9]))
                m_Protocol = (Protocol)raw[9];
            else
                m_Protocol = Protocol.Other;
            m_Checksum = new byte[2];
            m_Checksum[0] = raw[11];
            m_Checksum[1] = raw[10];
            m_SourceAddress = new IPAddress(BitConverter.ToUInt32(raw, 12));
            m_DestinationAddress = new IPAddress(BitConverter.ToUInt32(raw, 16));
            if (m_Protocol == Protocol.Tcp || m_Protocol == Protocol.Udp)
            {
                m_SourcePort = raw[m_HeaderLength] * 256 + raw[m_HeaderLength + 1];
                m_DestinationPort = raw[m_HeaderLength + 2] * 256 + raw[m_HeaderLength + 3];
            }
            else
            {
                m_SourcePort = -1;
                m_DestinationPort = -1;
            }
        }
        /// <summary>
        /// Gets the raw bytes of the IP packet.
        /// </summary>
        /// <value>An array of bytes.</value>
        protected byte[] Raw
        {
            get
            {
                return m_Raw;
            }
        }
        /// <summary>
        /// Gets the time when the IP packet was intercepted.
        /// </summary>
        /// <value>A <see cref="DateTime"/> value.</value>
        public DateTime Time
        {
            get
            {
                return m_Time;
            }
        }
        /// <summary>
        /// Gets the version of the IP protocol used.
        /// </summary>
        /// <value>A 32-bits signed integer.</value>
        public int Version
        {
            get
            {
                return m_Version;
            }
        }
        /// <summary>
        /// Gets the length of the IP header [in bytes].
        /// </summary>
        /// <value>A 32-bits signed integer.</value>
        public int HeaderLength
        {
            get
            {
                return m_HeaderLength;
            }
        }
        /// <summary>
        /// Gets the precedence parameter.
        /// </summary>
        /// <value>A <see cref="Precedence"/> instance.</value>
        public Precedence Precedence
        {
            get
            {
                return m_Precedence;
            }
        }
        /// <summary>
        /// Gets the delay parameter.
        /// </summary>
        /// <value>A <see cref="Delay"/> instance.</value>
        public Delay Delay
        {
            get
            {
                return m_Delay;
            }
        }
        /// <summary>
        /// Gets the throughput parameter.
        /// </summary>
        /// <value>A <see cref="Throughput"/> instance.</value>
        public Throughput Throughput
        {
            get
            {
                return m_Throughput;
            }
        }
        /// <summary>
        /// Gets the reliability parameter.
        /// </summary>
        /// <value>A <see cref="Reliability"/> instance.</value>
        public Reliability Reliability
        {
            get
            {
                return m_Reliability;
            }
        }
        /// <summary>
        /// Gets the total length of the IP packet.
        /// </summary>
        /// <value>A 32-bits signed integer.</value>
        public int TotalLength
        {
            get
            {
                return m_TotalLength;
            }
        }
        /// <summary>
        /// Gets the identification number of the IP packet.
        /// </summary>
        /// <value>A 32-bits signed integer.</value>
        public int Identification
        {
            get
            {
                return m_Identification;
            }
        }
        /// <summary>
        /// Gets the time-to-live [hop count] of the IP packet.
        /// </summary>
        /// <value>A 32-bits signed integer.</value>
        public int TimeToLive
        {
            get
            {
                return m_TimeToLive;
            }
        }
        /// <summary>
        /// Gets the protocol of the IP packet.
        /// </summary>
        /// <value>A <see cref="Protocol"/> instance.</value>
        public Protocol Protocol
        {
            get
            {
                return m_Protocol;
            }
        }
        /// <summary>
        /// Gets the checksum of the IP packet.
        /// </summary>
        /// <value>An array of two bytes.</value>
        public byte[] Checksum
        {
            get
            {
                return m_Checksum;
            }
        }
        /// <summary>
        /// Gets the source address of the IP packet.
        /// </summary>
        /// <value>An <see cref="IPAddress"/> instance.</value>
        public IPAddress SourceAddress
        {
            get
            {
                return m_SourceAddress;
            }
        }
        /// <summary>
        /// Gets the destination address of the IP packet.
        /// </summary>
        /// <value>An <see cref="IPAddress"/> instance.</value>
        public IPAddress DestinationAddress
        {
            get
            {
                return m_DestinationAddress;
            }
        }
        /// <summary>
        /// Gets the source port of the packet.
        /// </summary>
        /// <value>A 32-bits signed integer.</value>
        /// <remarks>
        /// This property will only return meaningful data if the IP packet encapsulates either a TCP or a UDP packet.
        /// If the IP address encapsulates a packet of another protocol, the returned source port will be set to minus one.
        /// </remarks>
        public int SourcePort
        {
            get
            {
                return m_SourcePort;
            }
        }
        /// <summary>
        /// Gets the destination port of the packet.
        /// </summary>
        /// <value>A 32-bits signed integer.</value>
        /// <remarks>
        /// This property will only return meaningful data if the IP packet encapsulates either a TCP or a UDP packet.
        /// If the IP address encapsulates a packet of another protocol, the returned destination port will be set to minus one.
        /// </remarks>
        public int DestinationPort
        {
            get
            {
                return m_DestinationPort;
            }
        }
        /// <summary>
        /// Gets a string representation of the source.
        /// </summary>
        /// <value>An <see cref="String"/> instance.</value>
        /// <remarks>
        /// If the encapsulated packet is a TCP or UDP packet, the returned string will consist of the IP address and the port number.
        /// If the IP packet does not encapsulate a TCP or UDP packet, the returned string will consist of the IP address.
        /// </remarks>
        public string Source
        {
            get
            {
                if (m_SourcePort != -1)
                    return SourceAddress.ToString() + ":" + m_SourcePort.ToString();
                else
                    return SourceAddress.ToString();
            }
        }
        /// <summary>
        /// Gets a string representation of the destination.
        /// </summary>
        /// <value>An <see cref="String"/> instance.</value>
        /// <remarks>
        /// If the encapsulated packet is a TCP or UDP packet, the returned string will consist of the IP address and the port number.
        /// If the IP packet does not encapsulate a TCP or UDP packet, the returned string will consist of the IP address.
        /// </remarks>
        public string Destination
        {
            get
            {
                if (m_DestinationPort != -1)
                    return DestinationAddress.ToString() + ":" + m_DestinationPort.ToString();
                else
                    return DestinationAddress.ToString();
            }
        }
        /// <summary>
        /// Returns a string representation of the Packet 
        /// </summary>
        /// <returns>An instance of the <see cref="String"/> class.</returns>
        public override string ToString()
        {
            return this.ToString(false);
        }
        /// <summary>
        /// Returns a string representation of the Packet 
        /// </summary>
        /// <param name="raw"><b>true</b> if the returned string should ony contain the raw bytes, <b>false</b> if the returned string should also contain a hexadecimal representation.</param>
        /// <returns>An instance of the <see cref="String"/> class.</returns>
        public string ToString(bool raw)
        {
            StringBuilder sb = new StringBuilder(Raw.Length);
            if (raw)
            {
                for (int i = 0; i < Raw.Length; i++)
                {
                    if (Raw[i] > 31)
                        sb.Append((char)Raw[i]);
                    else
                        sb.Append(".");
                }
            }
            else
            {
                string rawString = this.ToString(true);
                for (int i = 0; i < Raw.Length; i += 16)
                {
                    for (int j = i; j < Raw.Length && j < i + 16; j++)
                    {
                        sb.Append(Raw[j].ToString("X2") + " ");
                    }
                    if (rawString.Length < i + 16)
                    {
                        sb.Append(' ', ((16 - (rawString.Length % 16)) % 16) * 3);
                        sb.Append(" " + rawString.Substring(i) + "\r\n");
                    }
                    else
                    {
                        sb.Append(" " + rawString.Substring(i, 16) + "\r\n");
                    }
                }
            }
            return sb.ToString();
        }
        // private variables
        private byte[] m_Raw;
        private DateTime m_Time;
        private int m_Version;
        private int m_HeaderLength;
        private Precedence m_Precedence;
        private Delay m_Delay;
        private Throughput m_Throughput;
        private Reliability m_Reliability;
        private int m_TotalLength;
        private int m_Identification;
        private int m_TimeToLive;
        private Protocol m_Protocol;
        private byte[] m_Checksum;
        private IPAddress m_SourceAddress;
        private IPAddress m_DestinationAddress;
        private int m_SourcePort;
        private int m_DestinationPort;
    }
    #endregion
}