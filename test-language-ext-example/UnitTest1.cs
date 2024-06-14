namespace test_language_ext_example;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Math.Add(1, 2).ShouldBeSome(some => Assert.AreEqual(3, some));       
    }
}