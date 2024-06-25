namespace CodeFirst.Models;

public class Student 
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person person { get; set; }

    public int SchoolId { get; set; }
    public School school { get; set; }
}