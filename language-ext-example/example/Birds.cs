using System.Security.Cryptography.X509Certificates;
using LanguageExt;
using static LanguageExt.Prelude;



namespace language_ext_example.example;
public class Birds
{
    public static int SimPipe(int a, Func<int, int> f) => f(a);

    public static int SimPipe(int a, Func<int, int> f1, Func<int, int> f2) => f2(f1(a));

    public static int SimPipe(int a, Func<int, int> f1, Func<int, int> f2, Func<int, int> f3) => f3(f2(f1(a)));

    public static int SimPipe2(int a, Func<int, int> f1) => Combinators<int, int>.T(a)(f1);

    public static Func<int, int> IF(Func<int, bool> COND, Func<int, int> THEN, Func<int, int> ELSE) =>
        (int v) => COND(v) ? THEN(v) : ELSE(v);

    public static bool ISMORETHENZERO(int a) => a >= 0;
    public static int IdiotBird(int a) => a;

    public static Func<Func<int, int>, Func<int, int>> Mockingbird =
    (Func<int, int> f) => (int x) => f(f(x));



    // 絕對值
    public static int ABS(int a) => IF(x => x >= 0, x => x, x => -x).Invoke(a);

    public static int ABSBirds(int a) => IF(ISMORETHENZERO, IdiotBird, Mockingbird(x => -x)).Invoke(a);

    public static Func<int, int> Fix(Func<Func<int, int>, Func<int, int>> f) => x => f(Fix(f))(x);
    public static Func<int, int> FixY => Combinators<int, int, int>.Y((f, x) => x <= 1 ? 1 : x * f(x - 1));

    public static Func<int, int, int> Fix(Func<Func<int, int, int>, Func<int, int, int>> f) => (x, y) => f(Fix(f))(x, y);

    



    public static void Test(int a, Func<int, int> f1, Func<int, int> f2)
    {
        var resultI = Combinators<int>.I(1);
        var resultM = Combinators<int>.M((int x) => x);

        var resultMI = Combinators<int>.M(Combinators<int>.I)(5);

        var resultMM = Combinators<int>.M(Combinators<int>.M((int x) => x + 1));

        var resultK = Combinators<bool, bool>.K(true)(false);

        var resultIK = Prelude.pipe(Combinators<int>.I(1), Combinators<int, int>.K(2));

        var resultFix = Fix(f => x => x <= 1 ? 1 : x * f(x - 1))(3);





    }

}