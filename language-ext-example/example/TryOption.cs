using language_ext_example.example.api.Env;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.UnsafeValueAccess;
using static LanguageExt.Prelude;
namespace language_ext_example.example;

public class TryOption
{
    public static TryOption<int> Add(int x, int y) => () => x + y;
}
