namespace language_ext_example.example;

using System.Globalization;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pretty;
using static LanguageExt.Prelude;

public class List
{
    // 資料來源
    public static Lst<int> DataSource() =>
    Range(1, 10).Fold(Lst<int>.Empty, (acc, x) => acc.Add(x));

    // * 將兩個Option<int>相加
    private static Option<int> Add(Option<int> a, Option<int> b) =>
    List(a, b)
    .Sequence()
    .Map(x => x.First() + x.Last());

    // * 依位置將數字加總
    public static Option<int> Sum(Lst<int> n, params int[] i) =>
    i.Fold(
        Option<int>.Some(0),
        (acc, x) => acc.Bind(v => Add(n.At(x), Some(v)))
    );

    public static Func<int[], Option<int>> Sum(Lst<int> d) => curry<Lst<int>, int[], Option<int>>(Sum)(d);

    // List.Case 用例
    public static string CaseExample() =>
    List(1, 2, 3, 4, 5).Case switch
    {
        1 => "1",
        (int h, Seq<int> t) => $"{h} {t}",
        _ => "empty"
    };



}