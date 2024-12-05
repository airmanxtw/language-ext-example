using LanguageExt;
using static LanguageExt.Prelude;
namespace language_ext_example.example;
public class TupleMap
{
    public static int AddMethod(int x, int y) => x + y;
    public static int Add(Tuple<int, int> t) => t.Map(AddMethod);

}