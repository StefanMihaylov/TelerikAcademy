namespace CreateXML
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    class Program
    {
        // In a text file we are given the name, address and phone number of given person (each at a single line). Write a program, which creates new XML document, which contains these data in structured XML format

        static void Main()
        {
            //XElement person = new XElement();

            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\..\Person.txt"))
                {
                    XElement personName = null;
                    XElement personAddress = null;
                    XElement personPhone = null;
                    string line;
                    int index = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        switch (index)
                        {
                            case 0:
                                personName = new XElement("name", line);
                                break;
                            case 1:
                                personAddress = new XElement("address", line);
                                break;
                            case 2:
                                personPhone = new XElement("phone", line);
                                break;
                            default:
                                Console.WriteLine("Invalid index");
                                break;
                        }

                        index++;
                    }

                    XElement person = new XElement("person", personName, personAddress, personPhone);
                    person.Save(@"..\..\..\Person.xml");
                    Console.WriteLine(person);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
