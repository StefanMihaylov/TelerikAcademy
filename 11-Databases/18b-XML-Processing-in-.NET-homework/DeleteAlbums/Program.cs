namespace DeleteAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class Program
    {
        // Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\Catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            Console.WriteLine("\t Catalog before delete:");
            Print(rootNode);


            XmlDocument newDoc = new XmlDocument();
            XmlNode newRootNode = newDoc.CreateElement("catalog");
            newDoc.AppendChild(newRootNode);
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var price = decimal.Parse(node["price"].InnerText);
                if (price <= 30m)
                {
                    XmlNode newNode = newDoc.ImportNode(node, true);
                    newRootNode.AppendChild(newNode);
                }
            }

            Console.WriteLine("\n\t Catalog after album deleting:");
            Print(newRootNode);
            newDoc.Save(@"..\..\..\NewCatalog.xml");
        }

        private static void Print(XmlNode rootNode)
        {
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var artist = node["artist"].InnerText;
                var album = node["Name"].InnerText;
                var price = decimal.Parse(node["price"].InnerText);
                Console.WriteLine("\t Artist \"{0}\" - Album \"{1}\": {2:c}", artist, album, price);
            }
        }
    }
}
