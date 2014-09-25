namespace BullsAndCows.WebApi.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class NumberModel
    {
        [Range(1000, 9999)]
        public int Number { get; set; }
    }
}