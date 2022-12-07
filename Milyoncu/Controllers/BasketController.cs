using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milyoncu.Repos.Abstract;
using System.Net.Mime;

namespace Milyoncu.API.Controllers
{
    
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRep _basketRep;
        public BasketController(IBasketRep basketRep)
        {
            _basketRep = basketRep;
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

    }
}
