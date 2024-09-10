using LanguageExt;
using LanguageExt.Common;
using static LanguageExt.Prelude;

namespace language_ext_example.example;
public class ValidationExm
{
    public static int GetCode(char c) =>
    HashMap(
        ('A', 10), ('B', 11), ('C', 12), ('D', 13), ('E', 14), ('F', 15), ('G', 16), ('H', 17), ('J', 18),
        ('K', 19), ('L', 20), ('M', 21), ('N', 22), ('P', 23), ('Q', 24), ('R', 25), ('S', 26), ('T', 27),
        ('U', 28), ('V', 29), ('X', 30), ('Y', 31), ('W', 32), ('Q', 33), ('I', 34), ('O', 35)
    ).Find(c).IfNone(0);

    public static Validation<Error, char> IsNum(char c) =>
    c >= 48 && c <= 57 ? Success<Error, char>(c) : Fail<Error, char>(Error.New($"這不是數字(0~9):{c}"));

    public static Validation<Error, char> IsLetter(char c) =>
    pipe(c, v => v.ToString().ToUpper().ToCharArray().First(), Cond<char>(v => v >= 'A' && v <= 'Z').Then(Success<Error, char>).Else(Fail<Error, char>(Error.New($"第一個字不是字母(A~Z):{c}"))));

    public static Validation<Error, string> IsTen(string s) =>
    pipe(s, v => v.Length, Cond<int>(v => v == 10).Then(Success<Error, string>(s)).Else(Fail<Error, string>(Error.New("長度不是10"))));

    public static Either<Seq<Error>, IEnumerable<char>> CheckID(string s) =>
    (from _ in guard(s.Length == 10, Error.New("長度不是10")).ToValidation()
     from r in List(IsLetter(s.First())).AsEnumerable().Append(s.Skip(1).Map(IsNum)).Sequence()
     select r)
     .ToEither();


    //var result=List(IsLetter(s.First()),IsNum(s.Skip(1).Take(1).First()));
}

    // public static Either<Error, string> IsID(string s)
    // {
    //     var result = guard(s.Length == 10, Error.New("長度不是10")).ToEither()
    //                 .Map(_ => IsLetter(s.First()));

    // }



}