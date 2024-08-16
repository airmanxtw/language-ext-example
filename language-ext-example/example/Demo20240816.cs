
namespace language_ext_example.example;

using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pretty;
using LanguageExt.SomeHelp;
using static LanguageExt.Prelude;
public class Demo20240816
{
    public static int Add(int a, int b) => a + b;

    public static Option<int> GetA(int a) => Some(a);

    public static Option<int> GetB(int b) => Some(b);

    public static Option<int> GetResult1(int a, int b) =>
    GetA(a).Bind(a1 => GetB(b).Bind(b1 => Some(Add(a1, b1))));

    public static Option<int> GetResult2(int a, int b) =>
    fun((int a, int b) => Add(a, b)).Apply(GetA(a), GetB(b));

    public static Option<int> GetResult3(int a, int b) =>
    from a1 in GetA(a)
    from b1 in GetB(b)
    select Add(a1, b1);




}