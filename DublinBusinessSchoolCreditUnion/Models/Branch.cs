using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DublinBusinessSchoolCreditUnion.Models
{
    [Table("tblBranches")]
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }
        public string BranchLocation { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}