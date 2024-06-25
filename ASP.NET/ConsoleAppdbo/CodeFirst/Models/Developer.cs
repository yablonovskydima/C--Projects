namespace CodeFirst.Models;

public class Developer 
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default;
    public string LastName {get; set; } = default;

    public int Stack { get; set; } = default;
    public int Email { get; set; } = default;

    public int ProjectId { get; set; }
    public Project Project { get; set; }
}