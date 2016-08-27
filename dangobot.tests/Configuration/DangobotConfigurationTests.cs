
using System.IO;
using System.Linq;
using System.Reflection;
using dangobot.Configuration;
using NUnit.Framework;

namespace dangobot.tests.Configuration
{
    [TestFixture]
    public class DangobotConfigurationTests
    {
        private Stream SourceFromTestCases(string fileName)
        {
            var asm = Assembly.GetExecutingAssembly();
            var res = "dangobot.tests.Configuration.TestCases." + fileName;
            return asm.GetManifestResourceStream(res);
        }

        [Test]
        public void LoadsCompleteConfigurationFile()
        {
            var tomlData = SourceFromTestCases("Complete.toml");
            DangobotConfiguration.Read(tomlData);
            var config = DangobotConfiguration.Items;
            Assert.That(config.Slack.ApiKey, Is.EqualTo("*insert key here*"));
            Assert.That(config.Slack.Channels.Count, Is.EqualTo(2));
            Assert.That(config.Slack.Channels[0], Is.EqualTo("#general"));
            Assert.That(config.Slack.Channels[1], Is.EqualTo("#random"));
        }
    }
}
