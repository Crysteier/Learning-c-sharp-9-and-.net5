using System.IO.Compression;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.Threading.Tasks;

namespace WorkingWithSerialization
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var people = new List<Person>{
                new Person(3000M){FirstName="Alice",LastName="Smith",DateOfBirth=new DateTime(1972, 5, 5)},
                new Person(40000M){FirstName="Bob",LastName="Jones",DateOfBirth=new DateTime(1950,4,4)},
                new Person(20000M){FirstName="Charlie",LastName="Cox",DateOfBirth=new DateTime(1998,8,8),Children=new HashSet<Person>{new Person(0M){FirstName="Sallu",LastName="Cox",DateOfBirth=new DateTime(2012,7,12)}}}
            };

            var xs = new XmlSerializer(typeof(List<Person>));
            string path = Combine(CurrentDirectory, "people.xml");

            using (FileStream stream = File.Create(path))
            {
                //serialize the object graph to the stream
                xs.Serialize(stream, people);
            }

            WriteLine("Written {0:N0} bytes of XML to {1}", arg0: new FileInfo(path).Length, arg1: path);
            WriteLine();

            //display the serialized object path
            WriteLine(File.ReadAllText(path));

            WriteLine();

            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {

                //deserialize and cast the object graph into a List of Person
                var loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);

                foreach (var item in loadedPeople)
                {
                    WriteLine("{0} has {1} children", item.LastName, item.Children.Count);
                }
            }

            ///////////////////////////////////////////////////
            string jsonPath = Combine(CurrentDirectory, "people.json");
            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                //create object that will format as json
                var jss = new Newtonsoft.Json.JsonSerializer();

                //serialize the object graph into a string
                jss.Serialize(jsonStream, people);
            }
            WriteLine();
            WriteLine("Written {0:N0} bytes of JSON to {1}", arg0: new FileInfo(jsonPath).Length, arg1: jsonPath);

            //using NuJson = System.Text.Json.JsonSerializer;
            //I am not doing the last task, discovering the new JSON is easy
        }
    }
}
