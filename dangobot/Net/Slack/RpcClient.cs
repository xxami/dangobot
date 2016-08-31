
using dangobot.Net.Http;
using Newtonsoft.Json;

namespace dangobot.Net.Slack
{
    public interface IRpcClient<in TRpcArguments, out TRpcResponseModel>
    {
        TRpcResponseModel Call(string method, TRpcArguments args);
    }

    public class JsonRpcClient<TRpcArguments, TRpcResponseModel>
        : IRpcClient<TRpcArguments, TRpcResponseModel>
    {
        public IHttpClient HttpClient { get; private set; }

        public JsonRpcClient(IHttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public TRpcResponseModel Call(string methodUrl, TRpcArguments args)
        {
            var jsonArgs = JsonConvert.SerializeObject(args);
            var result = HttpClient.Post(methodUrl, jsonArgs);
            return JsonConvert.DeserializeObject<TRpcResponseModel>(result);
        }
    }
}
