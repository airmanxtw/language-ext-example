namespace language_ext_example.example;
public struct BirdsExample
{
    public static Func<int, int> IF(Func<int, bool> COND, Func<int, int> THEN, Func<int, int> ELSE) =>
        (int v) => COND(v) ? THEN(v) : ELSE(v);

    public static bool ISMORETHENZERO(int a) => a >= 0;
    public static int IdiotBird(int a) => a;


    public static Func<Func<int, int>, Func<int, int>> Mockingbird =>
    (Func<int, int> f) => (int x) => f(f(x));

    public static int ABS(int a) => IF(x => x >= 0, x => x, x => -x).Invoke(a);

    public static int ABSBirds(int a) =>
    IF(COND: ISMORETHENZERO, THEN: IdiotBird, ELSE: Mockingbird(x => -x)).Invoke(a);

}