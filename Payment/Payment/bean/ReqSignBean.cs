using PaymentSDK.bean;
using System;
using System.Reflection;
using System.Security.Cryptography;

namespace PaymentSDK
{
    abstract class ReqSignBean
    {
        public String sign;

        public void generateSign(String key)
        {
            Type t=GetType();//获得该类的Type
            String signValue=null;
            FieldInfo[] fields=t.GetFields();
            Array.Sort(fields, new FiledSort());
            foreach (FieldInfo pi in fields)
            {
                string name = pi.Name;
                if ("sign".Equals(name))
                {
                    continue;
                }
                var value = pi.GetValue(this);
                if (value is null)
                {
                    continue;
                }
                if (value is string)
                {
                    if (string.IsNullOrEmpty(value as string))
                    {
                        continue;
                    }
                }
                if (value is Decimal)
                {
                    String val = Convert.ToString(value);
                    if (val.EndsWith(".0"))
                    {
                        val = val.Substring(0, val.Length - 2);
                    }
                    else if (val.Contains("."))
                    {
                        val = val.TrimEnd('0').TrimEnd('.');
                    }
                    signValue += name + "=" + val + "&";
                }
                else { 
                    signValue += name + "=" + value + "&";
                }
            }
            signValue += "key=" + key;
            sign = md5(signValue);
        }

        private static String md5(String argString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(argString);
            byte[] md5Result = md5.ComputeHash(data);
            sbyte[] result = new sbyte[md5Result.Length];
            for (int i = 0; i < md5Result.Length; i++)
            {
                if (md5Result[i] > 127)
                {
                    result[i] = (sbyte)(md5Result[i] - 256);
                }
                else
                {
                    result[i] = (sbyte)md5Result[i];
                }
            }

            String strReturn = String.Empty;
            for (int i = 0; i < result.Length; i++)
            {
                int x = result[i] & 0xFF;
                if (x < 16)
                {
                    strReturn += "0";
                }
                strReturn += string.Format("{0:x}", x);
            }
            return strReturn.ToUpper();
        }
    }
}
