namespace CodeFirst.Models;

public class School
{
    public int Id { get; set; }
    public string Name { get; set; } = default;
    public string Description { get; set; } = default;
    public List<Student> students { get; set; }
}