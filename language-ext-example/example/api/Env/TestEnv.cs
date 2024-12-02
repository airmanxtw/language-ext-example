using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using language_ext_example.example.api.Env.Interface;
using LanguageExt;
namespace language_ext_example.example.api.Env;

public class TestEnv : Record<TestEnv>
{
    public static string GetValue() => "Hello, World!";
}

public record TestEnvRecord
{
    public string Value { get; init; } = default!;
    public string GetValue() => Value;
}

public readonly struct TestEnvStruct : ITestEnv
{
    public string GetValue()
    {
        return "Hello, World!";
    }
}



// : Record<TestData>
public class TestData(string name, int age): Record<TestData>
{
    public string Name { get; init; } = name;
    public int Age { get; init; } = age;
        
}

