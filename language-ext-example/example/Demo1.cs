namespace language_ext_example.example;

using System.Globalization;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pretty;
using static LanguageExt.Prelude;

public class Demo1
{

    public static Option<float> Pi() => 3.14f;

    // 求平方
    public static Option<float> Square(float r) => Some(r * r);

    public static float Square2(float r) => r * r;

    public static Option<float> Square3(float r) =>
    Try(() => Square2(r))
    .Match(
        Succ: v => Some(v),
        Fail: e => None
    );

    public static int Add(int a, int b)
    {
        return a + b;
    }
    // 求面積
    public static Option<float> Area(float r) => Pi().Map(x => Square(x)).Flatten();



    public static Option<float> Area2(float r) => Pi().Bind(x => Square(x));

    public static Option<float> Area3(float r) => Pi().Map(x => Square2(x));


 

}