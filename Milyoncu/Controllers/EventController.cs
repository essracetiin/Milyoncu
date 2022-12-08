using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using Milyoncu.Uow;

namespace Milyoncu.API.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRep _eventRep;
        private readonly IUow _uow;
        public EventController(IEventRep eventRep , IUow uow)
        {
            _eventRep = eventRep;
            _uow = uow;
        }
        [HttpGet]

        public IActionResult GetEvents()
        {
            var events = _eventRep.GetEvents();
            return this.Ok(events);
        }
        [HttpGet("GetEventbyId")]
        public IActionResult GetEventbyId(int EventId)
        {
            var events = _eventRep.GetEventbyId(EventId);
            return this.Ok(events);
        }
        [HttpPost]
        public IActionResult CreateEvent(Event e)
        {
            var c = _eventRep.CreateEvent(e);
            _uow.Commit();
            return this.Ok(c);
        }
    }
}
