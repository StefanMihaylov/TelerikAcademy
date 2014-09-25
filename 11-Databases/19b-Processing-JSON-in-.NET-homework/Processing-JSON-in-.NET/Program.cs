namespace Processing_JSON_in_.NET
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    class Program
    {
        // Using JSON.NET and the Telerik Academy Forums RSS feed implement the following:
        //  - The RSS feed is at http://forums.academy.telerik.com/feed/qa.rss 
        //  - Download the content of the feed programmatically. You can use WebClient.DownloadFile()
        //  - Parse the XML from the feed to JSON
        //  - Using LINQ-to-JSON select all the question titles and print them to the console
        //  - Parse the JSON string to POCO
        //  - Using the parsed objects create a HTML page that lists all questions from the RSS their categories and a link to the question's page

        static void Main(string[] args)
        {
            Uri address = new Uri("http://forums.academy.telerik.com/feed/qa.rss");
            string xmlFilePath = @"..\..\rss.xml";

            var webClient = new WebClient();
            webClient.DownloadFile(address, xmlFilePath);

            var xmlDoc = XDocument.Load(xmlFilePath);
            string jsonFromXml = JsonConvert.SerializeXNode(xmlDoc, Formatting.Indented);
            // File.WriteAllText(@"..\..\rss.json", jsonFromXml);

            var jsonObj = JObject.Parse(jsonFromXml);

            string pageTitle = (string)jsonObj["rss"]["channel"]["title"];
            Console.WriteLine(pageTitle);
            Console.WriteLine(new string('-', 50));

            var posts = jsonObj["rss"]["channel"]["item"];            
            foreach (var postTitle in posts.Select(i => i["title"]))
            {
                Console.WriteLine("\t {0}", postTitle);
            }

           
            CreateHtmlFile(posts, pageTitle);
        }

        public static void CreateHtmlFile(JToken data, string pageTitle)
        {
            var postCollection = JsonConvert.DeserializeObject<List<Post>>(data.ToString());

            StringBuilder result = new StringBuilder();
            string startHtml = @"<!DOCTYPE html> <html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <meta charset=""utf-8"" />
    <title>{0}</title>
</head>
<body>
<h2>{0}</h2>";

            string endHtml = @"</body>
</html>";

            string liElement = @"<li><span>{2}</span> : <a href=""{0}"">{1}</a></li>";

            result.AppendLine(string.Format(startHtml, pageTitle));
            result.AppendLine("<ul>");


            foreach (var post in postCollection)
            {
                result.AppendLine(string.Format(liElement, post.Link, post.Title, post.Category));
            }
            result.AppendLine("</ul>");
            result.AppendLine(endHtml);

            string filePath = @"..\..\index.html";
            File.WriteAllText(filePath, result.ToString());

            Process proc = new Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = filePath;
            proc.Start();
        }
    }
}