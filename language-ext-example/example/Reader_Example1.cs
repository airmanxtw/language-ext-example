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

    // 第一種用法：直接在Reader裡面使用env的Add和Subtract方法
    public static Reader<Env,int> GetValueReader1(int a,int b) => Reader<Env, int>(env => env.Add(a,b) + env.Subtract(a,b));

    // 第二種用法：先從Reader裡面取出env的Add和Subtract方法，然後再使用它們
    public static Reader<Env,int> GetValueReader2(int a,int b) => 
    from add in Reader<Env, Func<int,int,int>>(env => env.Add)
    from subtract in Reader<Env, Func<int,int,int>>(env => env.Subtract)
    select add(a,b) + subtract(a,b);

    // 第三種用法：先從Reader裡面取出env的Add方法，然後再使用它來計算addResult，接著再從Reader裡面取出env的Subtract方法，最後將addResult和subtractResult相加
    public static Reader<Env,int> GetValueReader3(int a,int b) =>
    Reader<Env,int>(env => env.Add(a,b)).Bind(addResult =>         
        Reader<Env,int>(env => env.Subtract(a,b))
        .Map(subtractResult => addResult + subtractResult)
    );


    // ***使用*** 這裡會將實際的Add和Subtract方法傳入Reader裡面，然後再從Reader裡面取出結果
    public static int GetValue1(int a,int b) => 
        GetValueReader1(a,b).Run(new Env{Add = Add, Subtract = Subtract}).ToOption().Value();
    public static int GetValue2(int a,int b) => 
        GetValueReader2(a,b).Run(new Env{Add = Add, Subtract = Subtract}).ToOption().Value();

    public static int GetValue3(int a,int b) =>
        GetValueReader3(a,b).Run(new Env{Add = Add, Subtract = Subtract}).ToOption().Value();


}
