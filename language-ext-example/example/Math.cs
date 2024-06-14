namespace language_ext_example.example;
using LanguageExt;
using static LanguageExt.Prelude;
public class Math
{
    public static Option<int> Add(int a, int b) => Some(a + b);
}

