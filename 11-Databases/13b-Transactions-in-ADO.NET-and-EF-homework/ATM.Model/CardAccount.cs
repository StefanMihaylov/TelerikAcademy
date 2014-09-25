namespace ATM.Model
{
    using System.ComponentModel.DataAnnotations;

    public class CardAccount
    {
        [Required]
        public int CardAccountId { get; set; }

        [Required]
        [MaxLength(10)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(4)]
        public string CardPIN { get; set; }

        [Required]
        public decimal CardMoney { get; set; }

    }
}
