using Microsoft.EntityFrameworkCore;
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
    public class BasketRep<T>: BaseRepository<Basket>,IBasketRep where T : class
    {
        public MilyoncuContext _db;
        public BasketRep(MilyoncuContext db): base(db)
        {
            _db = db;
        }

        public Basket GetBasketByUserId(int UserId)
        {
            return _db.Baskets.Include(r => r.User).Include(t => t.Tickets).Include(w=>w.User.Wallet).FirstOrDefault(u => u.UserId == UserId);
        }

        //IEnumerable<Basket> IBasketRep.GetBaskets => GetBaskets();

        public IEnumerable<Basket> GetBaskets()
        {
            return _db.Baskets.Include(r => r.User).Include(x => x.Tickets).ToList();
        }

    }
}
