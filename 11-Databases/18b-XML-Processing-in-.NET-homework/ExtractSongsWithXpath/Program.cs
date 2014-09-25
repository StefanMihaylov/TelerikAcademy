namespace ExtractSongsWithXpath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    class Program
    {
        // Rewrite the same using XDocument and LINQ query.

        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load(@"..\..\..\Catalog.xml");
            string xPathQuery = "/catalog/album/songs/song/title";

            var songList = xmlDoc.Descendants("song").Elements("title");

            Console.WriteLine("\t Songs:");
            foreach (var song in songList)
            {
                Console.WriteLine("\t {0}", song.Value);
            }
        }
    }
}
