using ConsoleApp1;
using System.Text.Json;
using System.Xml.Serialization;

List<Flat> flats = new List<Flat> { new Flat {SquareMeters = 50, Number = 2 },
    new Flat {SquareMeters = 50, Number = 25 },
    new Flat {SquareMeters = 60, Number = 12 },
    new Flat {SquareMeters = 52, Number = 1 }
};
List<Building> buildings = new List<Building>
{
    new Building {Number = 2, Name="sadasd", flats=flats, NumberOfEntrance=6 },
    new Building {Number = 3, Name="aijwpa'wd", flats=flats, NumberOfEntrance=2 },
    new Building {Number = 1, Name="asdk[pkwd", flats=flats, NumberOfEntrance=5 },
    new Building {Number = 5, Name="wodjomwa", flats=flats, NumberOfEntrance=1 },
    new Building {Number = 7, Name="xcas'dka[p", flats=flats, NumberOfEntrance=10 },
};

District district = new District { Buildings = buildings, Number = 25};

string path = "dz.xml";
XmlSerializer serializer = new XmlSerializer(typeof(District));

try
{
    using (Stream stream = File.Create(path)) 
    {
        serializer.Serialize(stream, district);
    }
}
catch (Exception ex) { }

var opt = new JsonSerializerOptions { WriteIndented = true };
string json = JsonSerializer.Serialize(district, opt);

Console.WriteLine(json);
