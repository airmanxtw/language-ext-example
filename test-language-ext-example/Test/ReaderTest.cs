using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt.UnsafeValueAccess;

namespace test_language_ext_example.Test;

[TestClass]
public class ReaderTest
{
    [TestMethod]
    public void TestReader()
    {
        var value = Reader.GetEnvValue().ToEither(default).ValueUnsafe();
        Assert.AreEqual("Hello, World!", value);
    }

    [TestMethod]
    public void TestReaderFunc()
    {
        var reader = Reader.GetReader(10);
        var func = new Func<int, int>(x =>
        {
            throw new Exception("Func Exception");
            return x * 2;
        });
        var result = reader.Run(func).Match(
            Succ: v => v,
            Fail: _ => -1
        );
        Assert.AreEqual(-1, result);
    }
}