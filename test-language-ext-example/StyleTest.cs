namespace test_language_ext_example;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;
using LanguageExt.Common;
using LanguageExt.UnsafeValueAccess;

[TestClass]
public class StyleTest
{
    [TestMethod]
    public void TestGetNumAndAdd1AndDoubleAndSquareGoodStyle()
    {
        var result = Style.GetNumAndAdd1AndDoubleAndSquareGoodStyle().Run().ToEither().Value();
        Assert.AreEqual(144, result);
    }
}