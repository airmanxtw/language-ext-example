namespace language_ext_example.example;
using LanguageExt;
using LanguageExt.Common;
using LanguageExt.Pretty;
using static LanguageExt.Prelude;
using language_ext_example.model;

public class Atom
{


    public static model.Stud PlusAge1(model.Stud stud)
    {
        stud.Age += 1;
        return stud;
    }


    // !!!! 這個方法是錯誤的
    public static model.Stud PlusAge2(model.Stud stud)
    {
        var StudAtom = Atom(stud);
        StudAtom.Swap(s =>
        {
            s.Age += 1;
            return s;
        });

        return StudAtom.Value;
    }

    




}