namespace language_ext_example.example;

using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pretty;
using LanguageExt.SomeHelp;
using static LanguageExt.Prelude;

public class Demo20240708
{

    // 1. pipe,curry,compose,flip
    // 2. identity,constant,ignore,fun


    public static int Add(int a) => a + 1;
    public static int Dob(int a) => a * 2;

    public static double Muti(double a, int b) => a * b;

    public Func<int, double> Muti3 = curry<double, int, double>(Muti)(3.0);

    public Func<int, double> Muti4 = curry<double, int, double>(Muti)(4.0);


    #region curry and flip 補齊
    public static double Func00(int a) => pipe(a, v => Muti(2.0, a));
    public static double Func01(int a) => pipe(a, curry<double, int, double>(Muti)(2.0));

    // 同等 Muti(int b,double a)
    public static Func<int, double, double> MutiFlip => flip<double, int, double>(Muti);

    public static double Func02(double b) => pipe(b, v => MutiFlip(3, b));
    public static double Func03(double b) => pipe(b, curry(MutiFlip)(3));

    #endregion

    #region curry 補充

    public static string FindStud(string db, string studNo) => $"{db}-{studNo}";

    //* without curry function
    public static Func<string, Func<string, string>> FindStudCurry1 =>
    (string db) => (string studNo) => FindStud(db, studNo);

    //* with curry function
    public static Func<string, Func<string, string>> FindStudCurry2 =>
    curry<string, string, string>(FindStud);

    public static Func<string, string> FindStudFromDB1 =>
    (string studNo) => FindStudCurry1("DB1.SERVER")(studNo);

    public static Func<string, string> FindStudFromDB2 => (string studNo) =>
    FindStudCurry2("DB2.SERVER")(studNo);

    // Find stud from DB1
    public static string DoFindStud(string studNo) => pipe(studNo, FindStudFromDB1);

    #endregion



    /// Applies a series of functions to an input value, starting with the initial value.
    public static int MyPipe(int a, params Func<int, int>[] fs) => fs.Fold(a, (x, f) => f(x));







    public static int Func1(int a) => pipe(a, Add, Dob);

    public static Func<int, int> Func2 => compose<int, int, int, int>(x => x, Add, Dob);

    public static Func<int, int> Func3 => compose<int, int, int, int>(identity, Add, Dob);

    public static void Func4(int a) => Console.WriteLine(a);

    public static Unit Func5(int a)
    {
        Func4(a);
        return unit;
    }

    public static Unit Func6(int a) => fun<int>(Func4)(a);

    public static Unit Func7(int a) => ignore(Add);




















}