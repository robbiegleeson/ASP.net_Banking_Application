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
<<<<<<< HEAD
            : base("DBSCU_Rob_Home")
=======
            : base("mikeHome")
>>>>>>> 170ebfb86ef32f17aa755ef029c74b6a90452507
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}