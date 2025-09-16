using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt.UnsafeValueAccess;
using System.Runtime.Serialization;
using LanguageExt.SomeHelp;

namespace test_language_ext_example.Test;

[TestClass]
public class TryOptionTest
{
    [TestMethod]
    public void TestTryOption()
    {
        var result = TryOption.Add(10, 12);

        var value = result.Try().Match(
            Some: v => v,
            None: () => -1,
            Fail: ex => -1);



        Assert.AreEqual(22, value);
    }




}