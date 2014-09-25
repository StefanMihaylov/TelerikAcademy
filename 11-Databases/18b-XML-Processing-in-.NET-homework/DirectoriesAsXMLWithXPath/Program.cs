namespace DirectoriesAsXMLWithXPath
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    class Program
    {
        // Rewrite the last exercises using XDocument, XElement and XAttribute.

        static void Main(string[] args)
        {
            var root = new DirectoryInfo(@"..\..\..\");
            XElement directories = new XElement(DirectoryWriter(root));
            directories.Save(@"..\..\..\directories2.xml");

            Console.WriteLine("New catalog created!");
           // Console.WriteLine(directories);
        }

        private static XElement DirectoryWriter(DirectoryInfo root)
        {

            XAttribute attribute = new XAttribute("name", root.Name);
            XElement currentDir = new XElement("dir", attribute);

            var directiories = root.GetDirectories();
            foreach (var dir in directiories)
            {
                currentDir.Add(DirectoryWriter(dir));
            }

            var files = root.GetFiles();
            foreach (var file in files)
            {
                XAttribute size = new XAttribute("size", file.Length.ToString());
                XElement currentFile = new XElement("file", file.Name, size);
                currentDir.Add(currentFile);
            }

            return currentDir;
        }
    }
}
