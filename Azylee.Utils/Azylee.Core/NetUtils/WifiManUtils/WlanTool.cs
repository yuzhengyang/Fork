using Azylee.Core.ModelUtils.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.NetUtils.WifiManUtils
{
    /// <summary>
    /// Wlan连接工具
    /// </summary>
    public class WlanTool
    {
        /// <summary>
        /// 连接到指定Wifi网络
        /// </summary>
        /// <param name="name">wifi名称</param>
        /// <param name="key">wifi密码</param>
        /// <returns></returns>
        public bool Connect(string name, string key)
        {
            WlanClient client = new WlanClient();
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                // Lists all networks with WEP security
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    if (network.profileName == name)
                    {
                        Connect(wlanIface, network, key);
                    }
                }

                if (wlanIface.InterfaceState == Wlan.WlanInterfaceState.Connected &&
                   wlanIface.CurrentConnection.isState == Wlan.WlanInterfaceState.Connected &&
                   wlanIface.CurrentConnection.profileName == name)
                {
                    return true;
                }
            }
            return false;
        }
        private void Connect(WlanClient.WlanInterface wlanIface, Wlan.WlanAvailableNetwork ssid, string key)
        {
            bool result = false;
            string description = "初始化错误";
            try
            {
                String auth = string.Empty;
                String cipher = string.Empty;
                bool isNoKey = false;
                String keytype = string.Empty;
                switch (ssid.dot11DefaultAuthAlgorithm)
                {
                    case Wlan.Dot11AuthAlgorithm.IEEE80211_Open:
                        auth = "open"; break;
                    //case Wlan.Dot11AuthAlgorithm.IEEE80211_SharedKey: 
                    // 'not implemented yet; 
                    //break; 
                    case Wlan.Dot11AuthAlgorithm.RSNA:
                        auth = "WPA2PSK"; break;
                    case Wlan.Dot11AuthAlgorithm.RSNA_PSK:
                        auth = "WPA2PSK"; break;
                    case Wlan.Dot11AuthAlgorithm.WPA:
                        auth = "WPAPSK"; break;
                    case Wlan.Dot11AuthAlgorithm.WPA_None:
                        auth = "WPAPSK"; break;
                    case Wlan.Dot11AuthAlgorithm.WPA_PSK:
                        auth = "WPAPSK"; break;
                }

                switch (ssid.dot11DefaultCipherAlgorithm)
                {
                    case Wlan.Dot11CipherAlgorithm.CCMP:
                        cipher = "AES";
                        keytype = "passPhrase";
                        break;
                    case Wlan.Dot11CipherAlgorithm.TKIP:
                        cipher = "TKIP";
                        keytype = "passPhrase";
                        break;
                    case Wlan.Dot11CipherAlgorithm.None:
                        cipher = "none"; keytype = "";
                        isNoKey = true;
                        break;
                    case Wlan.Dot11CipherAlgorithm.WEP:
                        cipher = "WEP";
                        keytype = "networkKey";
                        break;
                    case Wlan.Dot11CipherAlgorithm.WEP40:
                        cipher = "WEP";
                        keytype = "networkKey";
                        break;
                    case Wlan.Dot11CipherAlgorithm.WEP104:
                        cipher = "WEP";
                        keytype = "networkKey";
                        break;
                }

                if (isNoKey && !string.IsNullOrEmpty(key))
                {
                    description = "无法连接网络 SSID:" + ssid.profileName + "\r\n"
                        + "Dot11AuthAlgorithm:" + ssid.dot11DefaultAuthAlgorithm + "\r\n"
                        + "Dot11CipherAlgorithm:" + ssid.dot11DefaultAuthAlgorithm.ToString();
                    return;
                }
                else if (!isNoKey && string.IsNullOrEmpty(key))
                {
                    description = "无法连接网络 SSID:" + ssid.profileName + "\r\n"
                        + "Dot11AuthAlgorithm:" + ssid.dot11DefaultAuthAlgorithm + "\r\n"
                        + "Dot11CipherAlgorithm:" + ssid.dot11DefaultAuthAlgorithm.ToString();
                    return;
                }
                else
                {
                    string profileName = ssid.profileName; // this is also the SSID 
                    string mac = StringToHex(profileName);
                    string profileXml = string.Empty;
                    if (!string.IsNullOrEmpty(key))
                    {
                        profileXml = string.Format("<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>{0}</name><SSIDConfig><SSID><hex>{1}</hex><name>{0}</name></SSID></SSIDConfig><connectionType>ESS</connectionType><connectionMode>auto</connectionMode><autoSwitch>false</autoSwitch><MSM><security><authEncryption><authentication>{2}</authentication><encryption>{3}</encryption><useOneX>false</useOneX></authEncryption><sharedKey><keyType>{4}</keyType><protected>false</protected><keyMaterial>{5}</keyMaterial></sharedKey><keyIndex>0</keyIndex></security></MSM></WLANProfile>",
                            profileName, mac, auth, cipher, keytype, key);
                    }
                    else
                    {
                        profileXml = string.Format("<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>{0}</name><SSIDConfig><SSID><hex>{1}</hex><name>{0}</name></SSID></SSIDConfig><connectionType>ESS</connectionType><connectionMode>auto</connectionMode><autoSwitch>false</autoSwitch><MSM><security><authEncryption><authentication>{2}</authentication><encryption>{3}</encryption><useOneX>false</useOneX></authEncryption></security></MSM></WLANProfile>",
                            profileName, mac, auth, cipher, keytype);
                    }

                    wlanIface.SetProfile(Wlan.WlanProfileFlags.AllUser, profileXml, true);
                    //ssid.wlanInterface.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, ssid.profileNames);
                    wlanIface.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, profileName);
                }
            }
            catch (Exception e)
            {
                description = "无法连接网络 SSID:" + ssid.profileName + "\r\n"
                    + "Dot11AuthAlgorithm:" + ssid.dot11DefaultAuthAlgorithm + "\r\n"
                    + "Dot11CipherAlgorithm:" + ssid.dot11DefaultAuthAlgorithm.ToString() + "\r\n"
                    + e.Message;
                return;
            }
        }
        private Tuple<bool, string> ConnectSynchronously(WlanClient.WlanInterface wlanIface, Wlan.WlanAvailableNetwork ssid, string key)
        {
            bool result = false;
            string description = "初始化错误";
            try
            {
                String auth = string.Empty;
                String cipher = string.Empty;
                bool isNoKey = false;
                String keytype = string.Empty;
                switch (ssid.dot11DefaultAuthAlgorithm)
                {
                    case Wlan.Dot11AuthAlgorithm.IEEE80211_Open:
                        auth = "open"; break;
                    //case Wlan.Dot11AuthAlgorithm.IEEE80211_SharedKey: 
                    // 'not implemented yet; 
                    //break; 
                    case Wlan.Dot11AuthAlgorithm.RSNA:
                        auth = "WPA2PSK"; break;
                    case Wlan.Dot11AuthAlgorithm.RSNA_PSK:
                        auth = "WPA2PSK"; break;
                    case Wlan.Dot11AuthAlgorithm.WPA:
                        auth = "WPAPSK"; break;
                    case Wlan.Dot11AuthAlgorithm.WPA_None:
                        auth = "WPAPSK"; break;
                    case Wlan.Dot11AuthAlgorithm.WPA_PSK:
                        auth = "WPAPSK"; break;
                }

                switch (ssid.dot11DefaultCipherAlgorithm)
                {
                    case Wlan.Dot11CipherAlgorithm.CCMP:
                        cipher = "AES";
                        keytype = "passPhrase";
                        break;
                    case Wlan.Dot11CipherAlgorithm.TKIP:
                        cipher = "TKIP";
                        keytype = "passPhrase";
                        break;
                    case Wlan.Dot11CipherAlgorithm.None:
                        cipher = "none"; keytype = "";
                        isNoKey = true;
                        break;
                    case Wlan.Dot11CipherAlgorithm.WEP:
                        cipher = "WEP";
                        keytype = "networkKey";
                        break;
                    case Wlan.Dot11CipherAlgorithm.WEP40:
                        cipher = "WEP";
                        keytype = "networkKey";
                        break;
                    case Wlan.Dot11CipherAlgorithm.WEP104:
                        cipher = "WEP";
                        keytype = "networkKey";
                        break;
                }

                if (isNoKey && !string.IsNullOrEmpty(key))
                {
                    description = "无法连接网络 SSID:" + ssid.profileName + "\r\n"
                        + "Dot11AuthAlgorithm:" + ssid.dot11DefaultAuthAlgorithm + "\r\n"
                        + "Dot11CipherAlgorithm:" + ssid.dot11DefaultAuthAlgorithm.ToString();
                    return new Tuple<bool, string>(result, description);
                }
                else if (!isNoKey && string.IsNullOrEmpty(key))
                {
                    description = "无法连接网络 SSID:" + ssid.profileName + "\r\n"
                        + "Dot11AuthAlgorithm:" + ssid.dot11DefaultAuthAlgorithm + "\r\n"
                        + "Dot11CipherAlgorithm:" + ssid.dot11DefaultAuthAlgorithm.ToString();
                    return new Tuple<bool, string>(result, description);
                }
                else
                {
                    string profileName = ssid.profileName; // this is also the SSID 
                    string mac = StringToHex(profileName);
                    string profileXml = string.Empty;
                    if (!string.IsNullOrEmpty(key))
                    {
                        profileXml = string.Format("<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>{0}</name><SSIDConfig><SSID><hex>{1}</hex><name>{0}</name></SSID></SSIDConfig><connectionType>ESS</connectionType><connectionMode>auto</connectionMode><autoSwitch>false</autoSwitch><MSM><security><authEncryption><authentication>{2}</authentication><encryption>{3}</encryption><useOneX>false</useOneX></authEncryption><sharedKey><keyType>{4}</keyType><protected>false</protected><keyMaterial>{5}</keyMaterial></sharedKey><keyIndex>0</keyIndex></security></MSM></WLANProfile>",
                            profileName, mac, auth, cipher, keytype, key);
                    }
                    else
                    {
                        profileXml = string.Format("<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>{0}</name><SSIDConfig><SSID><hex>{1}</hex><name>{0}</name></SSID></SSIDConfig><connectionType>ESS</connectionType><connectionMode>auto</connectionMode><autoSwitch>false</autoSwitch><MSM><security><authEncryption><authentication>{2}</authentication><encryption>{3}</encryption><useOneX>false</useOneX></authEncryption></security></MSM></WLANProfile>",
                            profileName, mac, auth, cipher, keytype);
                    }

                    wlanIface.SetProfile(Wlan.WlanProfileFlags.AllUser, profileXml, true);
                    //ssid.wlanInterface.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, ssid.profileNames);
                    bool success = wlanIface.ConnectSynchronously(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, profileName, 15000);
                    if (!success)
                    {
                        description = "连接网络失败 SSID:" + ssid.profileName + "\r\n"
                            + "Dot11AuthAlgorithm:" + ssid.dot11DefaultAuthAlgorithm + "\r\n"
                            + "Dot11CipherAlgorithm:" + ssid.dot11DefaultAuthAlgorithm.ToString();
                        return new Tuple<bool, string>(result, description);
                    }
                    else
                    {
                        result = true;
                        description = "连接网络成功";
                        return new Tuple<bool, string>(result, description);
                    }
                }
            }
            catch (Exception e)
            {
                description = "无法连接网络 SSID:" + ssid.profileName + "\r\n"
                    + "Dot11AuthAlgorithm:" + ssid.dot11DefaultAuthAlgorithm + "\r\n"
                    + "Dot11CipherAlgorithm:" + ssid.dot11DefaultAuthAlgorithm.ToString() + "\r\n"
                    + e.Message;
                return new Tuple<bool, string>(result, description);
            }
        }
        /// <summary>
        /// 是否连接到某wifi
        /// </summary>
        /// <param name="name">wifi名称</param>
        /// <returns></returns>
        public bool IsConnect(string name)
        {
            WlanClient client = new WlanClient();
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                if (wlanIface.InterfaceState == Wlan.WlanInterfaceState.Connected &&
                    wlanIface.CurrentConnection.isState == Wlan.WlanInterfaceState.Connected &&
                    wlanIface.CurrentConnection.profileName == name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>  
        /// 字符串转Hex  
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        public static string StringToHex(string s)
        {
            StringBuilder sb = new StringBuilder();
            //默认是System.Text.Encoding.Default.GetBytes(str)
            byte[] byStr = Encoding.Default.GetBytes(s);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(Convert.ToString(byStr[i], 16));
            }
            return (sb.ToString().ToUpper());
        }
        /// <summary>
        /// Converts a 802.11 SSID to a string.
        /// </summary>
        public static string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {
            return Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
        }
    }
}
