namespace language_ext_example.example;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Globalization;
using language_ext_example.example.api.Env;
using language_ext_example.example.api.Env.Interface;
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

    public int GetTen() => 10;
    public int GetStrLen(string str) => str.Length;

    public void PrintStr(string str) => System.Console.WriteLine(str);

    public void PrintAdd(int a, int b) => System.Console.WriteLine(a + b);

    public void Print(int a, int b, Func<int, int, int> f) => f(a, b);



    public double CircleArea(double r) => 3.14159 * System.Math.Pow(r, 2);
    public static double Multiplication(double a, double b, double c) => a * b * c;


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


    public static Reader<ITestEnv, string> GetEnvValue() => Reader<ITestEnv, string>(e => e.GetValue());

    public static void Go()
    {
        var t1 = new TestData("Tom", 30);
        var t2 = new TestData("Aom", 30);

        var t3 = t1 > t2;
       


        var g1 = GetEnvValue().ToEither(default(TestEnvStruct));


        g1.Match(
         Right: Console.WriteLine,
         Left: e => Console.WriteLine(e.Message)
        );

        g1.Match(
         Right: Console.WriteLine,
         Left: e => Console.WriteLine(e.Message)
        );


    }









}