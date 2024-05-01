using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    
        public List<PlayerResponseDTO> GetAll()
        {
            var players = _dataContext.Player.Where(p=>p.Enabled==true).OrderBy(p => p.IsMember == true).OrderBy(p => p.Name).ToList();
            return players is List<Player> 
                ? _mapper.Map<List<PlayerResponseDTO>>(players) 
                : new List<PlayerResponseDTO>();
        }

        public int Add(PlayerDTO playerDto)
        {
            try
            {
                Player player = ToEntity(playerDto);
                player.Enabled = true;
                _dataContext.Player.Add(player);
                _dataContext.SaveChanges();
                return player.PlayerId;
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
