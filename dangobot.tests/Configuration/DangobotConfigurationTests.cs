
using System.IO;
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
            var tomlPath = SourceFromTestCases("Complete.toml");
            DangobotConfiguration.Read(tomlPath);
            var config = DangobotConfiguration.Items;
            Assert.That(config.Slack.ApiKey, Is.EqualTo("*insert token here*"));
        }
    }
}
