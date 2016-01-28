using System;
using System.ComponentModel.DataAnnotations;

namespace StockTrackerFourLayer.Services
{
    public class TransactionDTO
    {
        [Required]
        public string   Ticker { get; set; }

        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }
    }
}