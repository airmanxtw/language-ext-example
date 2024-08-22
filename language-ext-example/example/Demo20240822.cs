namespace language_ext_example.example;
public class Demo20240822
{
    public List<int> Data = [10, 11, 15, 44, 33, 22, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1];

    public static bool IsOdd(int a) => a % 2 == 1;

    public static bool IsEven(int a) => a % 2 == 0;

    public static bool IsMoreThan10(int a) => a > 10;

    public IEnumerable<int> GetOddData() => Data.Where(IsOdd).Where(IsMoreThan10);

    public IEnumerable<int> GetEvenData() => Data.Where(IsEven).Where(IsMoreThan10);



}
