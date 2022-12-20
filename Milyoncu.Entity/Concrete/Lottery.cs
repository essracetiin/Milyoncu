using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Entity.Concrete
{
    public class Lottery :BaseTable
    {
        public DateTime LotteryDate { get; set; }
        public int TicketId { get; set; }

    }
}
