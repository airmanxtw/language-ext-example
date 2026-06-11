using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt.UnsafeValueAccess;
using System.Runtime.Serialization;
using LanguageExt.SomeHelp;

namespace test_language_ext_example.Test;

[TestClass]
public class WriterTest
{
    [TestMethod]
    public void TestWriter()
    {
        var result = from w in Writer.Odd(10)
                     from x in Writer.Odd(12)
                     select w + x;

        var value = result.Run().Value.ToList().First();


        Assert.AreEqual(22, value);
    }

    [TestMethod]
    public void TestWriter2()
    {
        var result = from w in Writer.Odd(11)
                     from x in Writer.Odd(13)
                     select w + x;

        var (value, log) = result.Run();

        Assert.AreEqual(2, log.Count);
        Assert.AreEqual("偶數", log[0]);
        Assert.AreEqual("偶數", log[1]);
    }


}