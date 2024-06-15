namespace language_ext_example.example;
using LanguageExt;
using LanguageExt.Common;
using LanguageExt.Pretty;
using static LanguageExt.Prelude;

// point-free style
public class Style
{
    // from DataSource get a number , and add 1 to it, then double it, finally square it
    // * 從資料庫取得一個數字，加1，然後乘以2，最後平方

    // bad style
    public static Eff<int> GetNumAndAdd1AndDoubleAndSquare() =>
        DataSource.GetNum()
        .Bind(v => Math.Add(v, 1).ToEff())
        .Bind(v => Math.DoubleValue(v).ToEff())
        .Bind(v => Math.SquareValue(v).ToEff());

    // good style
    private static Eff<int> GetNum() => DataSource.GetNum();
    private static Eff<int> Add1(int v) => Math.Add(v, 1).ToEff();
    private static Eff<int> Double(int v) => Math.DoubleValue(v).ToEff();
    private static Eff<int> Square(int v) => Math.SquareValue(v).ToEff();

    public static Eff<int> GetNumAndAdd1AndDoubleAndSquareGoodStyle() =>
    GetNum()
    .Bind(Add1)
    .Bind(Double)
    .Bind(Square);


}