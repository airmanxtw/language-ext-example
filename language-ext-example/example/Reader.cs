using language_ext_example.example.api.Env;
using LanguageExt;

namespace language_ext_example.example;

public class Reader
{
    /// <summary>
    /// Runs the Reader monad and memoizes the result in a TryOption monad.
    /// </summary>
    /// <returns></returns>
    public static Reader<TestEnvStruct, string> GetEnvValue() => Prelude.Reader<TestEnvStruct, string>(e => e.GetValue());

    public static Reader<Func<int, int>, int> GetReader(int a) => Prelude.Reader<Func<int, int>, int>(f => f(a));
}
