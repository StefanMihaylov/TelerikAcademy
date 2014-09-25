namespace ExtractSongs
{
    using System;
    using System.Text;
    using System.Xml;

    class Program
    {
        // Write a program, which using XmlReader extracts all song titles from catalog.xml

        static void Main()
        {
            using (XmlReader reader = XmlReader.Create(@"..\..\..\Catalog.xml"))
            {
                Console.WriteLine("Songs:");
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
