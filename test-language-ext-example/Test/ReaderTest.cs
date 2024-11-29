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
}