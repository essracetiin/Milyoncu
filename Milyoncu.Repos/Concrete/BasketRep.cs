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
        public BasketRep(MilyoncuContext db) : base(db)
        {
            _db = db;
        }

        public Basket CreateCategory(Basket basket)
        {
            _db.Set<Basket>().Add(basket);
            return basket;
        }

        public Basket DeleteCategory(Basket basket)
        {
            _db.Set<Basket>().Remove(basket);
            return basket;
        }


        //IEnumerable<Basket> IBasketRep.GetBaskets => GetBaskets();

        public IEnumerable<Basket> GetBaskets()
        {
            return _db.Baskets.Include(r => r.User).Include(x => x.Tickets).ToList();
        }

        public Basket UpdateCategory(Basket basket)
        {
            _db.Set<Basket>().Update(basket);
            return basket;
        }

        Basket IBasketRep.GetBasketByUserId(int UserId)
        {
            return _db.Baskets.Include(r => r.User).Include(t => t.Tickets).Include(w => w.User.Wallet).FirstOrDefault(u => u.UserId == UserId);
        }
    }
}
