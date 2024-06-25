namespace language_ext_example.example.api;
using LanguageExt;
using LanguageExt.Common;
using LanguageExt.Pretty;
using static LanguageExt.Prelude;

public class With
{
    public static Func<int, Option<int>> WithExample(int x) => with<int, int>(x, a => a * 2);
}