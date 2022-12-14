using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milyoncu.Dto;
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
    public class TicketController : ControllerBase
    {
        private readonly ITicketRep _ticketRep;
        private readonly IUow _uow;

        public TicketController(ITicketRep ticketRep, IUow uow)
        {
            _ticketRep = ticketRep;
            _uow = uow;
        }
        [HttpGet]
        public IActionResult GetTickets()
        {
            var tickets = _ticketRep.GetTickets();
            return this.Ok(tickets);
        }
        [HttpGet("{ticketId:int}")]
        public IActionResult GetTicketbyId(int ticketId)
        {
            var tickets = _ticketRep.GetTicketbyId(ticketId);
            return this.Ok(tickets);
        }
        [HttpPost]
        public IActionResult CreateTicket(Ticket ticket)
        {
            var tickets = _ticketRep.CreateTicket(ticket);
            _uow.Commit();
            return this.Ok(tickets);
        }
        [HttpPut]
        public IActionResult Update(Ticket ticket)
        {
            var tickets = _ticketRep.UpdateTicket(ticket);
            _uow.Commit();
            return this.Ok(tickets);
        }
        [HttpDelete]
        public IActionResult Delete(Ticket ticket)
        {
            var tickets = _ticketRep.DeleteTicket(ticket);
            _uow.Commit();
            return this.Ok(tickets);
        }
        [HttpDelete("{ticketId:int}")]
        public IActionResult DeletebyTicketId(int ticketId)
        {
            _uow._ticketRep.DeletebyTicketId(ticketId);
            _uow.Commit();
            return this.Ok();
        }
        [HttpPost("AddToBasket")]
        public IActionResult AddToBasket(TicketDTO t)
        {
            var tickets = _ticketRep.AddToBasket(t);
            return this.Ok(tickets);
        }

        [HttpPost("RemoveFromBasket")]
        public IActionResult RemoveFromBasket(TicketDTO t)
        {
            var tickets = _ticketRep.RemoveFromBasket(t);
            return this.Ok(tickets);
        }

    }
}
