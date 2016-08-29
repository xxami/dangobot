
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dangobot.Net.Http
{
    interface IHttpClient
    {
        string Post(string url, string postData);
    }

    public class HttpClient : IHttpClient
    {
        public string Post(string url, string postData)
        {
            using (var web = new WebClient())
                return web.UploadString(url, "POST", postData);
        }
    }
}
