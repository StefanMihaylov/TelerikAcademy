namespace ConvertXML2HTML
{
    using System.Xml.Xsl;

    class Program
    {
        // Create an XSL stylesheet, which transforms the file catalog.xml into HTML document, formatted for viewing in a standard Web-browser.
        // Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml using the class XslTransform

        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(@"..\..\..\Catalog.xslt");
            xslt.Transform(@"..\..\..\Catalog.xml", @"..\..\..\Catalog.html");
            System.Console.WriteLine("html file generated");
        }
    }
}
