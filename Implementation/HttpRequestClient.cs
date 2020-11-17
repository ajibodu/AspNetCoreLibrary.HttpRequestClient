using HttpRequestClient.Interface;
using HttpRequestClient.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace HttpRequestClient.Implementation
{
    public class HttpRequestClient<RespObj> : IHttpRequestClient<RespObj>, IDisposable
    {
        public HttpWebRequest Request;
        public HttpWebResponse Response;
        public HttpRequestClient(string url, bool enforceCert = false)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            if (!enforceCert)
            {
                // allows for validation of SSL conversations
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            }
            
            Request = (HttpWebRequest)WebRequest.Create(url);
        }

        public RespObj Post(string data, PostType postType, string contentType = null)
        {
            try
            {
                Request.Method = "POST";
                Request.ContentType = contentType ?? "application/json";
                if (postType == PostType.Byte)
                {
                    byte[] byteArray = Encoding.ASCII.GetBytes(data);
                    Request.ContentLength = byteArray.Length;
                    Stream inStream = Request.GetRequestStream();
                    inStream.Write(byteArray, 0, byteArray.Length);
                    inStream.Close();
                }
                else
                {
                    Request.ContentLength = data.Length;
                    Stream inStream = Request.GetRequestStream();
                    StreamWriter writeStream = new StreamWriter(inStream);
                    writeStream.Write(data);
                    writeStream.Flush();
                }
                Response = (HttpWebResponse)Request.GetResponse();
                using (Stream rpRead = Response.GetResponseStream())
                {
                    StreamReader stReader = new StreamReader(rpRead, Encoding.ASCII);
                    string outPutRD = stReader.ReadToEnd().Trim();
                    RespObj resp = JsonConvert.DeserializeObject<RespObj>(outPutRD);
                    return resp;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string PostString(string data, PostType postType, string contentType = null)
        {
            try
            {
                Request.Method = "POST";
                Request.ContentType = contentType ?? "application/json";
                if (postType == PostType.Byte)
                {
                    byte[] byteArray = Encoding.ASCII.GetBytes(data);
                    Request.ContentLength = byteArray.Length;
                    Stream inStream = Request.GetRequestStream();
                    inStream.Write(byteArray, 0, byteArray.Length);
                    inStream.Close();
                }
                else
                {
                    Request.ContentLength = data.Length;
                    Stream inStream = Request.GetRequestStream();
                    StreamWriter writeStream = new StreamWriter(inStream);
                    writeStream.Write(data);
                    writeStream.Flush();
                }
                Response = (HttpWebResponse)Request.GetResponse();
                using (Stream rpRead = Response.GetResponseStream())
                {
                    StreamReader stReader = new StreamReader(rpRead, Encoding.ASCII);
                    string outPutRD = stReader.ReadToEnd().Trim();
                    return outPutRD;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HttpWebResponse PostWebResp(string data, PostType postType, string contentType = null)
        {
            try
            {
                Request.Method = "POST";
                Request.ContentType = contentType ?? "application/json";
                if (postType == PostType.Byte)
                {
                    byte[] byteArray = Encoding.ASCII.GetBytes(data);
                    Request.ContentLength = byteArray.Length;
                    Stream inStream = Request.GetRequestStream();
                    inStream.Write(byteArray, 0, byteArray.Length);
                    inStream.Close();
                }
                else
                {
                    Request.ContentLength = data.Length;
                    Stream inStream = Request.GetRequestStream();
                    StreamWriter writeStream = new StreamWriter(inStream);
                    writeStream.Write(data);
                    writeStream.Flush();
                }
                var response = (HttpWebResponse)Request.GetResponse();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public RespObj Get()
        {
            try
            {
                Request.Method = "GET";
                Response = (HttpWebResponse)Request.GetResponse();
                using (Stream rpRead = Response.GetResponseStream())
                {
                    StreamReader stReader = new StreamReader(rpRead, Encoding.ASCII);
                    string outPutRD = stReader.ReadToEnd().Trim();
                    RespObj resp = JsonConvert.DeserializeObject<RespObj>(outPutRD);
                    return resp;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetStrng()
        {
            try
            {
                Request.Method = "GET";
                Response = (HttpWebResponse)Request.GetResponse();
                using (Stream rpRead = Response.GetResponseStream())
                {
                    StreamReader stReader = new StreamReader(rpRead, Encoding.ASCII);
                    string outPutRD = stReader.ReadToEnd().Trim();
                    return outPutRD;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        void IDisposable.Dispose()
        {
            Request = null;
            Response = null;
        }
    }

    //public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
    //{
    //    public TrustAllCertificatePolicy()
    //    {
    //    }

    //    public bool CheckValidationResult(System.Net.ServicePoint sp, System.Security.Cryptography.X509Certificates.X509Certificate cert, System.Net.WebRequest req, int problem)
    //    {
    //        return true;
    //    }
    //}
    
}
