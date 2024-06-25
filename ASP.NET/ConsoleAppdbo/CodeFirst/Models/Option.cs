namespace CodeFirst.Models;

public class Option 
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<Project> projects { get; set; }
}