namespace language_ext_example.example;

using LanguageExt;
using LanguageExt.Common;

using static LanguageExt.Prelude;
public class State
{
    public static State<int, int> DepositMoeney(int amount) => State<int, int>(s => (s, s + amount));
    public static State<int, int> WithdrawMoney(int amount) => State<int, int>(s => (s, s - amount));
    public static State<int, int> InterestCalculation(float rate) => State<int, int>(s => (s, s + (int)(s * rate)));

    public static State<int, float> Pi => State<int, float>(s => (3.14f * s, s));
    public static State<float, float> Square => State<float, float>(s => (s * s, s));

    public static TryOption<float> CalculateAreaOfCircle(int radius)
    {
        return null;
        // var areaState = Pi.Bind<int, float, float>(p => Square);

        // var s = areaState.Run(radius);

        // return s.Value;
    }

}
