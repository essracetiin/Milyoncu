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
    public class EventRep<T> : BaseRepository<Event>, IEventRep where T : class
    {
        public MilyoncuContext _db;
        public EventRep(MilyoncuContext db) : base(db)
        {
            _db = db;
        }

        public Event CreateEvent(Event e)
        {
            _db.Set<Event>().Add(e);

            return e;

        }

        public bool DeletebyEventId(int EventId)
        {
            Set().Remove(Find(EventId));
            return true;
        }


        //public Event DeletebyEventId(int EventId)
        //{
        //    //return _db.Events.FirstOrDefault(e => e.Id == EventId);
        //    Set().Remove(Find(EventId));




        //}

        public Event DeleteEvent(Event e)
        {
            _db.Set<Event>().Remove(e);
            return e;
        }

        public Event GetEventbyId(int EventId)
        {
            return _db.Events.Include(c => c.Category).FirstOrDefault(e => e.Id == EventId);
        }

        public IEnumerable<Event> GetEvents()
        {
            return _db.Events.Include(c => c.Category).ToList();
        }

        public Event UpdateEvent(Event e)
        {
            _db.Set<Event>().Update(e);
            return e;

        }
    }
}