using Milyoncu.Core;
using Milyoncu.Dto;
using Milyoncu.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Repos.Abstract
{
    public interface IBasketRep: IBaseRepository<Basket>
    {
        IEnumerable<Basket> GetBaskets();
        BasketDTO ConfirmBasket(int userId);
        Basket GetBasketByUserId(int UserId); //Normalde DTO'dan dönmesi gerekiyor.
        Basket CreateCategory(Basket basket);
        Basket UpdateCategory(Basket basket);
        Basket DeleteCategory(Basket basket);
        Basket DeCompleteBasket(int basketId);
        public bool DeleteBasketById(int basketId);
    }
}
