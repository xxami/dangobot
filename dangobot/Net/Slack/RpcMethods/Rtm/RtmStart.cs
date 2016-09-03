
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dangobot.Net.Slack.RpcMethods.Rtm
{
    public class RtmStart : IRpcMethod
    {
        class Arguments
        {
            public string ApiToken { get; set; }
        }

        private readonly Arguments _arguments;

        public RtmStart(string apiToken)
        {
            _arguments = new Arguments()
            {
                ApiToken = apiToken,
            };
        }

        public object GetArguments()
        {
            return _arguments;
        }

        public Type GetResponseModel()
        {
            return typeof(int);
        }
    }
}
