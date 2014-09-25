namespace ExtractAlbumPrice
{
    using System;
    using System.Xml;

    class Program
    {
        // Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier. Use XPath query

        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..\..\..\Catalog.xml");
            string xPathQuery = "/catalog/album";

            int limitYear = DateTime.Now.AddYears(-5).Year;

            XmlNodeList albums = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode album in albums)
            {
                var yearAsString = album.SelectSingleNode("year").InnerText;
                var year = int.Parse(yearAsString);
                if (year.CompareTo(limitYear) <= 0)
                {
                    var price = album.SelectSingleNode("price").InnerText;
                    var albumName = album.SelectSingleNode("Name").InnerText;
                    Console.WriteLine("\t {0} \"{1}\" : {2:c}", year, albumName, Decimal.Parse(price));
                }
            }
        }
    }
}
