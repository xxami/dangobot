
using System;
using dangobot.Net.Http;
using Newtonsoft.Json;

namespace dangobot.Net.Slack
{
    public interface IRpcMethod
    {
        object GetArguments();
        Type GetResponseModel();
    }

    public interface IRpcClient
    {
        object Call<T>(T method) where T: IRpcMethod;
    }

    public class JsonRpcClient : IRpcClient
    {
        public IHttpClient HttpClient { get; private set; }

        public JsonRpcClient(IHttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public object Call<T>(T method) where T: IRpcMethod
        {
            var jsonArgs = JsonConvert.SerializeObject(args);
            var result = HttpClient.Post(methodUrl, jsonArgs);
            return JsonConvert.DeserializeObject<TRpcResponseModel>(result);
        }
    }
}
