
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Entity.Concrete
{
    public class Wallet : BaseTable
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int Amount { get; set; }
    }
}
