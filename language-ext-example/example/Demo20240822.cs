using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using LanguageExt.Pipes;
using LanguageExt.Pretty;

namespace language_ext_example.example;
public class Demo20240822
{
    public List<int> Data = [10, 11, 15, 44, 33, 22, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1];

    public static bool IsOdd(int a) => a % 2 == 1;

    public static bool IsEven(int a) => a % 2 == 0;

    public static bool IsMoreThan10(int a) => a > 10;

    public IEnumerable<int> GetOddData() => Data.Where(IsOdd).Where(IsMoreThan10);

    public IEnumerable<int> GetEvenData() => Data.Where(IsEven).Where(IsMoreThan10);

    public record SClass(string ClassNo, string ClassName);

    public record Student(string ClassNo, string StudentName);

    public record ClassStudent(string ClassNo, string ClassName, string StudentName);

    public static List<Student> Students() =>
    [new Student("A", "王大頭"), new Student("A", "陳小明"), new Student("B", "王姐")];

    public static List<SClass> Classes() => [new SClass("A", "一年級甲班"), new SClass("B", "二年級乙班")];


    public static IEnumerable<ClassStudent> GetClassStudents1() =>
    from c in Classes()
    join s in Students() on c.ClassNo equals s.ClassNo
    select new ClassStudent(c.ClassNo, c.ClassName, s.StudentName);

    public static IEnumerable<ClassStudent> GetClassStudents2() =>
    Classes().Join(Students(), c => c.ClassNo, s => s.ClassNo, (c, s) => new ClassStudent(c.ClassNo, c.ClassName, s.StudentName));

    public static IEnumerable<ClassStudent> GetClassStudents3() =>
    Students().Map(s => new ClassStudent(s.ClassNo, Classes().Find(c => c.ClassNo == s.ClassNo)?.ClassName ?? string.Empty, s.StudentName));

    public static IEnumerable<ClassStudent> GetClassStudents4() =>
    Students().GroupJoin(Classes(), s => s.ClassNo, c => c.ClassNo, (s, c) => new ClassStudent(s.ClassNo, c.FirstOrDefault()?.ClassName ?? string.Empty, s.StudentName));




}
