using System;
using System.Xml.Serialization;

[XmlInclude(typeof(Circle))]
[XmlInclude(typeof(Rectangle))]
public class Shape
{
    // create a list of Shapes to serialize 
    public string Colour { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Area { get; set; }
    public Shape() { }

}

[Serializable]
public class Circle : Shape
{
    public double Radius { get; set; }
    public double Area
    {
        get
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

}

[XmlInclude(typeof(Shape))]
[Serializable]
public class Rectangle : Shape
{
    public double Area
    {
        get
        {
            return Width * Height;
        }
    }
}






