namespace test_language_ext_example.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example.api;
using LanguageExt;
using LanguageExt.UnitTesting;

[TestClass]
public class WithTest
{
    [TestMethod]
    public void TestWith1()
    {
        With.WithExample(10)(10).ShouldBeSome(r => Assert.AreEqual(20, r));
    }
}