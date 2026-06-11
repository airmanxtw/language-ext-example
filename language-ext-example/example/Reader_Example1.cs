using System.Reflection;
using language_ext_example.example.api.Env;
using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using static LanguageExt.Prelude;

namespace language_ext_example.example;

public class Env
{    
    public required Func<int,int,int> Add {get;set;}
    public required Func<int,int,int> Subtract {get;set;}
}

public class ReaderExample1
{
   
   public static int Add(int a,int b) => a + b;
   public static int Subtract(int a,int b) => a - b;

    public static Reader<Env,int> GetValueReader1(int a,int b) => Reader<Env, int>(env => env.Add(a,b) + env.Subtract(a,b));

    public static Reader<Env,int> GetValueReader2(int a,int b) => 
    from add in Reader<Env, Func<int,int,int>>(env => env.Add)
    from subtract in Reader<Env, Func<int,int,int>>(env => env.Subtract)
    select add(a,b) + subtract(a,b);


    // ***使用***
    public static int GetValue1(int a,int b) => 
        GetValueReader1(a,b).Run(new Env{Add = Add, Subtract = Subtract}).ToOption().Value();
    public static int GetValue2(int a,int b) => 
        GetValueReader2(a,b).Run(new Env{Add = Add, Subtract = Subtract}).ToOption().Value();


}
