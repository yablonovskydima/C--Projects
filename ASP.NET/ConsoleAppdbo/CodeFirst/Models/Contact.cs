namespace CodeFirst.Models;

public class Contact 
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default;
    public string LastName { get; set; } = default;
    public string Email { get; set; } = default;
    public int ProjectId { get; set; }

    public Project Project { get; set; }

}