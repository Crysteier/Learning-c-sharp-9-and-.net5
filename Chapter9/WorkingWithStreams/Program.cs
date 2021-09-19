using System;
using static System.Console;
using System.Xml;
using System.IO;
using static System.IO.Path;
using static System.Environment;
using System.IO.Compression;

namespace WorkingWithStreams
{
    class Program
    {
        //Viper pilot call signs    
        static string[] callsings = new string[]{
        "Husker","Starbuck","Apollo","Boomer",
        "Bulldog","Athena","Helo","Racetrack"
            };
        static void Main(string[] args)
        {
            //WorkWithText();
            WorkWithXml();
            WorkWithCompression();
            WorkWithCompression(useBrotli: false);
        }

        static void WorkWithText()
        {
            //define a file to write to
            string textFile = Combine(CurrentDirectory, "streams.txt");

            //create a text file and return a helper writer
            StreamWriter text = File.CreateText(textFile);

            //enumerate the strings, writing each one to the stream on a seperate line
            foreach (var item in callsings)
            {
                text.WriteLine(item);
            }
            text.Close();
            WriteLine($"{textFile} cointains {new FileInfo(textFile).Length} bytes");
            WriteLine(File.ReadAllText(textFile));
        }

        static void WorkWithXml()
        {
            FileStream xmlFileStream = null;
            XmlWriter xml = null;

            try
            {
                //define a file to write to
                string xmlFile = Combine(CurrentDirectory, "streams.xml");
                //create a file stream
                xmlFileStream = File.Create(xmlFile);

                //wrap the file stream in a xml writer helper and automatically indent nested elements
                xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

                //write the xml declaration
                xml.WriteStartDocument();

                //write a root element
                xml.WriteStartElement("callsigns");

                //enumerate the strings writing each one to the stream
                foreach (var item in callsings)
                {
                    xml.WriteElementString("callsigns", item);
                }
                //write the close root element
                xml.WriteEndElement();

                ///clore helper and stream
                xml.Close();
                xmlFileStream.Close();

                //output alll the contents of the file
                WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length} bytes");
                WriteLine(File.ReadAllText(xmlFile));
            }
            catch (Exception ex)
            {
                //if the path doesnt exist the etion will be caught
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    WriteLine("The XML writers unmanage dresources have been disposed");
                }
                if (xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    WriteLine("The file streams unmanaged resources have been disposed");
                }
            }
        }

        static void WorkWithCompression(bool useBrotli = true)
        {
            string fileExt = useBrotli ? "brotli" : "gzip";

            string filePath = Combine(CurrentDirectory, $"streams.{fileExt}");

            FileStream file = File.Create(filePath);

            Stream compressor;
            if (useBrotli)
            {
                compressor = new BrotliStream(file, CompressionMode.Compress);
            }
            else
            {
                compressor = new GZipStream(file, CompressionMode.Compress);
            }

            using (compressor)
            {
                using (XmlWriter xml = XmlWriter.Create(compressor))
                {
                    xml.WriteStartDocument();
                    xml.WriteStartElement("callsigns");
                    foreach (var item in callsings)
                    {
                        xml.WriteElementString("callsign", item);
                    }

                    //the normal call to WriteEndElement is not necessary
                    //bacause when the XmlWriter disposes, it will 
                    //automatically end any elements of any depth
                }
            }//also closes the underlying stream

            //output all the contents of the compressed file
            WriteLine($"{filePath} contains: {new FileInfo(filePath).Length}");
            WriteLine("The compressed contents: ");
            WriteLine(File.ReadAllText(filePath));

            //read compressed files
            WriteLine("Reading the compressed XML file:");
            file = File.Open(filePath, FileMode.Open);

            Stream decompressor;
            if (useBrotli)
            {
                decompressor = new BrotliStream(file, CompressionMode.Decompress);
            }
            else
            {
                decompressor = new GZipStream(file, CompressionMode.Decompress);
            }

            using (decompressor)
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read()) //read the next XML node
                    {
                        //check if we are on an element node named callsign
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                        {
                            reader.Read();//move to the text inside elemnt
                            WriteLine($"{reader.Value}");
                        }
                    }
                }
            }
        }
    }
}
