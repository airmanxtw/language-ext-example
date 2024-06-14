namespace language_ext_example.example;
using LanguageExt;
using LanguageExt.Common;

using static LanguageExt.Prelude;
public class Math
{


    public static Either<Error, int> Add(int a, int b) =>
        guard(a > 0 && b > 0, Error.New("a and b must be positive")).ToEither().Map(_ => a + b);

    public static Either<Error, int> DoubleValue(int a) =>
        guard(a > 0, Error.New("a must be positive")).ToEither().Map(_ => a * 2);


    public static Eff<int> AddAndDouble(int a, int b) =>
    Add(a, b).ToEff()
    .Bind(v => DoubleValue(v).ToEff())
    .Bind(Log<int>.LogMessage("計算失敗"))
    .MapFail(v => Log<Error>.LogMessage("計算失敗", v).Run().Match(
        Succ: v => v,
        Fail: e => Error.New("計算失敗,且 Log 失敗")
    ));

    public static Eff<Lst<int>> GetLst() => Eff(() => List(1, 2, 3, 4, 5));

    public void Test()
    {
        var result = GetLst().Bind(v => v.Map(AddAndDouble).Sequence());
    }



}

