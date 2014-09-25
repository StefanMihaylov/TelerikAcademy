namespace DirectoriesAsXML
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;

    class Program
    {
        // Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files. Use tags <file> and <dir> with appropriate attributes. For the generation of the XML document use the class XmlWriter.

        static void Main()
        {
            Encoding encoding = Encoding.GetEncoding("utf-8");
            using (XmlTextWriter writer = new XmlTextWriter(@"..\..\..\directories.xml", encoding))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("directories");
                var root = new DirectoryInfo(@"..\..\..\");

                DirectoryWriter(writer, root);

                writer.WriteEndDocument();
                Console.WriteLine("New catalog created");
            }

        }

        private static void DirectoryWriter(XmlTextWriter writer, DirectoryInfo root)
        {
            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", root.Name);

            var directiories = root.GetDirectories();
            foreach (var dir in directiories)
            {
                DirectoryWriter(writer, dir);
            }

            var files = root.GetFiles();
            foreach (var file in files)
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("size", file.Length.ToString());
                writer.WriteString(file.Name);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}
