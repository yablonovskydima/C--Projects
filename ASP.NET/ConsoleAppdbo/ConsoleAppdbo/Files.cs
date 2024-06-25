using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppdbo
{
    public class Files
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string? ImageData { get; set; }

        public override string ToString()
        {
            return $"{Id.ToString()}\t{Title}\t{FileName}\t{ImageData}" ;
        }
    }
}
