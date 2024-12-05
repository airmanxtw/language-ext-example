using LanguageExt;
using static LanguageExt.Prelude;
namespace language_ext_example.example;
public class TupleMap
{
    public static int AddMethod(int x, int y) => x + y;
    public static int Add_1(Tuple<int, int> t) => t.Map(AddMethod);

    public static int Add_2(Tuple<int, int> t) => map(t, AddMethod);



}