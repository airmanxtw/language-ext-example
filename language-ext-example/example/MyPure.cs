using System.Diagnostics.Contracts;

namespace language_ext_example.example;
public readonly struct MyPure
{
    public static readonly MyPure Inst =default;


    //private readonly int B=10;
    [Pure]
    public int Add(int a, int b) => a + b;

}