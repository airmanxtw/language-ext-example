namespace language_ext_example.example;
using LanguageExt;
using LanguageExt.Common;
using LanguageExt.Pretty;
using static LanguageExt.Prelude;
public class DataSource
{
    // 模擬從資料庫來的一組數字
    public static Eff<Lst<int>> GetNumList() => Eff(() => List(1, 2, 3, 4, 5, 6, 7, 10));

    // 模擬從資料庫來的一個數字
    public static Eff<int> GetNum() => Eff(() => 5);
}
