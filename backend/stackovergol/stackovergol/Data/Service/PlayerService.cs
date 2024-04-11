using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using stackovergol.Data.Entity;
using stackovergol.Data.Repository;
using stackovergol.Dto;
using stackovergol.Exceptions;

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

        public void Add(PlayerDTO playerDto)
        {
            try
            {
                _dataContext.Player.Add(ToEntity(playerDto));
                _dataContext.SaveChanges();
            }catch(Exception ex)
            {
                if(ex.InnerException.Message.Contains("Duplicate entry"))
                {
                    throw new DuplicateException("O campo username é único");
                }
                throw new Exception("Erro ao cadastrar novo jogador");
            }
        }

        public int Update(PlayerDTO playerDto)
        {
            if (!_dataContext.Player.Any(p => p.PlayerId == playerDto.PlayerId))
                throw new NotFoundException("Jogador não encontrado");

            _dataContext.Entry(ToEntity(playerDto)).State = EntityState.Modified;
            return _dataContext.SaveChanges();
        }

        private Player ToEntity(PlayerDTO playerDto)
        {
            return _mapper.Map<Player>(playerDto);
        }
    }
}
