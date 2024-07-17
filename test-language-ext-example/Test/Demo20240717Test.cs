namespace test_language_ext_example.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;
using static LanguageExt.Prelude;
using LanguageExt.UnsafeValueAccess;

[TestClass]
public class Demo20240724Test
{
    [TestMethod]
    public void TestMethod1()
    {
        Demo20240717.Undivisible(7, 6).ShouldBeRight(v => Assert.AreEqual(6, v));
        
    }

    [TestMethod]
    public void TestMethod2()
    {
       
        Assert.AreEqual(false,Demo20240717.Prime(8)  );        

    }

    [TestMethod]
    public void TestMethod3()
    {
        var result=Demo20240717.Factor(8);
        var exp=new List<int>(){1,2,4,8};
        CollectionAssert.AreEqual(exp, result);


    }




}