using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DublinBusinessSchoolCreditUnion.Models
{
    [Table("tblTransactionTable")]
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public string TransactionType { get; set; }
        public int TransactionAmount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int TransactionAccountNumber { get; set; }
        public int DestinationAccountNumber { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionReference { get; set; }
    }
}