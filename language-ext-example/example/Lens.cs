using language_ext_example.model;
using LanguageExt;

namespace language_ext_example.example;
public class Lens
{
    public Lens<Teacher, string> TeacherNameLens = Lens<Teacher, string>.New(
        t => t.Name,
        n => t => t with { Name = n }
    );
}