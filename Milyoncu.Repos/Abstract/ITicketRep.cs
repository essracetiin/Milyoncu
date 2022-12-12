﻿using Milyoncu.Core;
using Milyoncu.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Repos.Abstract
{
    public interface ITicketRep : IBaseRepository<Ticket>
    {
        public IEnumerable<Ticket> GetTickets();
        public Ticket GetTicketbyId(int ticketId);
        public Ticket CreateTicket(Ticket ticket);
        public Ticket UpdateTicket(Ticket ticket);
        public Ticket DeleteTicket(Ticket ticket);
        public bool DeletebyTicketId(int ticketId);
    }
}
