namespace language_ext_example.example;
using LanguageExt;
using LanguageExt.Common;

using static LanguageExt.Prelude;

public class SeqExm
{
    private static Either<string, int> IsEven(int i) => i % 2 == 0 ? Right<string, int>(i) : Left<string, int>("Not even");
    public static Either<string, int> GetFirstOdd1() => List(1, 2, 3, 4, 5, 6, 7, 8, 9, 10).Map(IsEven).Where(x => x.IsRight).FirstOrDefault();

    // faster than GetFirstOdd1
    public static Either<string, int> GetFirstOdd2() => Seq(1, 2, 3, 4, 5, 6, 7, 8, 9, 10).Map(IsEven).Where(x => x.IsRight).FirstOrDefault();
}