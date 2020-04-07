using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using PaymentSDK.util;

namespace PaymentSDk.http
{
    class HttpClient
    {

        public T PostDataHttp<T>(String mchId, string baseUrl,
            Dictionary<string, string> headers,
            Dictionary<string, string> urlParas,
            string requestBody=null)
        {
            var resuleJson=string.Empty;
            try
            {
                var apiUrl=baseUrl;
                if (urlParas != null) {
                    foreach (var p in urlParas)
                    {
                        if (apiUrl.IndexOf("{" + p.Key + "}") > -1)
                        {
                            apiUrl=apiUrl.Replace("{" + p.Key + "}", p.Value);
                        }
                        else
                        {
                            apiUrl += string.Format("{0}{1}={2}", apiUrl.Contains("?") ? "&" : "?", p.Key, p.Value);
                        }
                    }
                }

                var webRequest=(HttpWebRequest)WebRequest.Create(apiUrl);
                webRequest.Method="POST";
                webRequest.ContentType="application/json";
                webRequest.Headers["FrontType"]="egc-mobile-ui";
                webRequest.Headers["terminalType"]="window";
                webRequest.Headers["deviceUuid"]= CommonUtil.GetMac();
                webRequest.Headers["appId"]="10007";
                webRequest.Headers["mchId"]= mchId;


                if (!string.IsNullOrEmpty(requestBody)) 
                {
                    using (var postStream=new StreamWriter(webRequest.GetRequestStream()))
                    {
                        postStream.Write(requestBody);
                    }
                }

                if (headers != null)
                {
                    foreach (var p in urlParas)
                    {
                        webRequest.Headers[p.Key]=p.Value;
                    }
                }

                var response=(HttpWebResponse)webRequest.GetResponse();

                using (Stream stream=response.GetResponseStream())
                {
                    using (StreamReader reader=new StreamReader(stream, Encoding.GetEncoding("UTF-8")))
                    {
                        resuleJson=reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(resuleJson);
        }

        public T GetDataHttp<T>(String mchId, string baseUrl)
        {
            var resuleJson = string.Empty;
            try
            {
                var apiUrl = baseUrl;

                var webRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
                webRequest.Method = "GET";
                webRequest.ContentType = "application/json";
                webRequest.Headers["FrontType"] = "egc-mobile-ui";
                webRequest.Headers["terminalType"] = "window";
                webRequest.Headers["deviceUuid"] = CommonUtil.GetMac();
                webRequest.Headers["appId"] = "10007";
                webRequest.Headers["mchId"] = mchId;

                var response = (HttpWebResponse)webRequest.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("UTF-8")))
                    {
                        resuleJson = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(resuleJson);
        }
    }

}
