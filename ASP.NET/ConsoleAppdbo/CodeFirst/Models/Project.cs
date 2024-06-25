namespace CodeFirst.Models;

public class Project
{
    public int Id { get; set; }
    public int ContactId { get; set; }
    public int DeveloperId { get; set; }
    public int OptionId { get; set; }
    public string Name { get; set; } = default;
    public string Number { get; set; } = default;
    public Option Option { get; set; }

    public Contact Contact { get; set; }
    public List<Developer> developers {get; set;}

}