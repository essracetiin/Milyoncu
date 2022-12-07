using Milyoncu.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Uow
{
    public interface IUow
    {
        IBasketRep _basketRep { get; }
        ICategoryRep _categoryRep { get; }
        IEventRep _eventRep { get; }
        ITicketRep _ticketRep { get; }
        IUserRep _userRep { get; }
        IWalletRep _walletRep { get; }


        void Commit();
    }
}
