using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CreateAlbumsCatalog
{
    class Program
    {
        // Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml, in which stores in appropriate way the names of all albums and their authors.

        static void Main()
        {
            using (XmlReader reader = XmlReader.Create(@"..\..\..\Catalog.xml"))
            {
                Encoding encoding = Encoding.GetEncoding("utf-8");
                using (var writer = new XmlTextWriter(@"..\..\..\Albums.xml", encoding))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");
                    bool nameTaken = false;
                    bool artistTaken = false;

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "Name")
                            {
                                writer.WriteStartElement("album");
                                writer.WriteElementString("name", reader.ReadElementString());
                                nameTaken = true;
                            }

                            if (reader.Name == "artist")
                            {
                                writer.WriteElementString("artist", reader.ReadElementString());
                                artistTaken = true;
                            }
                        }

                        if (nameTaken && artistTaken)
                        {
                            writer.WriteEndElement();
                            nameTaken = false;
                            artistTaken = false;
                        }
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    Console.WriteLine("New catalog created");
                }
            }
        }
    }
}
