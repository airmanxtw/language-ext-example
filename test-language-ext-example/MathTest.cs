namespace test_language_ext_example;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;
using LanguageExt.Common;

[TestClass]
public class MathTest
{
    [TestMethod]
    public void TestAddAndDoubleSucc()
    {
        var result = Math.AddAndDouble(1, 2).Run().Match(Succ: v => v, Fail: e => -1);
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void TestAddAndDoubleFail()
    {
        var result = Math.AddAndDouble(-1, 2).Run().Match(Succ: v => string.Empty, Fail: e => e.Message);
        Assert.AreEqual("a and b must be positive", result);
    }
}