using StockTrackerFourLayer.Domain;
using StockTrackerFourLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StockTrackerFourLayer.Infrastructure
{
    public class TransactionRepository : GenericRepository <Transaction>
    {
        public TransactionRepository(DbContext db) : base(db) { }
    }
}