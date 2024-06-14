namespace language_ext_example.example;
using LanguageExt;
using LanguageExt.Common;
using LanguageExt.Pretty;
using static LanguageExt.Prelude;

public class Log<T>
{
    // 模似一個 Log 函數
    public static Eff<T> LogMessage(string message, T data) =>
    Eff(() => ignore("寫入log"))
    .Map(_ => data);

    // 模似一個 Log 函數,使用 curry 來簡化參數T的傳遞
    public static Func<T, Eff<T>> LogMessage(string message) => curry<string, T, Eff<T>>(LogMessage)(message);

}