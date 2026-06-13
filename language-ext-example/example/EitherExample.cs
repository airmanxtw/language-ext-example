namespace language_ext_example.example;

using System.Globalization;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pretty;
using LanguageExt.TypeClasses;
using static LanguageExt.TypeClass;
using static LanguageExt.Prelude;




public class EitherExample
{
    public static Either<string, Option<int>> Add(int a, int b) =>
        Either<string, Option<int>>.Right(Some(a + b));

    public void Run()
    {

    }


}
