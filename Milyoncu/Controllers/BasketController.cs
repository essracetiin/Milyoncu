using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milyoncu.Dto.Models;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using Milyoncu.Repos.Concrete;
using Milyoncu.Uow;
using System.Net.Mime;

namespace Milyoncu.API.Controllers
{

    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRep _basketRep;
        IUow _uow;
        BasketModel _basketModel;
        public BasketController(IBasketRep basketRep, IUow uow, BasketModel basketModel)
        {
            _basketRep = basketRep;
            _uow = uow;
            _basketModel = basketModel; 
        }
        [HttpGet]

        public IActionResult GetBaskets()
        {
            var baskets = _basketRep.GetBaskets();
            return this.Ok(baskets);
        }
        [HttpGet("GetByUserId")]
        public IActionResult GetBasketByUserId(int UserId)
        {
            var baskets = _basketRep.GetBasketByUserId(UserId);
            return this.Ok(baskets);

        }
        [HttpPost]
        public IActionResult Create(Basket basket)
        {
            var baskets = _basketRep.CreateCategory(basket);
            _uow.Commit();
            return this.Ok(baskets);
        } 
        [HttpPut]
        public IActionResult Update(Basket basket)
        {
            var baskets = _basketRep.UpdateCategory(basket);
            _uow.Commit();
            return this.Ok(baskets);
        }
        [HttpDelete]
        public IActionResult Delete(Basket basket)
        {
            var baskets = _basketRep.DeleteCategory(basket);
            _uow.Commit();
            return this.Ok(baskets);
        }
        [HttpDelete("{basketId:int}")]
        public IActionResult DeleteBasketById(int basketId)
        {
            _uow._basketRep.DeleteBasketById(basketId);
            _uow.Commit();
            return this.Ok();
        }

    }
}