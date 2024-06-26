namespace test_language_ext_example.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using language_ext_example.example;
using LanguageExt;
using LanguageExt.UnitTesting;
using LanguageExt.ClassInstances;
using LanguageExt.UnsafeValueAccess;

[TestClass]
public class AtomTest
{
    [TestMethod]
    public void Test()
    {
        language_ext_example.model.Stud stud = new() { Name = "Ravi", Age = 20 };

        var stud2 = Atom.PlusAge2(stud);
        Assert.AreEqual(stud.Age, 21);
    }
}