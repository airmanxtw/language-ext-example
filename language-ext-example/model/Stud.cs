using System.Diagnostics.Contracts;

namespace language_ext_example.model
{
    public class Stud
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; }
    }

    // 主管
    public record Chief
    {
        public string Name { get; init; } = default!;
        public int Age { get; init; }
        public Chief(string name, int age) => (Name, Age) = (name, age);
    }

    public record Teacher
    {
        public required string Name { get; init; }

        public int Age { get; init; }

        [Pure]
        public static Teacher New(string name, int age) => new() { Name = name, Age = age };

    }
}