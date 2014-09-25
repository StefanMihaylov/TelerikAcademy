namespace AllArtists
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class Program
    {
        // Write program that extracts all different artists which are found in the catalog.xml. For each author you should print the number of albums in the catalogue. Use the DOM parser and a hash-table

        public static void Main()
        {
            var artists = new Dictionary<string, int>();

            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\Catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var artistName = node["artist"].InnerText;
                if (!artists.ContainsKey(artistName))
                {
                    artists[artistName] = 0;
                }

                artists[artistName]++;
            }

            Console.WriteLine("\t Short Melodic Black/Death Metal Catalog:");
            Console.WriteLine("\t {0}", new string('-',40));
            foreach (var artist in artists)
            {
                Console.WriteLine("\t Artist \"{0}\" : {1} albums", artist.Key, artist.Value);
            }
        }
    }
}
