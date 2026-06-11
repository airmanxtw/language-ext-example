using System.Reflection;
using language_ext_example.example.api.Env;
using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using static LanguageExt.Prelude;

namespace language_ext_example.example;



public class Reader
{
    /// <summary>
    /// Runs the Reader monad and memoizes the result in a TryOption monad.
    /// </summary>
    /// <returns></returns>
    public static Reader<TestEnvStruct, string> GetEnvValue() => Reader<TestEnvStruct, string>(e => e.GetValue());

    public static Reader<Func<int, int>, int> GetReader(int a) => Reader<Func<int, int>, int>(f => f(a));




    public static Reader<double,double> GetArea(double r) => Reader<double, double>(pi => pi * r * r);

    public static double GetAreaWithPi(double r)
    {        
        var r2 = GetArea(r).Run(10d).ToOption().Value();
        
        return r2;
    }
    


}
