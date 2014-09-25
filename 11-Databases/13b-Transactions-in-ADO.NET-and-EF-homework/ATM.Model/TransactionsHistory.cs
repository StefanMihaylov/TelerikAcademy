namespace ATM.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransactionsHistory
    {
        [Required]
        [Key]
        public int RecondId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string SenderCardNumber { get; set; }

        [Required]
        [MaxLength(10)]
        public string ReceiverCardNumber { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
