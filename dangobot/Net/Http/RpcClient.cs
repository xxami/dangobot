
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dangobot.Net.Http
{
    interface IRpcClient
    {
        string Call(string method, string jsonArguments);
    }

    public class BasicRpcClient
    {
        public string Call(string methodUrl, string jsonArguments)
        {
            using (var web = new WebClient())
                return web.UploadString(methodUrl, "POST", jsonArguments);
        }
    }
}
