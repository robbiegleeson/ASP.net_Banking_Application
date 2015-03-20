using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DublinBusinessSchoolCreditUnion.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
            : base("DBSCU_Rob_Home")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}