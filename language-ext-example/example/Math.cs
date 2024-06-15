namespace language_ext_example.example;
using LanguageExt;
using LanguageExt.Common;

using static LanguageExt.Prelude;
public class Math
{


    public static Either<Error, int> Add(int a, int b) =>
        guard(a > 0 && b > 0, Error.New("a and b must be positive")).ToEither().Map(_ => a + b);

    // * 將數值乘以2，數值必須是正數
    public static Either<Error, int> DoubleValue(int a) =>
        guard(a > 0, Error.New("a must be positive")).ToEither().Map(_ => a * 2);

    // * 將數值平方
    public static Option<int> SquareValue(int a) => Some(a * a);


    // * 將數值乘以2，數值必須是正數 Eff 版本
    public static Eff<int> DoubleValueEff(int a) => DoubleValue(a).ToEff();

    public static Eff<int> AddAndDouble(int a, int b) =>
    Add(a, b).ToEff()
    .Bind(DoubleValueEff)
    .Bind(Log<int>.LogMessage("計算失敗"))
    .MapFail(v => Log<Error>.LogMessage("計算失敗", v).Run().Match(
        Succ: v => v,
        Fail: e => Error.New("計算失敗,且 Log 失敗")
    ));


    // * lst裡面的數字都透過 DoubleValue 函數轉換成 兩倍數字
    public static Either<Error, Lst<int>> NumListToDouble(Lst<int> lst) =>
    Right(lst).Bind(t => t.Map(DoubleValue).Sequence());

    // * lst裡面的數字都透過 DoubleValue 函數轉換成 兩倍數字 Eff 版本
    public static Eff<Lst<int>> NumListToDoubleEff(Lst<int> lst) => NumListToDouble(lst).ToEff();




}

