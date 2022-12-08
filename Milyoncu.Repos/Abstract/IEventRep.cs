using Milyoncu.Core;
using Milyoncu.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Repos.Abstract
{
    public interface IEventRep : IBaseRepository<Event>
    {
        public IEnumerable<Event> GetEvents();
        public Event GetEventbyId(int EventId);
        public Event CreateEvent(Event e);
        public Event UpdateEvent();
        public Event DeleteEvent();



    }
}
