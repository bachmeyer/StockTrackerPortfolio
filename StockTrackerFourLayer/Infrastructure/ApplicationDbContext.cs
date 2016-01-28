﻿using StockTrackerFourLayer.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockTrackerFourLayer.Domain.Identity;
using System.Data.Entity;

namespace StockTrackerFourLayer.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Transaction> Transactions {get; set;}

    public IDbSet<Stock> Stocks {get; set;}
    }
}