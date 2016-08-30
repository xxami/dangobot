
using dangobot.Net.Http;
using Moq;
using NUnit.Framework;

namespace dangobot.tests.Net.Http
{
    [TestFixture]
    public class RpcClientTests
    {
        [Test]
        public void MakesHttpPostRequest()
        {
            var methodUrl = "url";
            var jsonArguments = "args";

            var mock = new Mock<IHttpClient>();
            mock.Setup(client => client.Post(methodUrl, jsonArguments))
                .Returns("success");

            var rpcClient = new BasicRpcClient(mock.Object);

            var response = rpcClient.Call(methodUrl, jsonArguments);
            Assert.That(response, Is.EqualTo("success"));
        }
    }
}
