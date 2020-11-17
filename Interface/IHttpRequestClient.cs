using HttpRequestClient.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HttpRequestClient.Interface
{
    interface IHttpRequestClient<RespObj>
    {
        RespObj Post(string data, PostType postType, string contentType = null);
        string PostString(string data, PostType postType, string contentType = null);
        HttpWebResponse PostWebResp(string data, PostType postType, string contentType = null);
        RespObj Get();
        string GetStrng();
    }
}
