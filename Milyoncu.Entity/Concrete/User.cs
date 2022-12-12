
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Entity.Concrete
{
    public class User: BaseTable 
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Role { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Error { get; set; }
        public int WalletId { get; set; }
        [ForeignKey("WalletId")]
        public  Wallet ?Wallet { get; set; }
    }
}
