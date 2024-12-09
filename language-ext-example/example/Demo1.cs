namespace language_ext_example.example;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Security.Cryptography;
using language_ext_example.example.api.Env;
using language_ext_example.example.api.Env.Interface;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pretty;
using Microsoft.VisualBasic;
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
    public static Reader<Func<int, int>, int> GetReader(int a) => Reader<Func<int, int>, int>(f => f(a));

    public static State<int, int> GetState => State<int, int>(f => (f + 1, f));

    public static State<Func<int, int>, int> GetState0(int a) =>
    State<Func<int, int>, int>(f => (f(a), (int x) => f(a) + x));

    public static State<Stck<int>, Stck<int>> PutStack(int a) =>
    State<Stck<int>, Stck<int>>(f => (f.Push(a), f));

    // (1,(int x)=>1+x) -> (2,(int x)=>2+x) => (4,(int x)=>4+x) => (8,(int x)=>8+x)

    public static Lens<int, int> GetLens => Lens<int, int>.New(x => x + 1, y => x => y - x);

    public static State<int, int> GetState2 => get(GetLens);


    public static int AddMethod(int a, int b) => a + b;


    public static void Go()
    {
        var x0 = Lens<int, int>.New(x => x, x => x => x + 1);
        var x1 = x0.Get(1);

        var x2 = GetState0(0).Bind(GetState0).Bind(GetState0).Run((int x) => x + 1).Value.ToOption();
        var x3 = PutStack(1).Bind(s => put(s).Bind(_ => PutStack(3))).Run(Stck<int>.Empty).Value.ToOption();


        //var x = Lens.fst<int, int>();
        // var y = x.Get((9, 2));
        // var z = x.Set(2, (9, 2));

        //var t = x.Update(x => x + 1);

        var t1 = new TestData("Tom", 30);
        var t2 = new TestData("Aom", 30);

        var t3 = t1 > t2;

        //var n = Lens.fst<int, int>;





        var s1 = GetState.Run(10).Value;



        var fff = pipe((1, 2), t => AddMethod(t.Item1, t.Item2));
        // 解構 data1





        var g1 = GetEnvValue().ToEither(default(TestEnvStruct));

        var g2 = GetReader(10).ToEither((int x) => x + 1);


        g1.Match(
         Right: Console.WriteLine,
         Left: e => Console.WriteLine(e.Message)
        );

        g2.Match(
         Right: Console.WriteLine,
         Left: e => Console.WriteLine(e.Message)
        );


    }









}