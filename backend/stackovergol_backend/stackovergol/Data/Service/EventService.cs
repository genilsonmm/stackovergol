using AutoMapper;
using stackovergol.Data.Entity;
using stackovergol.Data.Repository;
using stackovergol.Dto;

namespace stackovergol.Data.Service
{
    public class EventService : BaseRepository
    {
        public EventService(DataContext dataContext, IMapper mapper)
            : base(dataContext, mapper) { }

        public int Add(EventResponse eventDTO)
        {
            Event newEvent = _mapper.Map<Event>(eventDTO);
            _dataContext.Event.Add(newEvent);
            _dataContext.SaveChanges();
            return newEvent.EventId;
        }

        public EventResponse GetNext()
        {
            Event lastEvent = _dataContext.Event.OrderByDescending(e => e.EventId).FirstOrDefault();
            return _mapper.Map<EventResponse>(lastEvent);
        }

        public List<EventResponse> GetAll()
        {
            var events = _dataContext.Event.OrderByDescending(e => e.EventId).Take(16).ToList();
            return _mapper.Map<List<EventResponse>>(events);
        }
    }
}

