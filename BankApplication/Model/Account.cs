using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Model
{
    public class Account
    {
        [Key]
        public string AccountId { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Branch { get; set; }
        public string Owner { get; set; }
    }
}
