namespace language_ext_example.example;

using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pretty;
using LanguageExt.SomeHelp;
using static LanguageExt.Prelude;

public class Demo20240717
{
    public static Either<int, int> Undivisible(int m, int n)
    => m % n == 0 ? Left<int, int>(n) : Right<int, int>(n);

    public static bool Prime(int n) =>
    Range(2, n - 2).Map(v => Undivisible(n, v)).Sequence().IsRight;



    public static List<int> Factor(int n) =>
    Range(1, n).Map(v => Undivisible(n, v)).Partition()
    .Map((l, r) => l).ToList();


}