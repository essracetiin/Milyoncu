using Microsoft.EntityFrameworkCore;
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

        public bool DeleteBasketById(int basketId)
        {
            Set().Remove(Find(basketId));
            return true;
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
        public BasketDTO ConfirmBasket(int userId)
        {
            var basket = _db.Baskets.Include(n => n.Tickets).FirstOrDefault(f => f.UserId == userId);
            basket.Completed = true;
            basket.Tickets.ToList().ForEach(item => item.Completed = true);
            _db.Baskets.Entry(basket).State = EntityState.Modified; //basket entitysinde değişiklik yapıldığı bilgisini yolluyor.
            _db.SaveChanges();
            BasketDTO basketdto = new BasketDTO();
            basketdto.Message = "Sepetiniz Onaylanmıştır.";
            basketdto.Error = false;
            return basketdto;
            
        }
    }
}
