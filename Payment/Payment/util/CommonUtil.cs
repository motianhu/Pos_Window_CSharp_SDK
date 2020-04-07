using System;
using System.Management;
using System.Net.NetworkInformation;

namespace PaymentSDK.util
{
    class CommonUtil
    {

        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }


        public static bool isFinishTrade(int trade)
        {
            return trade != (int)CodeEnum.ORDER_STATE_NOTPAY
                        && trade != (int)CodeEnum.ORDER_STATE_SCANING
                        && trade != (int)CodeEnum.ORDER_STATE_USERPAYING
                        && trade != (int)CodeEnum.ORDER_STATE_REVOKEING
                        && trade != (int)CodeEnum.ORDER_STATE_REFUNDING;
        }

        public static String GetMac()
        {
            String mac = GetNetworkAdpaterID();
            if (String.IsNullOrEmpty(mac))
            {
                mac = GetMacAddress();
            }
            return mac;
        }

        private static string GetMacAddress()
        {
            string physicalAddress = "";
            NetworkInterface[] nice = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adaper in nice)
            {
                if (adaper.Description == "en0")
                {
                    physicalAddress = adaper.GetPhysicalAddress().ToString();
                    break;
                }
                else
                {
                    physicalAddress = adaper.GetPhysicalAddress().ToString();
                    if (physicalAddress != "")
                    {
                        break;
                    };
                }
            }
            physicalAddress = System.Text.RegularExpressions.Regex.Replace(physicalAddress, @"(\w{2})", "$1-").Trim('-');
            return physicalAddress;
        }

        private static string GetNetworkAdpaterID()
        {
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                moc = null;
                mc = null;
                return mac.Trim().Replace(':', '-');
            }
            catch (Exception e)
            {
                Console.WriteLine("mac: " + e );
                return null;
            }
        }
    }
}
