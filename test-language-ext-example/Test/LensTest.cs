namespace test_language_ext_example.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;
using LanguageExt.ClassInstances;
using LanguageExt.UnsafeValueAccess;
using language_ext_example.model;

[TestClass]

public class LensTest
{
    [TestMethod]
    public void TestGetLens()
    {
        var teacher = new Teacher("John", 30);
        var lens = new language_ext_example.example.Lens();
        var result = lens.TeacherNameLens.Get(teacher);
        Assert.AreEqual("John", result);
    }

    [TestMethod]
    public void TestSetLens()
    {
        var teacher = new Teacher("John", 30);
        var lens = new language_ext_example.example.Lens();
        var result = lens.TeacherNameLens.Set("Tom", teacher);
        Assert.AreEqual("Tom", result.Name);
    }
}