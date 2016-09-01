
using dangobot.Net.Http;
using Newtonsoft.Json;

namespace dangobot.Net.Slack
{
    public interface IRpcMethod
    {
        
    }

    public interface IRpcClient
    {
        T Call<T>(T method) where T: IRpcClient;
    }

    public class JsonRpcClient : IRpcClient
    {
        public IHttpClient HttpClient { get; private set; }

        public JsonRpcClient(IHttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public T Call<T>(T method) where T: IRpcClient
        {
            var jsonArgs = JsonConvert.SerializeObject(args);
            var result = HttpClient.Post(methodUrl, jsonArgs);
            return JsonConvert.DeserializeObject<TRpcResponseModel>(result);
        }
    }
}
