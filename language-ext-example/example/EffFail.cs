namespace language_ext_example.example;

using System.Globalization;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pretty;
using static LanguageExt.Prelude;

public class EffFail
{    
    public static Eff<Unit> Log(string message) =>
    Eff(() => ignore(message));
    public static Eff<int> LogSucc(int v) =>
    Log($"Result is {v}")
    .Map(_ => v);

    public static Eff<int> LogFail(Error error) =>
    Log($"Error: {error.Message}")
    .Bind(_ => FailEff<int>(error));

    public static Eff<int> Add(int a) =>
    Eff(() => a + 1);

    public static Eff<int> Square(int a) =>
    Eff(() => a * a);

    public static Eff<int> Formula1(int a) =>
    Add(a)
    .Bind(Square)
    .Bind(LogSucc)
    .IfFailEff(LogFail);

    public static Eff<int> Formula2(int a) =>
    Add(a)
    .Bind(Square)
    .MatchEff(
        Succ: LogSucc,
        Fail: LogFail
    );


}