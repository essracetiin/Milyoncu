using Milyoncu.Core;
using Milyoncu.Dal;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Repos.Concrete
{
    public class TicketRep<T> : BaseRepository<Ticket>, ITicketRep where T : class
    {
        public TicketRep(MilyoncuContext db) : base(db)
        {

        }
    }
}
