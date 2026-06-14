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

    public static void Run()
    {
        var solution1 = from x in Add(1, 2)
                        from y in Add(3, 4)
                        let z = Prelude.apply((a, b) => a + b, x, y)
                        select z;

        var solution2 = from x in Add(1, 2)
                        from y in Add(3, 4)
                        let z = from a in x
                                from b in y
                                select a + b
                        select z;

    }


}
