namespace CodeFirst.Models;

public class Person 
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default;
    public int LastName { get; set; } = default;
    public DateTime BirthDate { get; set; } = default;
    public int PassportNum { get; set; } = default;

    public int StudentId { get; set; }
    public Student student { get; set; }

}