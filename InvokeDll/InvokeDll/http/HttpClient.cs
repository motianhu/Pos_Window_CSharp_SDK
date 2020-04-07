using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace InvokeDll.http
{
    public class HttpClient
    {
        public T PostDataHttp<T>(string baseUrl,
            Dictionary<string, string> headers,
            Dictionary<string, string> urlParas,
            string requestBody = null)
        {
            var resuleJson = string.Empty;
            try
            {
                var apiUrl = baseUrl;
                if (urlParas != null)
                {
                    foreach (var p in urlParas)
                    {
                        if (apiUrl.IndexOf("{" + p.Key + "}") > -1)
                        {
                            apiUrl = apiUrl.Replace("{" + p.Key + "}", p.Value);
                        }
                        else
                        {
                            apiUrl += string.Format("{0}{1}={2}", apiUrl.Contains("?") ? "&" : "?", p.Key, p.Value);
                        }
                    }
                }

                var webRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                webRequest.Headers["FrontType"] = "egc-mobile-ui";
                webRequest.Headers["terminalType"] = "window";
                webRequest.Headers["Accept-Language"] = "zh-cn";
                webRequest.Headers["parkUuid"] = "f67f34192972hengdahhdservicearea";
                webRequest.Headers["Project"] = "HHD";
                webRequest.Headers["Device"] = "1";
                webRequest.Headers["ipAddr"]= "172.0.0.1";

                if (!string.IsNullOrEmpty(requestBody))
                {
                    using (var postStream = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        postStream.Write(requestBody);
                    }
                }

                if (headers != null)
                {
                    foreach (var p in urlParas)
                    {
                        webRequest.Headers[p.Key] = p.Value;
                    }
                }

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
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(resuleJson);
        }
    }
}
