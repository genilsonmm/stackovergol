using AutoMapper;
using Microsoft.EntityFrameworkCore;
using stackovergol.Data.Entity;
using stackovergol.Data.Repository;
using stackovergol.Dto;
using stackovergol.Exceptions;
using stackovergol.Infra;
using System.Linq.Expressions;

namespace stackovergol.Data.Service
{
    public class PlayerService : BaseRepository
    {

        public PlayerService(DataContext dataContext, IMapper mapper) 
            : base(dataContext, mapper) { }
    
        public List<PlayerResponseDTO> GetAll()
        {
            var players = _dataContext.Player.Where(p=>p.Enabled==true).OrderBy(p => p.Role.Name.Equals(Constants.MEMBER)).OrderBy(p => p.Name).Include(r=>r.Role).ToList();
            return players is List<Player> 
                ? _mapper.Map<List<PlayerResponseDTO>>(players) 
                : new List<PlayerResponseDTO>();
        }

        public List<PlayerResponseDTO> GetAllExcept(List<int> playersId)
        {
            if(playersId.Count == 0) return new List<PlayerResponseDTO>();

            string ids = "";
            playersId.ForEach(id =>
            {
                ids += playersId.Last() == id ? id : id + ",";
            });

            string query = $"select p.*, r.Name as Role from Player p inner join Roles r on p.RoleId = r.RoleId and p.Enabled = TRUE and PlayerId not in ({ids}) order by p.Name";

            var players = _dataContext.Player.FromSqlRaw(query).ToList();
       
            return players is List<Player>
                ? _mapper.Map<List<PlayerResponseDTO>>(players)
                : new List<PlayerResponseDTO>();
        }

        public int Add(PlayerDTO playerDto)
        {
            try
            {
                Role? role = _dataContext.Roles.Where(r => r.Name.Equals(playerDto.Role)).FirstOrDefault();
                Player player = ToEntity(playerDto);
                player.Enabled = true;
                player.RoleId = role.RoleId;

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

            var role = _dataContext.Roles.Where(_ => _.Name.Equals(playerDto.Role)).FirstOrDefault();
            var player = ToEntity(playerDto);
            player.RoleId = role.RoleId;

            _dataContext.Entry(player).State = EntityState.Modified;
            return _dataContext.SaveChanges();
        }

        public PlayerAuthDTO GetByCredentials(string username, string password)
        {
            var player = _dataContext.Player.Include(r => r.Role)
                .Where(p => p.Enabled==true && p.Username.Equals(username) && p.Password.Equals(password)).FirstOrDefault();
            
            if (player == null)
                throw new NotFoundException("Jogador não encontrado");

            return _mapper.Map<PlayerAuthDTO>(player);
        }

        private Player ToEntity(PlayerDTO playerDto)
        {
            return _mapper.Map<Player>(playerDto);
        }
    }
}
