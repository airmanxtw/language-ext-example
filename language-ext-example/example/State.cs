namespace language_ext_example.example;
using LanguageExt;
using LanguageExt.Common;

using static LanguageExt.Prelude;
public class State
{
    public static State<int, int> DepositMoeney(int amount) => State<int, int>(s => (s, s + amount));
    public static State<int, int> WithdrawMoney(int amount) => State<int, int>(s => (s, s - amount));
    public static State<int, int> InterestCalculation(float rate) => State<int, int>(s => (s, s + (int)(s * rate)));
}
