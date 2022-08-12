using System;
using static System.Console;
using System.Xml.Serialization;
using static System.IO.Path;
using static System.Environment;

var listOfShapes = new List<Shape>
{
 new Circle { Colour = "Red", Radius = 2.5 },
 new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
 new Circle { Colour = "Green", Radius = 8.0 },
 new Circle { Colour = "Purple", Radius = 12.3 },
 new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 }
};

var serializerXml = new XmlSerializer(typeof(List<Shape>));

string path = Combine(CurrentDirectory, "shapes.xml");
using (FileStream stream = File.Create(path))
{
    // serialize the object graph to the stream 
    serializerXml.Serialize(stream, listOfShapes);
}
WriteLine(File.ReadAllText(path));

using (FileStream fileXml = File.Open(path, FileMode.Open))
{
    List<Shape> loadedShapesXml =
         serializerXml.Deserialize(fileXml) as List<Shape>;
    foreach (Shape item in loadedShapesXml)
    {
        WriteLine("{0} is {1} and has an area of {2:N}",
        item.GetType().Name, item.Colour, item.Area);
    }
}