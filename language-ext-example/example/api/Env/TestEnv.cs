using System.Security.Cryptography.X509Certificates;
using language_ext_example.example.api.Env.Interface;
namespace language_ext_example.example.api.Env;

public class TestEnv
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
