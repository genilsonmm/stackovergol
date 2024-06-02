using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

            var response = _mapper.Map<EventResponse>(lastEvent);
            response.Players = PlayersInTheNextMatch(lastEvent.EventId);
            return response;
        }

        public List<EventResponse> GetAll()
        {
            var events = _dataContext.Event.OrderByDescending(e => e.EventId).Take(16).ToList();
            return _mapper.Map<List<EventResponse>>(events);
        }

        public void DeletePlayerFromMatch(int playerId)
        {
            var eventPlayer = _dataContext.EventPlayer.Where(ev=>ev.PlayerId == playerId).First();
            _dataContext.EventPlayer.Remove(eventPlayer);
            _dataContext.SaveChanges();
        }

        public void PlayerInOrOutOfEvent(InOrOutEventDTO inOrOutEventDTO)
        {
            EventPlayer eventPlayer = _dataContext.EventPlayer.Where(e => e.EventId == inOrOutEventDTO.EventId && e.PlayerId == inOrOutEventDTO.PlayerId).FirstOrDefault();
            eventPlayer.IAmIn = inOrOutEventDTO.IAmIn;
            if (eventPlayer != null)
            {
                _dataContext.Entry(eventPlayer).State = EntityState.Modified;
            }
            else
            {
                _dataContext.EventPlayer.Add(_mapper.Map<EventPlayer>(inOrOutEventDTO));
            }
            _dataContext.SaveChanges();
        }

        private Dictionary<string, List<PlayerResponseDTO>> PlayersInTheNextMatch(int eventId)
        {
            List<EventPlayer> eventPlayers = _dataContext.EventPlayer
                .Where(e => e.EventId == eventId)
                .Include(player => player.Player)
                .OrderBy(item=>item.IAmIn)
                .ToList();

            
            Dictionary<string, List<PlayerResponseDTO>> players = new Dictionary<string, List<PlayerResponseDTO>>();

            players.Add("in", _mapper.Map<List<PlayerResponseDTO>>(eventPlayers.FindAll(p => p.IAmIn == true).Select(item => item.Player).ToList()));
            players.Add("out", _mapper.Map<List<PlayerResponseDTO>>(eventPlayers.FindAll(p => p.IAmIn == false).Select(item => item.Player).ToList()));

            return players;
        }
    }
}

