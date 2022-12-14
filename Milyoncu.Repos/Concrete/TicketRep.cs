using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Milyoncu.Core;
using Milyoncu.Dal;
using Milyoncu.Dto;
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
        public MilyoncuContext _db;
        public TicketRep(MilyoncuContext db) : base(db)
        {
            _db = db;
        }
        public TicketDTO AddToBasket(TicketDTO t)
        {
            var ticket = _db.Tickets.FirstOrDefault(r=>r.Id == t.Id);
            ticket.BasketId = t.BasketId;
            _db.Tickets.Entry(ticket).State = EntityState.Modified;
            _db.SaveChanges();
            return t;
        }
        public TicketDTO RemoveFromBasket(TicketDTO t)
        {
            var ticket = _db.Tickets.FirstOrDefault(r => r.Id == t.Id);
            ticket.BasketId = null;
            _db.Tickets.Entry(ticket).State = EntityState.Modified;
            _db.SaveChanges();
            return t;
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            _db.Set<Ticket>().Add(ticket);
            return ticket;
        }

        public bool DeletebyTicketId(int ticketId)
        {
            Set().Remove(Find(ticketId));
            return true;
        }

        public Ticket DeleteTicket(Ticket ticket)
        {
            _db.Set<Ticket>().Remove(ticket);
            return ticket;
        }

        public Ticket GetTicketbyId(int ticketId)
        {
            return _db.Tickets.Include(t => t.Event).FirstOrDefault(t => t.Id == ticketId);
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _db.Tickets.Include(t => t.Event).ToList();
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            _db.Set<Ticket>().Update(ticket);
            return ticket;
        }
    }
}
