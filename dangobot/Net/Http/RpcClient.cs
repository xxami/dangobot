﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dangobot.Net.Http
{
    public interface IRpcClient
    {
        string Call(string method, string jsonArguments);
    }

    public class JsonRpcClient
    {
        public IHttpClient HttpClient { get; private set; }

        public JsonRpcClient(IHttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public string Call(string methodUrl, string jsonArguments)
        {
            return HttpClient.Post(methodUrl, jsonArguments);
        }
    }
}
