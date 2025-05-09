using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;

namespace test_language_ext_example.Test;
[TestClass]
public class StateTest
{
    [TestMethod]
    public void TestState()
    {
        var money = State.DepositMoeney(500)
                         .Bind(_ => State.WithdrawMoney(200))
                         .Bind(_=> State.InterestCalculation((float)0.02))
                         .Run(100).State;
        Assert.AreEqual(408, money);   
    }
}