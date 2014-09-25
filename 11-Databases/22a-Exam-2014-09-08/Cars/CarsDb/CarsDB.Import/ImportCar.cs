namespace CarsDB.Import
{
    using CarsDB.Model;

    public class ImportCar
    {
        public int Year { get; set; }

        public Transmission TransmissionType { get; set; }
        public string ManufacturerName { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        public ImportDealer Dealer { get; set; }
    }
}
