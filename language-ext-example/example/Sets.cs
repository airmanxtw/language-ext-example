namespace language_ext_example.example;
using LanguageExt;
using LanguageExt.Common;

using static LanguageExt.Prelude;

public record Stud(string StudNo, int Score);

public class Sets
{
    readonly List<Stud> studsA = [
        new Stud("001",100),
        new Stud("002",90),
        new Stud("003",80),
        new Stud("004",70),
        new Stud("005",60),
        new Stud("006",50),
        new Stud("007",40),
        new Stud("008",30),
        new Stud("009",20),
        new Stud("010",10)
    ];

    // score readomly
    readonly List<Stud> studsB = [
        new Stud("001",90),
        new Stud("002",80),
        new Stud("003",70),
        new Stud("008",20),
        new Stud("009",10),
        new Stud("010",100),
        new Stud("011",90),
    ];

    // * 取得兩個 List<Stud> 的交集
    public static List<Stud> GetIntersect(List<Stud> lstA, List<Stud> lstB) =>
        lstA.IntersectBy(lstB.Select(b => b.StudNo), s => s.StudNo).ToList();

    // * 取得兩個 List<Stud> 的差集
    public static List<Stud> GetExcept(List<Stud> lstA, List<Stud> lstB) =>
        lstA.ExceptBy(lstB.Select(b => b.StudNo), s => s.StudNo).ToList();

    // * 取得兩個 List<Stud> 的聯集
    public static List<Stud> GetUnion(List<Stud> lstA, List<Stud> lstB) =>
        lstA.Union(lstB).ToList();





}