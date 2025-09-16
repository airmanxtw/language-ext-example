using language_ext_example.example.api.Env;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.UnsafeValueAccess;
using static LanguageExt.Prelude;
namespace language_ext_example.example;

public class Writer
{

    public static Writer<MSeq<string>, Seq<string>, int> Odd(int y) =>
        y % 2 == 0
        ? Writer<MSeq<string>, Seq<string>, int>(y)
        : Writer<MSeq<string>, Seq<string>, int>(y, Seq1("偶數"));


}