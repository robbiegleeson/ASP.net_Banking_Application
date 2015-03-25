using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DublinBusinessSchoolCreditUnion.Models
{
    [DataContract]
    [Table("tblTransactionTable")]
    public class Transaction
    {
        [DataMember]
        [Key]
        public int TransactionID { get; set; }
        [DataMember]
        public string TransactionType { get; set; }
        [DataMember]
        public int TransactionAmount { get; set; }
        [DataMember]
        public DateTime TransactionDateTime { get; set; }
        [DataMember]
        public int TransactionAccountNumber { get; set; }
        [DataMember]
        public int DestinationAccountNumber { get; set; }
        [DataMember]
        public string TransactionDescription { get; set; }
        [DataMember]
        public string TransactionReference { get; set; }
    }
}