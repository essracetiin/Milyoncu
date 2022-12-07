using Milyoncu.Dal;
using Milyoncu.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Uow
{
    public class Uow : IUow
    {
        MilyoncuContext _db;
        public IBasketRep _basketRep { get; private set; }

        public ICategoryRep _categoryRep { get; private set; }

        public IEventRep _eventRep { get; private set; }

        public ITicketRep _ticketRep { get; private set; }

        public IUserRep _userRep { get; private set; }

        public IWalletRep _walletRep { get; private set; }

        public void Commit()
        {
            _db.SaveChanges();
        }
        public Uow(MilyoncuContext db, IBasketRep basketRep, ICategoryRep categoryRep, IEventRep eventRep, ITicketRep ticketRep, IUserRep userRep, IWalletRep walletRep)
        {
            _db = db;
            _basketRep = basketRep;
            _categoryRep = categoryRep;
            _eventRep = eventRep;
            _ticketRep = ticketRep;
            _userRep = userRep;
            _walletRep = walletRep;
        }
    }
}
