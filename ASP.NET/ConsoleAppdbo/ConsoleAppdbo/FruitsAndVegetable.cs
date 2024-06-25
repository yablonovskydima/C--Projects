using System;
using System.Collections.Generic;

namespace ConsoleAppdbo;

public partial class FruitsAndVegetable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int Calories { get; set; }
    public override string ToString()
    {
        return $"{Id}\t{Name}\t{Type}\t{Color}\t{Calories}";
    }
}
