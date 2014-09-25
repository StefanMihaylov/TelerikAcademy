namespace ValidateSchema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Schema;

    class Program
    {
        static void Main()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", @"..\..\..\Catalog.xsd");

            XDocument doc = XDocument.Load(@"..\..\..\Catalog.xml");
            string result = "";
            doc.Validate(schemas, (o, e) => { result = e.Message; });
            Console.WriteLine(result == "" ? "Document is valid" : "Document is invalid: " + result);

            XDocument docInvalid = XDocument.Load(@"..\..\..\Catalog_invalid.xml");
            result = "";
            docInvalid.Validate(schemas, (o, e) => { result = e.Message; });
            Console.WriteLine(result == "" ? "Document is valid" : "Document is invalid: " + result);
        }
    }
}
