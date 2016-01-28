using StockTrackerFourLayer.Services.Models;
using System.Collections.Generic;

namespace StockTrackerFourLayer.Services
{
    public class ExpandedStockDTO : StockDTO
    {
        public decimal LowPrice { get; set; }

        public decimal HighPrice { get; set; }

        public string Description { get; set; }

        public IList<TransactionDTO> Transactions { get; set; }
    }
}