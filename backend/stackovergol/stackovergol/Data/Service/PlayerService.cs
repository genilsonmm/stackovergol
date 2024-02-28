using AutoMapper;
using stackovergol.Data.Entity;
using stackovergol.Data.Repository;
using stackovergol.Dto;

namespace stackovergol.Data.Service
{
    public class PlayerService : BaseRepository
    {

        public PlayerService(DataContext dataContext, IMapper mapper) 
            : base(dataContext, mapper) { }
    
        public List<PlayerResultDTO> GetAll()
        {
            var players = _dataContext.Player.OrderBy(p => p.Name).ToList();
            return players is List<Player> 
                ? _mapper.Map<List<PlayerResultDTO>>(players) 
                : new List<PlayerResultDTO>();
        }

        public int Add(PlayerDTO playerDto)
        {
            var player = _mapper.Map<Player>(playerDto);
            _dataContext.Player.Add(player);
            return _dataContext.SaveChanges();
        }
    }
}
