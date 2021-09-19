using System;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace WorkingWithFileSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            //OutputFileSystemInfo();
            //WorkWithDrives();
            //WorkWithDirectories();
            WorkWithFiles();
        }

        static void OutputFileSystemInfo()
        {
            WriteLine("{0,-33} {1}", "Path.PathSeparator", PathSeparator);
            WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar", DirectorySeparatorChar);
            WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory()", GetCurrentDirectory());
            WriteLine("{0,-33} {1}", "Environment.CurrentDirectory", CurrentDirectory);
            WriteLine("{0,-33} {1}", "Environment.SystemDirectory", SystemDirectory);
            WriteLine("{0,-33} {1}", "Path.GetTempPath()", GetTempPath());
            WriteLine("GetFolderPath((SpecialFolder)");
            WriteLine("{0,-33} {1}", " .System", GetFolderPath(SpecialFolder.System));
            WriteLine("{0,-33} {1}", " .ApplicationData", GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0,-33} {1}", " .MyDocuments", GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0,-33} {1}", " .Personal", GetFolderPath(SpecialFolder.Personal));
        }

        static void WorkWithDrives()
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}", "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}", drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
                }
            }

        }

        static void WorkWithDirectories()
        {
            //define a directory path for a new folder startin in the users folder
            var newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "New Folder");
            WriteLine($"Working with: {newFolder}");

            //check if it esxists
            WriteLine($"Does the exist? {Exists(newFolder)}");

            //create directory
            WriteLine("Creating it ...");
            CreateDirectory(newFolder);
            WriteLine($"Does the exist? {Exists(newFolder)}");
            Write("Confirm the directory exists, and then press ENTER: ");
            ReadLine();

            //delete directory
            WriteLine("Deleting it...");
            Delete(newFolder, recursive: true);
            WriteLine($"Does the exist? {Exists(newFolder)}");
        }

        static void WorkWithFiles()
        {
            //define a directory name for the output files starting in the users personal
            var dir = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "OutputFiles");
            CreateDirectory(dir);

            //define file paths
            string textFile = Combine(dir, "Dummy.txt");
            string backupFile = Combine(dir, "Dummy.bak");
            WriteLine($"Working with: {textFile}");

            //check if a file exists
            WriteLine($"Does it exists? {File.Exists(textFile)}");

            //create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello C#");
            textWriter.Close(); //close the file and release resources
            WriteLine($"Does it exists? {File.Exists(textFile)}");

            //copy the file and overwrite if it already exists
            File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);
            WriteLine($"Does it exists? {File.Exists(backupFile)}");
            Write("Confirm the file exists and then press ENTER: ");
            ReadLine();

            //delete file
            File.Delete(textFile);
            WriteLine($"Does it exists? {File.Exists(textFile)}");

            //read from the backup file
            WriteLine($"Readings from the backup file {backupFile}: ");
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();

            //managing paths
            WriteLine($"Folder anme: {GetDirectoryName(textFile)}");
            WriteLine($"File name: {GetFileName(textFile)}");
            WriteLine($"File name without extension: {GetFileNameWithoutExtension(textFile)}");
            WriteLine($"File extension: {GetExtension(textFile)}");
            WriteLine($"Random fil name: {GetRandomFileName()}");
            WriteLine($"Temporary file name: {GetTempFileName()}");

            //FileInfo stuff
            var info = new FileInfo(backupFile);
            WriteLine($"{backupFile}:");
            WriteLine($"Conatins {info.Length} bytes");
            WriteLine($"Last accesed {info.LastAccessTime}");
            WriteLine($"Has readonly set to {info.IsReadOnly}");

        }
    }
}
