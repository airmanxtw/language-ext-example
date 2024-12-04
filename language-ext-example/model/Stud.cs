namespace language_ext_example.model
{
    public class Stud
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; }
    }

    public record Teacher(string Name, int Age);
}