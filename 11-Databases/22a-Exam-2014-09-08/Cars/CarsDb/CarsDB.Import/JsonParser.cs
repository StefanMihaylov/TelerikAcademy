namespace CarsDB.Import
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;

    using CarsDB.Data;
    using CarsDB.Model;

    public class JsonParser
    {
        private CarsDbContext database;
        private ILogger logger;
        private string path;

        public JsonParser(CarsDbContext database, ILogger logger, string path)
        {
            this.database = database;
            this.logger = logger;
            this.path = path;
        }

        public void Convert(string fileName)
        {
            this.logger.LogLine("Inserting File \"{0}\"", fileName);
            this.database.Configuration.AutoDetectChangesEnabled = false;

            string json = this.ReadFile(this.path + fileName);
            var deserializedCars = JsonConvert.DeserializeObject<ICollection<ImportCar>>(json);

            var citiesInMemory = new HashSet<City>();
            var manufacturersInMemory = new HashSet<Manufacturer>();

            int index = 0;
            foreach (var car in deserializedCars)
            {
                var currentCar = new Car();
                currentCar.Model = car.Model;
                currentCar.Price = car.Price;
                currentCar.Year = car.Year;
                currentCar.TransmitionType = car.TransmissionType;

                string manufacturerName = car.ManufacturerName;
                var manufactureInDb = this.database.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);
                var manufactureInMemory = manufacturersInMemory.FirstOrDefault(m => m.Name == manufacturerName);
                if (manufactureInDb == null && manufactureInMemory == null)
                {
                    manufactureInDb = new Manufacturer()
                    {
                        Name = manufacturerName
                    };
                    manufacturersInMemory.Add(manufactureInDb);
                    currentCar.Manufacturer = manufactureInDb;
                }
                else
                {
                    if (manufactureInDb != null)
                    {
                        currentCar.ManufacturerId = manufactureInDb.ManufacturerId;
                    }

                    if (manufactureInMemory != null)
                    {
                        currentCar.Manufacturer = manufactureInMemory;
                    }
                }

                var dealer = new Dealer();
                dealer.Name = car.Dealer.Name;

                string cityName = car.Dealer.City;
                var cityInDb = this.database.Cities.FirstOrDefault(s => s.Name == cityName);
                var cityInMemory = citiesInMemory.FirstOrDefault(s => s.Name == cityName);

                if (cityInDb == null && cityInMemory == null)
                {
                    cityInDb = new City()
                    {
                        Name = cityName
                    };
                    citiesInMemory.Add(cityInDb);
                    dealer.Cities.Add(cityInDb);
                }
                else
                {
                    if (cityInDb != null)
                    {
                        dealer.Cities.Add(cityInDb);
                    }

                    if (cityInMemory != null)
                    {
                        dealer.Cities.Add(cityInMemory);
                    }
                }

                currentCar.Dealer = dealer;
                this.database.Cars.Add(currentCar);

                SaveBatch(index);
                index++;
            }

            this.database.SaveChanges();
            this.logger.LogLine("\nFile \"{0}\" inserted", fileName);

            this.database.Configuration.AutoDetectChangesEnabled = true;
        }


        private string ReadFile(string path)
        {
            try
            {
                using (var reader = new StreamReader(path))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could not read the file {0}", path);
            }

            return null;
        }

        public void SaveBatch(int index, int batch = 100)
        {
            if (index % batch == 0)
            {
                this.logger.Log(".");
                this.database.SaveChanges();
            }
        }
    }
}
