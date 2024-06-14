namespace test_language_ext_example;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;
using LanguageExt.Common;
using LanguageExt.UnsafeValueAccess;

[TestClass]
public class MathTest
{
    [TestMethod]
    public void TestAddAndDoubleSucc()
    {
        var result = Math.AddAndDouble(1, 2).Run().ToEither().Value();
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void TestAddAndDoubleFail()
    {
        var result = Math.AddAndDouble(-1, 2).Run().ToEither().MapLeft(e => e.Message);
        Assert.AreEqual("a and b must be positive", result);
    }

    [TestMethod]
    public void TestLstToDoubleSucc()
    {
        // source: [1, 2, 3, 4, 5, 6, 7, 10]
        var result = DataSource.GetNumList()
                    .Bind(Math.NumListToDoubleEff)
                    .Run().ToEither().Value();

        // expect: [2, 4, 6, 8, 10, 12, 14, 20]
        var expect = new List<int>() { 2, 4, 6, 8, 10, 12, 14, 20 };

        CollectionAssert.AreEqual(expect, result.ToList());
        //Assert.IsTrue(expect.SequenceEqual([.. result]));
    }

    [TestMethod]
    public void TestValue()
    {
        var result = Math.Add(-1, 1).Value();
        Assert.AreEqual(0, result);
    }

}