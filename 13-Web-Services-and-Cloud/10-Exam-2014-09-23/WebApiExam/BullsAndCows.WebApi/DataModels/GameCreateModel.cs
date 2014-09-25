namespace BullsAndCows.WebApi.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class GameCreateModel
    {
        public string Name { get; set; }

        [Range(1000,9999)]
        public int Number { get; set; }
    }
}