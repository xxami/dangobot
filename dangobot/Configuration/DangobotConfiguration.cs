
using System.Collections.Generic;
using System.IO;
using Nett;

namespace dangobot.Configuration
{
    public class DangobotConfiguration
    {
        public SlackConfigurationItem Slack { get; set; }

        public static DangobotConfiguration Items { get; private set; }
        public static void Read(Stream tomlData)
        {
            DangobotConfiguration.Items = Toml.ReadStream<DangobotConfiguration>(tomlData);
        }
    }

    public class SlackConfigurationItem
    {
        public List<string> Channels { get; set; }
        public string ApiKey { get; set; } 
    }
}
