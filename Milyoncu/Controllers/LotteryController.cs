using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Milyoncu.Dal;
using Milyoncu.Repos.Abstract;
using Milyoncu.Uow;
using System.Net.Mime;

namespace Milyoncu.API.Controllers
{
    [Route("/[controller]/[action]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class LotteryController : ControllerBase
    {
        private readonly ILotteryRep _lotteryRep;
        private readonly IUow _uow;
       
        
        public LotteryController(ILotteryRep lotteryRep, IUow uow)
        {
            _lotteryRep = lotteryRep;
            _uow = uow;
            
            
        }
        [HttpPost("CreateLottery")]
        public IActionResult CreateLottery(int eventId)
        {
           
            var lottery = _lotteryRep.CreateLottery(eventId);
            return this.Ok(lottery);
        }
    }
}
