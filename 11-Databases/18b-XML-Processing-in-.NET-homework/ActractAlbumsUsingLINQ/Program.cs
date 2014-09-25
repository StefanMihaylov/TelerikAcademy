namespace ActractAlbumsUsingLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        // Rewrite the previous using LINQ query

        static void Main()
        {
            XDocument xmlDoc = XDocument.Load(@"..\..\..\Catalog.xml");

            int limitYear = DateTime.Now.AddYears(-5).Year;
            var albums = xmlDoc.Descendants("album")
                            .Where(a => int.Parse(a.Element("year").Value) <= limitYear);

            foreach (var album in albums)
            {
                var year = album.Element("year").Value;
                var price = album.Element("price").Value;
                var albumName = album.Element("Name").Value;
                Console.WriteLine("\t {0} \"{1}\" : {2:c}", year, albumName, Decimal.Parse(price));
            }
        }
    }
}
