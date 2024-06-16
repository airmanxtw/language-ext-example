namespace language_ext_example.example;
using LanguageExt;
using LanguageExt.Common;
using LanguageExt.Pretty;
using static LanguageExt.Prelude;

public class ListMap
{
    // Math.SequareValue 是一個 Option monad 函數，將傳入的數字平方後回傳
    // 以這例子來說，最後會回傳 [Some(1), Some(4), Some(9), Some(16), Some(25), Some(36), Some(49), Some(64), Some(81), Some(100)]
    public static IEnumerable<Option<int>> ListToSquareValueA() => Range(1, 10).Map(Math.SquareValue);

    // 加個 Sequence() 把原本的 IEnumerable<Option<int>> 轉換成 Option<IEnumerable<int>>
    public static Option<IEnumerable<int>> ListToSquareValueB() => Range(1, 10).Map(Math.SquareValue).Sequence();


}