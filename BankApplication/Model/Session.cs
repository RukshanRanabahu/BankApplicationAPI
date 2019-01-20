using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Model
{
    public class Session
    {
        [Key]
        public string SessionID { get; set; }
        public string UserID { get; set; }
    }
}
