namespace test_language_ext_example.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;
using LanguageExt.ClassInstances;
using LanguageExt.UnsafeValueAccess;

[TestClass]
public class ListMapTest
{
    [TestMethod]
    public void TestListToSquareValue()
    {
        var result = default(EqOption<IEnumerable<int>>)
        .Equals(
            ListMap.ListToSquareValueA().Sequence(),
            ListMap.ListToSquareValueB()
        );
        Assert.IsTrue(result);
    }

}