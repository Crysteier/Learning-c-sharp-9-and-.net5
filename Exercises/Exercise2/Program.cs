using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
using static System.Console;
using System.IO;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfShapes = new List<Shape>{
               //new Circle{Color="Red",Radius=2.5},
               new Rectangle{Color="Blue",Width=10.0,Height=20.0},
              // new Circle{Color="Green",Radius=8.0},
             //  new Circle{Color="Purple",Radius=12.3},
               new Rectangle{Color="Blue",Width=18.0,Height=45.0}
           };
            var xs = new XmlSerializer(typeof(List<Shape>));
            string path = Combine(CurrentDirectory, "shapes.xml");

            using(FileStream fs = File.Create(path))
            {

                xs.Serialize(fs, listOfShapes);

            }
            WriteLine("Written {0:N0} bytes of XML to {1}", arg0: new FileInfo(path).Length, arg1: path);
            WriteLine();
            WriteLine(listOfShapes[0]);
        }
    }


}
