
using System.Net;

namespace dangobot.Net.Http
{
    public interface IHttpClient
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
