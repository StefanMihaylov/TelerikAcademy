using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AllArtistsWithXPath
{
    class Program
    {
        // Implement the previous using XPath.

        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..\..\..\Catalog.xml");
            string xPathQuery = "/catalog/album";

            XmlNodeList albumList = xmlDoc.SelectNodes(xPathQuery);

            var artistSet = new Dictionary<string, int>();
            foreach (XmlNode album in albumList)
            {
                string artistName = album.SelectSingleNode("artist").InnerText;
                if (!artistSet.ContainsKey(artistName))
                {
                    artistSet[artistName] = 0;
                }

                artistSet[artistName]++;
            }

            Console.WriteLine("\t Short Melodic Black/Death Metal Catalog:");
            Console.WriteLine("\t {0}", new string('-', 40));
            foreach (var artist in artistSet)
            {
                Console.WriteLine("\t Artist \"{0}\" : {1} albums", artist.Key, artist.Value);
            }
        }

    }
}
