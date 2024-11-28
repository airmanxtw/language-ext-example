namespace test_language_ext_example.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;
using LanguageExt.ClassInstances;


[TestClass]
public class TypeTest
{
    [TestMethod]
    public void TestTint()
    {
        var eqInt = default(EqInt);
        //var eqLst = default(EqLst<int>);
        Assert.AreEqual(true, eqInt.Equals(1, 1));

    }
}