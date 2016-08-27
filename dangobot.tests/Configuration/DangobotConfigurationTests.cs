
using System;
using System.IO;
using System.Reflection;
using System.Text;
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
        public void LoadsCompleteConfiguration()
        {
            var tomlData = SourceFromTestCases("Complete.toml");
            DangobotConfiguration.Read(tomlData);
            var config = DangobotConfiguration.Items;
            Assert.That(config.Slack, Is.Not.Null);
            Assert.That(config.Slack.ApiKey, Is.EqualTo("*insert key here*"));
            Assert.That(config.Slack.Channels.Count, Is.EqualTo(2));
            Assert.That(config.Slack.Channels[0], Is.EqualTo("#general"));
            Assert.That(config.Slack.Channels[1], Is.EqualTo("#random"));
        }

        [Test]
        public void LoadsEmptyConfiguration()
        {
            var tomlData = new MemoryStream(Encoding.UTF8.GetBytes(""));
            DangobotConfiguration.Read(tomlData);
            var config = DangobotConfiguration.Items;
            Assert.That(config.Slack, Is.Null);
        }

        [Test]
        public void LoadsPartialConfiguration()
        {
            var tomlData = SourceFromTestCases("Partial.toml");
            DangobotConfiguration.Read(tomlData);
            var config = DangobotConfiguration.Items;
            Assert.That(config.Slack, Is.Not.Null);
            Assert.That(config.Slack.ApiKey, Is.EqualTo("*insert key here*"));
            Assert.That(config.Slack.Channels, Is.Null);
        }

        [Test]
        public void LoadsPartialConfigurationWithUndefinedData()
        {
            var tomlData = SourceFromTestCases("UnknownValues.toml");
            DangobotConfiguration.Read(tomlData);
            var config = DangobotConfiguration.Items;
            Assert.That(config.Slack, Is.Not.Null);
            Assert.That(config.Slack.ApiKey, Is.EqualTo("*insert key here*"));
        }

        [Test]
        public void DoesNotLoadMalformedConfiguration()
        {
            var tomlData = new MemoryStream(Encoding.UTF8.GetBytes("[]*9$£"));
            Assert.Throws<Exception>(() => DangobotConfiguration.Read(tomlData));
        }

        [Test]
        public void DoesNotLoadConfigurationWithInvalidDataType()
        {
            var tomlData = SourceFromTestCases("MismatchingTypes.toml");
            Assert.Throws<Exception>(() => DangobotConfiguration.Read(tomlData));
        }
    }
}
