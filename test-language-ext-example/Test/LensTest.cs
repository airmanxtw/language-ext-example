namespace test_language_ext_example.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;
using LanguageExt.ClassInstances;
using LanguageExt.UnsafeValueAccess;
using language_ext_example.model;
using static LanguageExt.Prelude;

[TestClass]

public class LensTest
{

    public void Test0()
    {
        var chief = new Chief("John", 30);

        var teacher = Teacher.New("John", 30);

        var TeacherTom = teacher with { Name = "Tom" };



        var result = pipe(Teacher.New("John", 30), t => t.Name);
        Assert.AreEqual("John", result);
    }

    public void Test1()
    {

    }

    [TestMethod]
    public void TestGetLens()
    {
        var teacher = Teacher.New("John", 30);
        var lens = new language_ext_example.example.Lens();
        var result = lens.TeacherNameLens.Get(teacher);
        Assert.AreEqual("John", result);
    }

    [TestMethod]
    public void TestSetLens()
    {
        var teacher = Teacher.New("John", 30);
        var lens = new language_ext_example.example.Lens();


        var result = lens.TeacherNameLens.Set("Tom", teacher);



        Assert.AreEqual("Tom", result.Name);
    }
}