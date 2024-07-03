namespace language_ext_example.example;

using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pretty;
using LanguageExt.SomeHelp;
using static LanguageExt.Prelude;

record Tea(string Name, int Age);

public class Demo20240703
{


    public void Test()
    {

        var result = List(1, 2, 3, 4, 5).Fold(0, (acr, cur) => acr + cur);

        var Teas = List(new Tea("Black Tea", 1), new Tea("Green Tea", 2), new Tea("White Tea", 3));

        var then1=(Tea t)=>t.Age>1;
        var adder=(int acr,Tea cur) => acr + cur.Age;

        var result2 = 
        Teas
        .Where(then1)
        .Fold(0, adder);

        var Logger=(int v)=>{
            Console.WriteLine(v);
            return "ok";
            };


        var P=(int v)=>v>1 ? Some(v) : None;

        var value=(int v)=>P(v).IfNone(-1);

        var value2=Right<string,int>(1).IfLeft(c=>-1);

        var value3=Success<string,int>(1).MapFail(c=>Error.New(1,"error"));

        var value4=Some<int>(1).Do(v=>Logger(v)).Map(v=>v+1);

        


        var ChangeName = (Tea t) => Some(t)
        .Map(x => x with { Name = "Green Tea" });




        var tea = new Tea("Black Tea");




    }
}