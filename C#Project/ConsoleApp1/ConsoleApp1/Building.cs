using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class Building
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public List<Flat> flats{get; set;}
        public int NumberOfEntrance { get; set; }
    }
}
