using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpFactory.Send("http://192.168.120.145:8080/api/Web/WebRequest?Msg_type=WEB_ORDER_INFO_QUERY&Token=0A12667C82D4121DB333AE7BDBD4ABFA", "");
        }
    }

    public class HttpFactory
    {
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="method"></param>
        /// <param name="contentType"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static string Send(string url, string content, string method = "Post", string contentType = "application/json", int timeout = 15000)
        {
            string result = String.Empty;
            if (!String.IsNullOrEmpty(url))
            {
                try
                {
                    ServicePointManager.DefaultConnectionLimit = 1024; //提升系统外联的最大并发web访问数
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    request.Method = method;
                    request.ContentType = contentType;
                    request.Timeout = timeout;
                    request.Headers.Add("cookie", "token=token");
                    if (!String.IsNullOrEmpty(content))
                    {
                        byte[] body = Encoding.UTF8.GetBytes(content);
                        request.ContentLength = body.Length;
                        using (Stream stream = request.GetRequestStream())
                        {
                            stream.Write(body, 0, body.Length);
                            stream.Close();
                        }
                    }
                    WebResponse response = request.GetResponse();
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                    {
                        result = reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                    if (!Object.Equals(ex.Response, null))
                    {
                        using (StreamReader reader = new StreamReader(ex.Response?.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                        {
                            //throw new RequestException($"{reader.ReadToEnd()}", RequestException.ErrorCodeEnum.S500);
                        }
                    }
                    else throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
    }
}
