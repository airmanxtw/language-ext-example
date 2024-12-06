using System.Security.Cryptography.X509Certificates;
using LanguageExt;
using LanguageExt.Pipes;

namespace language_ext_example.example;
public class Birds
{
    public static int SimPipe(int a, Func<int, int> f) => f(a);

    public static int SimPipe(int a, Func<int, int> f1, Func<int, int> f2) => f2(f1(a));

    public static int SimPipe(int a, Func<int, int> f1, Func<int, int> f2, Func<int, int> f3) => f3(f2(f1(a)));

    public static int SimPipe2(int a, Func<int, int> f1) => Combinators<int, int>.T(a)(f1);

    public static void Test(int a, Func<int, int> f1, Func<int, int> f2)
    {
        var resultI = Combinators<int>.I(1);
        var resultM = Combinators<int>.M((int x) => x);

        var resultMI = Combinators<int>.M(Combinators<int>.I)(5);

        var resultMM = Combinators<int>.M(Combinators<int>.M((int x) => x + 1));

        var resultK = Combinators<bool, bool>.K(true)(false);

        var resultIK = Prelude.pipe(Combinators<int>.I(1), Combinators<int, int>.K(2));

        



    }

}