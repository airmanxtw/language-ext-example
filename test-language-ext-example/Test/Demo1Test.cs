namespace test_language_ext_example.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;
using LanguageExt.ClassInstances;
using LanguageExt.UnsafeValueAccess;

[TestClass]
public class Demo1Test
{
    [TestMethod]
    public void Test()
    {        
        Demo1.Go();
        Assert.AreEqual(16, 16);               
    }
}