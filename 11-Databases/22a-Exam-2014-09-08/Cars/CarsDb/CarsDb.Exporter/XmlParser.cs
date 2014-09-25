namespace CarsDb.Exporter
{
    using CarsDB.Data;
    using CarsDB.Import;
    using System;
    using System.Linq;
    using System.IO;
    using System.Xml.Linq;

    public class XmlParser
    {
        private CarsDbContext database;
        private ILogger logger;
        private string inputPath;
        private string outputPath;

        public XmlParser(CarsDbContext database, ILogger logger, string inputPath, string outputPath)
        {
            this.database = database;
            this.logger = logger;
            this.inputPath = inputPath;
            this.outputPath = outputPath;

            if (!Directory.Exists(this.outputPath))
            {
                Directory.CreateDirectory(this.outputPath);
            }
        }

        public void Parse(string fileName)
        {
            // var result = new XElement("search-results");

            var root = XElement.Load(this.inputPath + fileName);
            var xmlQueries = root.Elements();

            var allCars = this.database.Cars.AsQueryable();

            foreach (var xmlQuery in xmlQueries)
            {
                var currentQuery = allCars;

                var resultFileName = xmlQuery.Attribute("OutputFileName").Value;

                var orderBy = xmlQuery.Element("OrderBy").Value;

                var xmlWheres = xmlQuery.Element("WhereClauses").Elements();
                foreach (var xmlWhere in xmlWheres)
                {
                    var property = xmlWhere.Attribute("PropertyName").Value;
                    var type = xmlWhere.Attribute("Type").Value;
                    var search = xmlWhere.Value;

                    if (property == "Id")
                    {
                        int searchedId = int.Parse(search);
                        if (type == "Equals")
                        {
                            currentQuery = currentQuery.Where(c => c.CarId == searchedId);
                        }
                        else if (type == "GreaterThan")
                        {
                            currentQuery = currentQuery.Where(c => c.CarId > searchedId);
                        }
                        else if (type == "LessThan")
                        {
                            currentQuery = currentQuery.Where(c => c.CarId < searchedId);
                        }
                    }
                    else if (property == "Year")
                    {
                        int searchedYear = int.Parse(search);
                        if (type == "Equals")
                        {
                            currentQuery = currentQuery.Where(c => c.Year == searchedYear);
                        }
                        else if (type == "GreaterThan")
                        {
                            currentQuery = currentQuery.Where(c => c.Year > searchedYear);
                        }
                        else if (type == "LessThan")
                        {
                            currentQuery = currentQuery.Where(c => c.Year < searchedYear);
                        }
                    }
                    else if (property == "Price")
                    {
                        decimal searchedPrice = decimal.Parse(search);
                        if (type == "Equals")
                        {
                            currentQuery = currentQuery.Where(c => c.Price == searchedPrice);
                        }
                        else if (type == "GreaterThan")
                        {
                            currentQuery = currentQuery.Where(c => c.Price > searchedPrice);
                        }
                        else if (type == "LessThan")
                        {
                            currentQuery = currentQuery.Where(c => c.Price < searchedPrice);
                        }
                    }
                    else if (property == "Model")
                    {
                        if (type == "Equals")
                        {
                            currentQuery = currentQuery.Where(c => c.Model == search);
                        }
                        else if (type == "Contains")
                        {
                            currentQuery = currentQuery.Where(c => c.Model.Contains(search));
                        }
                    }
                    else if (property == "Manufacturer")
                    {
                        if (type == "Equals")
                        {
                            currentQuery = currentQuery.Where(c => c.Manufacturer.Name == search);
                        }
                        else if (type == "Contains")
                        {
                            currentQuery = currentQuery.Where(c => c.Manufacturer.Name.Contains(search));
                        }
                    }
                    else if (property == "Dealer")
                    {
                        if (type == "Equals")
                        {
                            currentQuery = currentQuery.Where(c => c.Dealer.Name == search);
                        }
                        else if (type == "Contains")
                        {
                            currentQuery = currentQuery.Where(c => c.Dealer.Name.Contains(search));
                        }
                    }
                    else if (property == "City")
                    {
                        if (type == "Equals")
                        {
                            currentQuery = currentQuery.Where(c => c.Dealer.Cities.Any(s => s.Name == search));
                        }
                    }
                }


                // Ordr by
                if (orderBy == "Id")
                {
                    currentQuery = currentQuery.OrderBy(c => c.CarId);
                }
                else if (orderBy == "Year")
                {
                    currentQuery = currentQuery.OrderBy(c => c.Year);
                }
                else if (orderBy == "Model")
                {
                    currentQuery = currentQuery.OrderBy(c => c.Model);
                }
                else if (orderBy == "Price")
                {
                    currentQuery = currentQuery.OrderBy(c => c.Price);
                }
                else if (orderBy == "Manufacturer")
                {
                    currentQuery = currentQuery.OrderBy(c => c.Manufacturer.Name);
                }
                else if (orderBy == "Dealer")
                {
                    currentQuery = currentQuery.OrderBy(c => c.Dealer.Name);
                }

                var resultQuery = currentQuery.Select(c => new
                {
                    Manufacturer = c.Manufacturer.Name,
                    Transmition = c.TransmitionType,
                    Model = c.Model,
                    Year = c.Year,
                    Price = c.Price,
                    Dealer = c.Dealer.Name,
                    Cities = c.Dealer.Cities.Select(s => s.Name)
                });

                XNamespace ns = "http://www.w3.org/2001/XMLSchema-instance";

                var resultXml = new XElement("Cars");               

               // resultXmlNamespace = new XName("xsd", "http://www.w3.org/2001/XMLSchema");
               // resultXml.Add(resultXmlNamespace);

                foreach (var resultCar in resultQuery)
                {
                    var xmlCar = new XElement("Car");
                    xmlCar.Add(new XAttribute("Manufacturer", resultCar.Manufacturer));
                    xmlCar.Add(new XAttribute("Model", resultCar.Model));
                    xmlCar.Add(new XAttribute("Year", resultCar.Year));
                    xmlCar.Add(new XAttribute("Price", resultCar.Price));

                    xmlCar.Add(new XElement("TransmissionType", resultCar.Transmition.ToString().ToLower()));
                    var dealer = new XElement("Dealer",new XAttribute("Name", resultCar.Dealer));
                    var cities = new XElement("Cities");
                    foreach (var city in resultCar.Cities)
                    {
                        cities.Add(new XElement("City", city));
                    }
                    dealer.Add(cities);
                    xmlCar.Add(dealer);
                    resultXml.Add(xmlCar);
                }

                resultXml.Save(this.outputPath + resultFileName);
            }
        }
    }
}
