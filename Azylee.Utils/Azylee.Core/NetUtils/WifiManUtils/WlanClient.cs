using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Threading;
using System.Text;

namespace Azylee.Core.NetUtils.WifiManUtils
{
    /// <summary>
    /// Represents a client to the Zeroconf (Native Wifi) service.
    /// </summary>
    /// <remarks>
    /// This class is the entrypoint to Native Wifi management. To manage WiFi settings, create an instance
    /// of this class.
    /// </remarks>
    public class WlanClient : IDisposable
    {
        /// <summary>
        /// Represents a Wifi network interface.
        /// </summary>
        public class WlanInterface
        {
            private readonly WlanClient client;
            private Wlan.WlanInterfaceInfo info;

            #region Events
            /// <summary>
            /// Represents a method that will handle <see cref="WlanNotification"/> events.
            /// </summary>
            /// <param name="notifyData">The notification data.</param>
            public delegate void WlanNotificationEventHandler(Wlan.WlanNotificationData notifyData);

            /// <summary>
            /// Represents a method that will handle <see cref="WlanConnectionNotification"/> events.
            /// </summary>
            /// <param name="notifyData">The notification data.</param>
            /// <param name="connNotifyData">The notification data.</param>
            public delegate void WlanConnectionNotificationEventHandler(Wlan.WlanNotificationData notifyData, Wlan.WlanConnectionNotificationData connNotifyData);

            /// <summary>
            /// Represents a method that will handle <see cref="WlanReasonNotification"/> events.
            /// </summary>
            /// <param name="notifyData">The notification data.</param>
            /// <param name="reasonCode">The reason code.</param>
            public delegate void WlanReasonNotificationEventHandler(Wlan.WlanNotificationData notifyData, Wlan.WlanReasonCode reasonCode);

            /// <summary>
            /// Occurs when an event of any kind occurs on a WLAN interface.
            /// </summary>
            public event WlanNotificationEventHandler WlanNotification;

            /// <summary>
            /// Occurs when a WLAN interface changes connection state.
            /// </summary>
            public event WlanConnectionNotificationEventHandler WlanConnectionNotification;

            /// <summary>
            /// Occurs when a WLAN operation fails due to some reason.
            /// </summary>
            public event WlanReasonNotificationEventHandler WlanReasonNotification;

            #endregion

            #region Event queue
            private bool queueEvents;
            private readonly AutoResetEvent eventQueueFilled = new AutoResetEvent(false);
            private readonly Queue<object> eventQueue = new Queue<object>();

            private struct WlanConnectionNotificationEventData
            {
                public Wlan.WlanNotificationData notifyData;
                public Wlan.WlanConnectionNotificationData connNotifyData;
            }
            private struct WlanReasonNotificationData
            {
                public Wlan.WlanNotificationData notifyData;
                public Wlan.WlanReasonCode reasonCode;
            }
            #endregion

            internal WlanInterface(WlanClient client, Wlan.WlanInterfaceInfo info)
            {
                this.client = client;
                this.info = info;
            }

            /// <summary>
            /// Sets a parameter of the interface whose data type is <see cref="int"/>.
            /// </summary>
            /// <param name="opCode">The opcode of the parameter.</param>
            /// <param name="value">The value to set.</param>
            private void SetInterfaceInt(Wlan.WlanIntfOpcode opCode, int value)
            {
                IntPtr valuePtr = Marshal.AllocHGlobal(sizeof(int));
                Marshal.WriteInt32(valuePtr, value);
                try
                {
                    Wlan.ThrowIfError(
                        Wlan.WlanSetInterface(client.clientHandle, info.interfaceGuid, opCode, sizeof(int), valuePtr, IntPtr.Zero));
                }
                finally
                {
                    Marshal.FreeHGlobal(valuePtr);
                }
            }

            /// <summary>
            /// Gets a parameter of the interface whose data type is <see cref="int"/>.
            /// </summary>
            /// <param name="opCode">The opcode of the parameter.</param>
            /// <returns>The integer value.</returns>
            private int GetInterfaceInt(Wlan.WlanIntfOpcode opCode)
            {
                IntPtr valuePtr;
                int valueSize;
                Wlan.WlanOpcodeValueType opcodeValueType;
                Wlan.ThrowIfError(
                    Wlan.WlanQueryInterface(client.clientHandle, info.interfaceGuid, opCode, IntPtr.Zero, out valueSize, out valuePtr, out opcodeValueType));
                try
                {
                    return Marshal.ReadInt32(valuePtr);
                }
                finally
                {
                    Wlan.WlanFreeMemory(valuePtr);
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="WlanInterface"/> is automatically configured.
            /// </summary>
            /// <value><c>true</c> if "autoconf" is enabled; otherwise, <c>false</c>.</value>
            public bool Autoconf
            {
                get
                {
                    return GetInterfaceInt(Wlan.WlanIntfOpcode.AutoconfEnabled) != 0;
                }
                set
                {
                    SetInterfaceInt(Wlan.WlanIntfOpcode.AutoconfEnabled, value ? 1 : 0);
                }
            }

            /// <summary>
            /// Gets or sets the BSS type for the indicated interface.
            /// </summary>
            /// <value>The type of the BSS.</value>
            public Wlan.Dot11BssType BssType
            {
                get
                {
                    return (Wlan.Dot11BssType)GetInterfaceInt(Wlan.WlanIntfOpcode.BssType);
                }
                set
                {
                    SetInterfaceInt(Wlan.WlanIntfOpcode.BssType, (int)value);
                }
            }

            /// <summary>
            /// Gets the state of the interface.
            /// </summary>
            /// <value>The state of the interface.</value>
            public Wlan.WlanInterfaceState InterfaceState
            {
                get
                {
                    return (Wlan.WlanInterfaceState)GetInterfaceInt(Wlan.WlanIntfOpcode.InterfaceState);
                }
            }

            /// <summary>
            /// Gets the channel.
            /// </summary>
            /// <value>The channel.</value>
            /// <remarks>Not supported on Windows XP SP2.</remarks>
            public int Channel
            {
                get
                {
                    return GetInterfaceInt(Wlan.WlanIntfOpcode.ChannelNumber);
                }
            }

            /// <summary>
            /// Gets the RSSI.
            /// </summary>
            /// <value>The RSSI.</value>
            /// <remarks>Not supported on Windows XP SP2.</remarks>
            public int RSSI
            {
                get
                {
                    return GetInterfaceInt(Wlan.WlanIntfOpcode.RSSI);
                }
            }

            /// <summary>
            /// Gets the radio state.
            /// </summary>
            /// <value>The radio state.</value>
            /// <remarks>Not supported on Windows XP.</remarks>
            public Wlan.WlanRadioState RadioState
            {
                get
                {
                    int valueSize;
                    IntPtr valuePtr;
                    Wlan.WlanOpcodeValueType opcodeValueType;
                    Wlan.ThrowIfError(
                        Wlan.WlanQueryInterface(client.clientHandle, info.interfaceGuid, Wlan.WlanIntfOpcode.RadioState, IntPtr.Zero, out valueSize, out valuePtr, out opcodeValueType));
                    try
                    {
                        return (Wlan.WlanRadioState)Marshal.PtrToStructure(valuePtr, typeof(Wlan.WlanRadioState));
                    }
                    finally
                    {
                        Wlan.WlanFreeMemory(valuePtr);
                    }
                }
            }

            /// <summary>
            /// Gets the current operation mode.
            /// </summary>
            /// <value>The current operation mode.</value>
            /// <remarks>Not supported on Windows XP SP2.</remarks>
            public Wlan.Dot11OperationMode CurrentOperationMode
            {
                get
                {
                    return (Wlan.Dot11OperationMode)GetInterfaceInt(Wlan.WlanIntfOpcode.CurrentOperationMode);
                }
            }

            /// <summary>
            /// Gets the attributes of the current connection.
            /// </summary>
            /// <value>The current connection attributes.</value>
            /// <exception cref="Win32Exception">An exception with code 0x0000139F (The group or resource is not in the correct state to perform the requested operation.) will be thrown if the interface is not connected to a network.</exception>
            public Wlan.WlanConnectionAttributes CurrentConnection
            {
                get
                {
                    int valueSize;
                    IntPtr valuePtr;
                    Wlan.WlanOpcodeValueType opcodeValueType;
                    Wlan.ThrowIfError(
                        Wlan.WlanQueryInterface(client.clientHandle, info.interfaceGuid, Wlan.WlanIntfOpcode.CurrentConnection, IntPtr.Zero, out valueSize, out valuePtr, out opcodeValueType));
                    try
                    {
                        return (Wlan.WlanConnectionAttributes)Marshal.PtrToStructure(valuePtr, typeof(Wlan.WlanConnectionAttributes));
                    }
                    finally
                    {
                        Wlan.WlanFreeMemory(valuePtr);
                    }
                }
            }

            /// <summary>
            /// Requests a scan for available networks.
            /// </summary>
            /// <remarks>
            /// The method returns immediately. Progress is reported through the <see cref="WlanNotification"/> event.
            /// </remarks>
            public void Scan()
            {
                Wlan.ThrowIfError(
                    Wlan.WlanScan(client.clientHandle, info.interfaceGuid, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            }

            /// <summary>
            /// Converts a pointer to a available networks list (header + entries) to an array of available network entries.
            /// </summary>
            /// <param name="availNetListPtr">A pointer to an available networks list's header.</param>
            /// <returns>An array of available network entries.</returns>
            private static Wlan.WlanAvailableNetwork[] ConvertAvailableNetworkListPtr(IntPtr availNetListPtr)
            {
                Wlan.WlanAvailableNetworkListHeader availNetListHeader = (Wlan.WlanAvailableNetworkListHeader)Marshal.PtrToStructure(availNetListPtr, typeof(Wlan.WlanAvailableNetworkListHeader));
                long availNetListIt = availNetListPtr.ToInt64() + Marshal.SizeOf(typeof(Wlan.WlanAvailableNetworkListHeader));
                Wlan.WlanAvailableNetwork[] availNets = new Wlan.WlanAvailableNetwork[availNetListHeader.numberOfItems];
                for (int i = 0; i < availNetListHeader.numberOfItems; ++i)
                {
                    availNets[i] = (Wlan.WlanAvailableNetwork)Marshal.PtrToStructure(new IntPtr(availNetListIt), typeof(Wlan.WlanAvailableNetwork));
                    availNets[i].profileName = WlanTool.GetStringForSSID(availNets[i].dot11Ssid);
                    availNetListIt += Marshal.SizeOf(typeof(Wlan.WlanAvailableNetwork));
                }
                return availNets;
            }

            /// <summary>
            /// Retrieves the list of available networks.
            /// </summary>
            /// <param name="flags">Controls the type of networks returned.</param>
            /// <returns>A list of the available networks.</returns>
            public Wlan.WlanAvailableNetwork[] GetAvailableNetworkList(Wlan.WlanGetAvailableNetworkFlags flags)
            {
                IntPtr availNetListPtr;
                Wlan.ThrowIfError(
                    Wlan.WlanGetAvailableNetworkList(client.clientHandle, info.interfaceGuid, flags, IntPtr.Zero, out availNetListPtr));
                try
                {
                    return ConvertAvailableNetworkListPtr(availNetListPtr);
                }
                finally
                {
                    Wlan.WlanFreeMemory(availNetListPtr);
                }
            }

            /// <summary>
            /// Converts a pointer to a BSS list (header + entries) to an array of BSS entries.
            /// </summary>
            /// <param name="bssListPtr">A pointer to a BSS list's header.</param>
            /// <returns>An array of BSS entries.</returns>
            private static Wlan.WlanBssEntry[] ConvertBssListPtr(IntPtr bssListPtr)
            {
                Wlan.WlanBssListHeader bssListHeader = (Wlan.WlanBssListHeader)Marshal.PtrToStructure(bssListPtr, typeof(Wlan.WlanBssListHeader));
                long bssListIt = bssListPtr.ToInt64() + Marshal.SizeOf(typeof(Wlan.WlanBssListHeader));
                Wlan.WlanBssEntry[] bssEntries = new Wlan.WlanBssEntry[bssListHeader.numberOfItems];
                for (int i = 0; i < bssListHeader.numberOfItems; ++i)
                {
                    bssEntries[i] = (Wlan.WlanBssEntry)Marshal.PtrToStructure(new IntPtr(bssListIt), typeof(Wlan.WlanBssEntry));
                    bssListIt += Marshal.SizeOf(typeof(Wlan.WlanBssEntry));
                }
                return bssEntries;
            }

            /// <summary>
            /// Retrieves the basic service sets (BSS) list of all available networks.
            /// </summary>
            public Wlan.WlanBssEntry[] GetNetworkBssList()
            {
                IntPtr bssListPtr;
                Wlan.ThrowIfError(
                    Wlan.WlanGetNetworkBssList(client.clientHandle, info.interfaceGuid, IntPtr.Zero, Wlan.Dot11BssType.Any, false, IntPtr.Zero, out bssListPtr));
                try
                {
                    return ConvertBssListPtr(bssListPtr);
                }
                finally
                {
                    Wlan.WlanFreeMemory(bssListPtr);
                }
            }

            /// <summary>
            /// Retrieves the basic service sets (BSS) list of the specified network.
            /// </summary>
            /// <param name="ssid">Specifies the SSID of the network from which the BSS list is requested.</param>
            /// <param name="bssType">Indicates the BSS type of the network.</param>
            /// <param name="securityEnabled">Indicates whether security is enabled on the network.</param>
            public Wlan.WlanBssEntry[] GetNetworkBssList(Wlan.Dot11Ssid ssid, Wlan.Dot11BssType bssType, bool securityEnabled)
            {
                IntPtr ssidPtr = Marshal.AllocHGlobal(Marshal.SizeOf(ssid));
                Marshal.StructureToPtr(ssid, ssidPtr, false);
                try
                {
                    IntPtr bssListPtr;
                    Wlan.ThrowIfError(
                        Wlan.WlanGetNetworkBssList(client.clientHandle, info.interfaceGuid, ssidPtr, bssType, securityEnabled, IntPtr.Zero, out bssListPtr));
                    try
                    {
                        return ConvertBssListPtr(bssListPtr);
                    }
                    finally
                    {
                        Wlan.WlanFreeMemory(bssListPtr);
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(ssidPtr);
                }
            }

            /// <summary>
            /// Connects to a network defined by a connection parameters structure.
            /// </summary>
            /// <param name="connectionParams">The connection paramters.</param>
            protected void Connect(Wlan.WlanConnectionParameters connectionParams)
            {
                Wlan.ThrowIfError(
                    Wlan.WlanConnect(client.clientHandle, info.interfaceGuid, ref connectionParams, IntPtr.Zero));
            }

            /// <summary>
            /// Requests a connection (association) to the specified wireless network.
            /// </summary>
            /// <remarks>
            /// The method returns immediately. Progress is reported through the <see cref="WlanNotification"/> event.
            /// </remarks>
            public void Connect(Wlan.WlanConnectionMode connectionMode, Wlan.Dot11BssType bssType, string profile)
            {
                Wlan.WlanConnectionParameters connectionParams = new Wlan.WlanConnectionParameters();
                connectionParams.wlanConnectionMode = connectionMode;
                connectionParams.profile = profile;
                connectionParams.dot11BssType = bssType;
                connectionParams.flags = 0;
                Connect(connectionParams);
            }

            /// <summary>
            /// Connects (associates) to the specified wireless network, returning either on a success to connect
            /// or a failure.
            /// </summary>
            /// <param name="connectionMode"></param>
            /// <param name="bssType"></param>
            /// <param name="profile"></param>
            /// <param name="connectTimeout"></param>
            /// <returns></returns>
            public bool ConnectSynchronously(Wlan.WlanConnectionMode connectionMode, Wlan.Dot11BssType bssType, string profile, int connectTimeout)
            {
                queueEvents = true;
                try
                {
                    Connect(connectionMode, bssType, profile);
                    while (queueEvents && eventQueueFilled.WaitOne(connectTimeout, true))
                    {
                        lock (eventQueue)
                        {
                            while (eventQueue.Count != 0)
                            {
                                object e = eventQueue.Dequeue();
                                if (e is WlanConnectionNotificationEventData)
                                {
                                    WlanConnectionNotificationEventData wlanConnectionData = (WlanConnectionNotificationEventData)e;
                                    // Check if the conditions are good to indicate either success or failure.
                                    if (wlanConnectionData.notifyData.notificationSource == Wlan.WlanNotificationSource.ACM)
                                    {
                                        switch ((Wlan.WlanNotificationCodeAcm)wlanConnectionData.notifyData.notificationCode)
                                        {
                                            case Wlan.WlanNotificationCodeAcm.ConnectionComplete:
                                                if (wlanConnectionData.connNotifyData.profileName == profile)
                                                    return true;
                                                break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                finally
                {
                    queueEvents = false;
                    eventQueue.Clear();
                }
                return false; // timeout expired and no "connection complete"
            }

            /// <summary>
            /// Connects to the specified wireless network.
            /// </summary>
            /// <remarks>
            /// The method returns immediately. Progress is reported through the <see cref="WlanNotification"/> event.
            /// </remarks>
            public void Connect(Wlan.WlanConnectionMode connectionMode, Wlan.Dot11BssType bssType, Wlan.Dot11Ssid ssid, Wlan.WlanConnectionFlags flags)
            {
                Wlan.WlanConnectionParameters connectionParams = new Wlan.WlanConnectionParameters();
                connectionParams.wlanConnectionMode = connectionMode;
                connectionParams.dot11SsidPtr = Marshal.AllocHGlobal(Marshal.SizeOf(ssid));
                Marshal.StructureToPtr(ssid, connectionParams.dot11SsidPtr, false);
                connectionParams.dot11BssType = bssType;
                connectionParams.flags = flags;
                Connect(connectionParams);
                Marshal.DestroyStructure(connectionParams.dot11SsidPtr, ssid.GetType());
                Marshal.FreeHGlobal(connectionParams.dot11SsidPtr);
            }

            /// <summary>
            /// Deletes a profile.
            /// </summary>
            /// <param name="profileName">
            /// The name of the profile to be deleted. Profile names are case-sensitive.
            /// On Windows XP SP2, the supplied name must match the profile name derived automatically from the SSID of the network. For an infrastructure network profile, the SSID must be supplied for the profile name. For an ad hoc network profile, the supplied name must be the SSID of the ad hoc network followed by <c>-adhoc</c>.
            /// </param>
            public void DeleteProfile(string profileName)
            {
                Wlan.ThrowIfError(
                    Wlan.WlanDeleteProfile(client.clientHandle, info.interfaceGuid, profileName, IntPtr.Zero));
            }

            /// <summary>
            /// Sets the profile.
            /// </summary>
            /// <param name="flags">The flags to set on the profile.</param>
            /// <param name="profileXml">The XML representation of the profile. On Windows XP SP 2, special care should be taken to adhere to its limitations.</param>
            /// <param name="overwrite">If a profile by the given name already exists, then specifies whether to overwrite it (if <c>true</c>) or return an error (if <c>false</c>).</param>
            /// <returns>The resulting code indicating a success or the reason why the profile wasn't valid.</returns>
            public Wlan.WlanReasonCode SetProfile(Wlan.WlanProfileFlags flags, string profileXml, bool overwrite)
            {
                Wlan.WlanReasonCode reasonCode;
                Wlan.ThrowIfError(
                        Wlan.WlanSetProfile(client.clientHandle, info.interfaceGuid, flags, profileXml, null, overwrite, IntPtr.Zero, out reasonCode));
                return reasonCode;
            }

            /// <summary>
            /// Gets the profile's XML specification.
            /// </summary>
            /// <param name="profileName">The name of the profile.</param>
            /// <returns>The XML document.</returns>
            public string GetProfileXml(string profileName)
            {
                IntPtr profileXmlPtr;
                Wlan.WlanProfileFlags flags;
                Wlan.WlanAccess access;
                Wlan.ThrowIfError(
                    Wlan.WlanGetProfile(client.clientHandle, info.interfaceGuid, profileName, IntPtr.Zero, out profileXmlPtr, out flags,
                                   out access));
                try
                {
                    return Marshal.PtrToStringUni(profileXmlPtr);
                }
                finally
                {
                    Wlan.WlanFreeMemory(profileXmlPtr);
                }
            }

            /// <summary>
            /// Gets the information of all profiles on this interface.
            /// </summary>
            /// <returns>The profiles information.</returns>
            public Wlan.WlanProfileInfo[] GetProfiles()
            {
                IntPtr profileListPtr;
                Wlan.ThrowIfError(
                    Wlan.WlanGetProfileList(client.clientHandle, info.interfaceGuid, IntPtr.Zero, out profileListPtr));
                try
                {
                    Wlan.WlanProfileInfoListHeader header = (Wlan.WlanProfileInfoListHeader)Marshal.PtrToStructure(profileListPtr, typeof(Wlan.WlanProfileInfoListHeader));
                    Wlan.WlanProfileInfo[] profileInfos = new Wlan.WlanProfileInfo[header.numberOfItems];
                    long profileListIterator = profileListPtr.ToInt64() + Marshal.SizeOf(header);
                    for (int i = 0; i < header.numberOfItems; ++i)
                    {
                        Wlan.WlanProfileInfo profileInfo = (Wlan.WlanProfileInfo)Marshal.PtrToStructure(new IntPtr(profileListIterator), typeof(Wlan.WlanProfileInfo));
                        profileInfos[i] = profileInfo;
                        profileListIterator += Marshal.SizeOf(profileInfo);
                    }
                    return profileInfos;
                }
                finally
                {
                    Wlan.WlanFreeMemory(profileListPtr);
                }
            }

            internal void OnWlanConnection(Wlan.WlanNotificationData notifyData, Wlan.WlanConnectionNotificationData connNotifyData)
            {
                if (WlanConnectionNotification != null)
                    WlanConnectionNotification(notifyData, connNotifyData);

                if (queueEvents)
                {
                    WlanConnectionNotificationEventData queuedEvent = new WlanConnectionNotificationEventData();
                    queuedEvent.notifyData = notifyData;
                    queuedEvent.connNotifyData = connNotifyData;
                    EnqueueEvent(queuedEvent);
                }
            }

            internal void OnWlanReason(Wlan.WlanNotificationData notifyData, Wlan.WlanReasonCode reasonCode)
            {
                if (WlanReasonNotification != null)
                    WlanReasonNotification(notifyData, reasonCode);
                if (queueEvents)
                {
                    WlanReasonNotificationData queuedEvent = new WlanReasonNotificationData();
                    queuedEvent.notifyData = notifyData;
                    queuedEvent.reasonCode = reasonCode;
                    EnqueueEvent(queuedEvent);
                }
            }

            internal void OnWlanNotification(Wlan.WlanNotificationData notifyData)
            {
                if (WlanNotification != null)
                    WlanNotification(notifyData);
            }

            /// <summary>
            /// Enqueues a notification event to be processed serially.
            /// </summary>
            private void EnqueueEvent(object queuedEvent)
            {
                lock (eventQueue)
                    eventQueue.Enqueue(queuedEvent);
                eventQueueFilled.Set();
            }

            /// <summary>
            /// Gets the network interface of this wireless interface.
            /// </summary>
            /// <remarks>
            /// The network interface allows querying of generic network properties such as the interface's IP address.
            /// </remarks>
            public NetworkInterface NetworkInterface
            {
                get
                {
                    // Do not cache the NetworkInterface; We need it fresh
                    // each time cause otherwise it caches the IP information.
                    foreach (NetworkInterface netIface in NetworkInterface.GetAllNetworkInterfaces())
                    {
                        Guid netIfaceGuid = new Guid(netIface.Id);
                        if (netIfaceGuid.Equals(info.interfaceGuid))
                        {
                            return netIface;
                        }
                    }
                    return null;
                }
            }

            /// <summary>
            /// The GUID of the interface (same content as the <see cref="System.Net.NetworkInformation.NetworkInterface.Id"/> value).
            /// </summary>
            public Guid InterfaceGuid
            {
                get { return info.interfaceGuid; }
            }

            /// <summary>
            /// The description of the interface.
            /// This is a user-immutable string containing the vendor and model name of the adapter.
            /// </summary>
            public string InterfaceDescription
            {
                get { return info.interfaceDescription; }
            }

            /// <summary>
            /// The friendly name given to the interface by the user (e.g. "Local Area Network Connection").
            /// </summary>
            public string InterfaceName
            {
                get { return NetworkInterface.Name; }
            }
        }

        private IntPtr clientHandle;
        private uint negotiatedVersion;
        private readonly Wlan.WlanNotificationCallbackDelegate wlanNotificationCallback;
        private readonly Dictionary<Guid, WlanInterface> ifaces = new Dictionary<Guid, WlanInterface>();

        /// <summary>
        /// Creates a new instance of a Native Wifi service client.
        /// </summary>
        public WlanClient()
        {
            Wlan.ThrowIfError(
                Wlan.WlanOpenHandle(Wlan.WLAN_CLIENT_VERSION_XP_SP2, IntPtr.Zero, out negotiatedVersion, out clientHandle));
            try
            {
                Wlan.WlanNotificationSource prevSrc;
                wlanNotificationCallback = OnWlanNotification;
                Wlan.ThrowIfError(
                    Wlan.WlanRegisterNotification(clientHandle, Wlan.WlanNotificationSource.All, false, wlanNotificationCallback, IntPtr.Zero, IntPtr.Zero, out prevSrc));
            }
            catch
            {
                Close();
                throw;
            }
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
            Close();
        }

        ~WlanClient()
        {
            Close();
        }

        /// <summary>
        /// Closes the handle.
        /// </summary>
        private void Close()
        {
            if (clientHandle != IntPtr.Zero)
            {
                Wlan.WlanCloseHandle(clientHandle, IntPtr.Zero);
                clientHandle = IntPtr.Zero;
            }
        }

        private static Wlan.WlanConnectionNotificationData? ParseWlanConnectionNotification(ref Wlan.WlanNotificationData notifyData)
        {
            int expectedSize = Marshal.SizeOf(typeof(Wlan.WlanConnectionNotificationData));
            if (notifyData.dataSize < expectedSize)
                return null;

            Wlan.WlanConnectionNotificationData connNotifyData =
                (Wlan.WlanConnectionNotificationData)
                Marshal.PtrToStructure(notifyData.dataPtr, typeof(Wlan.WlanConnectionNotificationData));
            if (connNotifyData.wlanReasonCode == Wlan.WlanReasonCode.Success)
            {
                IntPtr profileXmlPtr = new IntPtr(
                    notifyData.dataPtr.ToInt64() +
                    Marshal.OffsetOf(typeof(Wlan.WlanConnectionNotificationData), "profileXml").ToInt64());
                connNotifyData.profileXml = Marshal.PtrToStringUni(profileXmlPtr);
            }

            return connNotifyData;
        }

        private void OnWlanNotification(ref Wlan.WlanNotificationData notifyData, IntPtr context)
        {
            WlanInterface wlanIface;
            ifaces.TryGetValue(notifyData.interfaceGuid, out wlanIface);

            switch (notifyData.notificationSource)
            {
                case Wlan.WlanNotificationSource.ACM:
                    switch ((Wlan.WlanNotificationCodeAcm)notifyData.notificationCode)
                    {
                        case Wlan.WlanNotificationCodeAcm.ConnectionStart:
                        case Wlan.WlanNotificationCodeAcm.ConnectionComplete:
                        case Wlan.WlanNotificationCodeAcm.ConnectionAttemptFail:
                        case Wlan.WlanNotificationCodeAcm.Disconnecting:
                        case Wlan.WlanNotificationCodeAcm.Disconnected:
                            Wlan.WlanConnectionNotificationData? connNotifyData = ParseWlanConnectionNotification(ref notifyData);
                            if (connNotifyData.HasValue)
                                if (wlanIface != null)
                                    wlanIface.OnWlanConnection(notifyData, connNotifyData.Value);
                            break;
                        case Wlan.WlanNotificationCodeAcm.ScanFail:
                            {
                                int expectedSize = Marshal.SizeOf(typeof(int));
                                if (notifyData.dataSize >= expectedSize)
                                {
                                    Wlan.WlanReasonCode reasonCode = (Wlan.WlanReasonCode)Marshal.ReadInt32(notifyData.dataPtr);
                                    if (wlanIface != null)
                                        wlanIface.OnWlanReason(notifyData, reasonCode);
                                }
                            }
                            break;
                    }
                    break;
                case Wlan.WlanNotificationSource.MSM:
                    switch ((Wlan.WlanNotificationCodeMsm)notifyData.notificationCode)
                    {
                        case Wlan.WlanNotificationCodeMsm.Associating:
                        case Wlan.WlanNotificationCodeMsm.Associated:
                        case Wlan.WlanNotificationCodeMsm.Authenticating:
                        case Wlan.WlanNotificationCodeMsm.Connected:
                        case Wlan.WlanNotificationCodeMsm.RoamingStart:
                        case Wlan.WlanNotificationCodeMsm.RoamingEnd:
                        case Wlan.WlanNotificationCodeMsm.Disassociating:
                        case Wlan.WlanNotificationCodeMsm.Disconnected:
                        case Wlan.WlanNotificationCodeMsm.PeerJoin:
                        case Wlan.WlanNotificationCodeMsm.PeerLeave:
                        case Wlan.WlanNotificationCodeMsm.AdapterRemoval:
                            Wlan.WlanConnectionNotificationData? connNotifyData = ParseWlanConnectionNotification(ref notifyData);
                            if (connNotifyData.HasValue)
                                if (wlanIface != null)
                                    wlanIface.OnWlanConnection(notifyData, connNotifyData.Value);
                            break;
                    }
                    break;
            }

            if (wlanIface != null)
                wlanIface.OnWlanNotification(notifyData);
        }

        /// <summary>
        /// Gets the WLAN interfaces.
        /// </summary>
        /// <value>The WLAN interfaces.</value>
        public WlanInterface[] Interfaces
        {
            get
            {
                IntPtr ifaceList;
                Wlan.ThrowIfError(
                    Wlan.WlanEnumInterfaces(clientHandle, IntPtr.Zero, out ifaceList));
                try
                {
                    Wlan.WlanInterfaceInfoListHeader header =
                        (Wlan.WlanInterfaceInfoListHeader)Marshal.PtrToStructure(ifaceList, typeof(Wlan.WlanInterfaceInfoListHeader));
                    Int64 listIterator = ifaceList.ToInt64() + Marshal.SizeOf(header);
                    WlanInterface[] interfaces = new WlanInterface[header.numberOfItems];
                    List<Guid> currentIfaceGuids = new List<Guid>();
                    for (int i = 0; i < header.numberOfItems; ++i)
                    {
                        Wlan.WlanInterfaceInfo info =
                            (Wlan.WlanInterfaceInfo)Marshal.PtrToStructure(new IntPtr(listIterator), typeof(Wlan.WlanInterfaceInfo));
                        listIterator += Marshal.SizeOf(info);
                        currentIfaceGuids.Add(info.interfaceGuid);

                        WlanInterface wlanIface;
                        if (!ifaces.TryGetValue(info.interfaceGuid, out wlanIface))
                        {
                            wlanIface = new WlanInterface(this, info);
                            ifaces[info.interfaceGuid] = wlanIface;
                        }

                        interfaces[i] = wlanIface;
                    }

                    // Remove stale interfaces
                    Queue<Guid> deadIfacesGuids = new Queue<Guid>();
                    foreach (Guid ifaceGuid in ifaces.Keys)
                    {
                        if (!currentIfaceGuids.Contains(ifaceGuid))
                            deadIfacesGuids.Enqueue(ifaceGuid);
                    }
                    while (deadIfacesGuids.Count != 0)
                    {
                        Guid deadIfaceGuid = deadIfacesGuids.Dequeue();
                        ifaces.Remove(deadIfaceGuid);
                    }

                    return interfaces;
                }
                finally
                {
                    Wlan.WlanFreeMemory(ifaceList);
                }
            }
        }

        /// <summary>
        /// Gets a string that describes a specified reason code.
        /// </summary>
        /// <param name="reasonCode">The reason code.</param>
        /// <returns>The string.</returns>
        public string GetStringForReasonCode(Wlan.WlanReasonCode reasonCode)
        {
            StringBuilder sb = new StringBuilder(1024); // the 1024 size here is arbitrary; the WlanReasonCodeToString docs fail to specify a recommended size
            Wlan.ThrowIfError(
                Wlan.WlanReasonCodeToString(reasonCode, sb.Capacity, sb, IntPtr.Zero));
            return sb.ToString();
        }
    }
}
