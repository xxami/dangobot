
using NLua;
using NUnit.Framework;

namespace dangobot.tests
{
    [TestFixture]
    public class LuaTests
    {
        [Test]
        public void LuaInterfaceEvaluatesSimpleExpression()
        {
            Lua state = new Lua();
            var res = state.DoString("return 1+1")[0] as double?;
            Assert.That(res, Is.EqualTo(2d));
        }
    }
}
