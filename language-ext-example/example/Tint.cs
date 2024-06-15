namespace language_ext_example.example;

using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.Common;
using LanguageExt.Pretty;
using LanguageExt.TypeClasses;
using static LanguageExt.Prelude;

public struct Tint : Num<int>
{
    public readonly int Abs(int x)
    {
        return Abs(x);
    }

    public int Append(int x, int y)
    {
        throw new NotImplementedException();
    }

    public int Compare(int x, int y)
    {
        throw new NotImplementedException();
    }

    public Task<int> CompareAsync(int x, int y)
    {
        throw new NotImplementedException();
    }

    public int Divide(int x, int y)
    {
        throw new NotImplementedException();
    }

    public int Empty()
    {
        throw new NotImplementedException();
    }

    public bool Equals(int x, int y)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EqualsAsync(int x, int y)
    {
        throw new NotImplementedException();
    }

    public int FromDecimal(decimal x)
    {
        throw new NotImplementedException();
    }

    public int FromDouble(double x)
    {
        throw new NotImplementedException();
    }

    public int FromFloat(float x)
    {
        throw new NotImplementedException();
    }

    public int FromInteger(int x)
    {
        throw new NotImplementedException();
    }

    public int GetHashCode(int x)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetHashCodeAsync(int x)
    {
        throw new NotImplementedException();
    }

    public readonly int Negate(int x)
    {
        return x >= 0 ? -x : x;
    }

    public int Plus(int x, int y)
    {
        throw new NotImplementedException();
    }

    public int Product(int x, int y)
    {
        throw new NotImplementedException();
    }

    public int Signum(int x)
    {
        throw new NotImplementedException();
    }

    public int Subtract(int x, int y)
    {
        throw new NotImplementedException();
    }
}