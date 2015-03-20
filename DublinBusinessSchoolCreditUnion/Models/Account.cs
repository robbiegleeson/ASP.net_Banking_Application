using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DublinBusinessSchoolCreditUnion.Models
{
    [Table("tblAccounts")]
    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public int CustomerID { get; set; }
        public int Balance { get; set; }
    }
}