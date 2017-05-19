using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace Y.Utils.WindowsUtils.ProcessUtils
{
    public class NetProcessTool
    {
        #region 枚举 读取连接表选项
        enum TCP_TABLE_CLASS
        {
            TCP_TABLE_BASIC_LISTENER,
            TCP_TABLE_BASIC_CONNECTIONS,
            TCP_TABLE_BASIC_ALL,
            TCP_TABLE_OWNER_PID_LISTENER,
            TCP_TABLE_OWNER_PID_CONNECTIONS,
            TCP_TABLE_OWNER_PID_ALL,
            TCP_TABLE_OWNER_MODULE_LISTENER,
            TCP_TABLE_OWNER_MODULE_CONNECTIONS,
            TCP_TABLE_OWNER_MODULE_ALL
        }
        enum UDP_TABLE_CLASS
        {
            UDP_TABLE_BASIC,
            UDP_TABLE_OWNER_PID,
            UDP_TABLE_OWNER_MODULE
        }
        #endregion
        #region UDP 和 TCP 列表 结构
        struct UdpTable
        {
            public uint dwNumEntries;
            private UdpRow table;
        }
        struct TcpTable
        {
            public uint dwNumEntries;
            private TcpRow table;
        }
        #endregion
        #region UDP 和 TCP 行记录 结构
        public struct UdpRow
        {
            private uint localAddr;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            private byte[] localPort;

            public IPAddress LocalIP
            {
                get
                {
                    return new IPAddress((long)((ulong)this.localAddr));
                }
            }
            public ushort LocalPort
            {
                get
                {
                    return BitConverter.ToUInt16(new byte[]
                    {
                    this.localPort[1],
                    this.localPort[0]
                    }, 0);
                }
            }
            public int ProcessId { get; }
        }

        public struct TcpRow
        {
            ConnectionState state;
            private uint localAddr;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            private byte[] localPort;
            private uint remoteAddr;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            private byte[] remotePort;

            public IPAddress LocalIP
            {
                get
                {
                    return new IPAddress((long)((ulong)this.localAddr));
                }
            }
            public ushort LocalPort
            {
                get
                {
                    return BitConverter.ToUInt16(new byte[]
                    {
                    this.localPort[1],
                    this.localPort[0]
                    }, 0);
                }
            }
            public IPAddress RemoteIP
            {
                get
                {
                    return new IPAddress((long)((ulong)this.remoteAddr));
                }
            }
            public ushort RemotePort
            {
                get
                {
                    return BitConverter.ToUInt16(new byte[]
                    {
                    this.remotePort[1],
                    this.remotePort[0]
                    }, 0);
                }
            }
            public int ProcessId { get; }
        }
        #endregion

        [DllImport("iphlpapi.dll", SetLastError = true)]
        static extern uint GetExtendedTcpTable(IntPtr pTcpTable, ref int dwOutBufLen, bool sort, int ipVersion, TCP_TABLE_CLASS tblClass, uint reserved = 0u);
        [DllImport("iphlpapi.dll", SetLastError = true)]
        static extern uint GetExtendedUdpTable(IntPtr pUdpTable, ref int dwOutBufLen, bool sort, int ipVersion, UDP_TABLE_CLASS tblClass, uint reserved = 0u);

        public static TcpRow[] GetTcpConn()
        {
            TcpRow[] array = null;
            int ipVersion = 2;
            int cb = 0;
            uint extendedTcpTable = GetExtendedTcpTable(IntPtr.Zero, ref cb, true, ipVersion, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL, 0u);
            IntPtr intPtr = Marshal.AllocHGlobal(cb);
            try
            {
                extendedTcpTable = GetExtendedTcpTable(intPtr, ref cb, true, ipVersion, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL, 0u);
                bool flag = extendedTcpTable > 0u;
                if (flag) return null;

                TcpTable tcpTable = (TcpTable)Marshal.PtrToStructure(intPtr, typeof(TcpTable));
                IntPtr intPtr2 = (IntPtr)((long)intPtr + Marshal.SizeOf(tcpTable.dwNumEntries));
                array = new TcpRow[tcpTable.dwNumEntries];
                int num = 0;
                while (num < (long)((ulong)tcpTable.dwNumEntries))
                {
                    TcpRow tcpRow = (TcpRow)Marshal.PtrToStructure(intPtr2, typeof(TcpRow));
                    array[num] = tcpRow;
                    intPtr2 = (IntPtr)((long)intPtr2 + Marshal.SizeOf(tcpRow));
                    num++;
                }
            }
            catch (Exception)
            { }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }
            return array;
        }
        public static UdpRow[] GetUdpConn()
        {
            UdpRow[] array = null;
            int ipVersion = 2;
            int cb = 0;
            uint extendedUdpTable = GetExtendedUdpTable(IntPtr.Zero, ref cb, true, ipVersion, UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID, 0u);
            IntPtr intPtr = Marshal.AllocHGlobal(cb);
            try
            {
                extendedUdpTable = GetExtendedUdpTable(intPtr, ref cb, true, ipVersion, UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID, 0u);
                bool flag = extendedUdpTable > 0u;
                if (flag) return null;

                UdpTable udpTable = (UdpTable)Marshal.PtrToStructure(intPtr, typeof(UdpTable));
                IntPtr intPtr2 = (IntPtr)((long)intPtr + Marshal.SizeOf(udpTable.dwNumEntries));
                array = new UdpRow[udpTable.dwNumEntries];
                int num = 0;
                while (num < (long)((ulong)udpTable.dwNumEntries))
                {
                    UdpRow udpRow = (UdpRow)Marshal.PtrToStructure(intPtr2, typeof(UdpRow));
                    array[num] = udpRow;
                    intPtr2 = (IntPtr)((long)intPtr2 + Marshal.SizeOf(udpRow));
                    num++;
                }
            }
            catch (Exception)
            { }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }
            return array;
        }
    }
}
