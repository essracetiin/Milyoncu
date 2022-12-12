using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using Milyoncu.Repos.Concrete;
using Milyoncu.Uow;
using System.Diagnostics.Tracing;
using System.Net.Mime;

namespace Milyoncu.API.Controllers
{
    [Route("/[controller]/[action]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRep _eventRep;
        private readonly IUow _uow;
        public EventController(IEventRep eventRep, IUow uow)
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
        [HttpGet("{EventId:int}")]
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

        [HttpPut]
        public IActionResult Update(Event e)
        {
            var Events = _eventRep.UpdateEvent(e);
            _uow.Commit();
            return this.Ok(Events);
        }

        [HttpDelete]
        public IActionResult Delete(Event e)
        {
            var Events = _eventRep.DeleteEvent(e);
            _uow.Commit();
            return this.Ok(Events);
        }
        [HttpDelete("{EventId:int}")]
        public IActionResult DeletebyEventId(int EventId)
        {
            _uow._eventRep.DeletebyEventId(EventId);
            _uow.Commit();
            return this.Ok();
        }
    }
}