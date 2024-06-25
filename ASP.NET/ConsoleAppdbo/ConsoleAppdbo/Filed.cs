using System;
using System.Collections.Generic;

namespace ConsoleAppdbo;

public partial class Filed
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public byte[]? ImageData { get; set; }
}
