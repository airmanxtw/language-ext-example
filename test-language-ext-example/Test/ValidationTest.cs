namespace test_language_ext_example.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;

[TestClass]
public class ValidationTest
{
    [TestMethod]
    public void TestError1()
    {
        ValidationExm.CheckID("A12345678A").ShouldBeLeft(e => Assert.AreEqual("這不是數字(0~9):A", e.First().Message));
    }

    [TestMethod]
    public void TestError2()
    {
        ValidationExm.CheckID("9123456780").ShouldBeLeft(e => Assert.AreEqual("第一個字不是字母(A~Z):9", e.First().Message));
    }

    [TestMethod]
    public void TestError3()
    {
        ValidationExm.CheckID("912345678A").ShouldBeLeft(e => Assert.AreEqual(2, e.Length));
    }

    [TestMethod]
    public void TestError4()
    {
        Assert.AreEqual("10123456789", string.Concat(ValidationExm.GetUniCode("A123456789")));
    }

    [TestMethod]
    public void TestError5()
    {
        Assert.AreEqual("1084800848", string.Concat(ValidationExm.MutilpUniAndSpec("A12345678").Map(c => c.ToString())));
    }

    [TestMethod]
    public void TestError6()
    {
        Assert.AreEqual(9, ValidationExm.GetCheckCode("A12345678"));
    }



    [TestMethod]
    public void TestMethod1()
    {
        //Assert.AreEqual(52,'4');
        ValidationExm.CheckID("A123456789").ShouldBeRight(e => Assert.AreEqual("A123456789", string.Concat(e)));
        //ValidationExm.CheckID("A123456789").ShouldBeLeft(e=>Assert.AreEqual("這不是數字(0~9)", e.First().Message));
        //ValidationExm.CheckID("A123456789").ShouldBeLeft(e=>Assert.AreEqual(1, e.Length));
        //Assert.AreEqual(10, ValidationExm.GetCode('a'));

        //Math.Add(-1, 2).ShouldBeLeft(e => Assert.AreEqual("a and b must be positive", e.Message));
    }
}