using Microsoft.EntityFrameworkCore;
using Milyoncu.Core;
using Milyoncu.Dal;
using Milyoncu.Dal.Migrations;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Repos.Concrete
{
    public class LotteryRep<T> : BaseRepository<Lottery>, ILotteryRep where T : class
    {
        public MilyoncuContext _db;
        public LotteryRep(MilyoncuContext db) : base(db)
        {
            _db = db;
        }

        public Lottery CreateLottery(int eventId)
        {
            
            var tickets = _db.Tickets.Where(e => e.EventId == eventId).Where(s=>s.Completed==true).ToList();
            

            Random t = new Random();
            var c = t.Next(0, tickets.Count - 1);
            var winner = tickets[c];
            Lottery lottery = new Lottery()
            {
                LotteryDate = DateTime.Now,
                TicketId = winner.Id
                

            };
            _db.Lotteries.Add(lottery);
            _db.SaveChanges();
            return lottery;
        }
    }
}
