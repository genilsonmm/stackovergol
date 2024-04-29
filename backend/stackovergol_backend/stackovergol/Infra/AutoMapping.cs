using AutoMapper;
using stackovergol.Data.Entity;
using stackovergol.Dto;

namespace stackovergol.Infra
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Player, PlayerDTO>();
            CreateMap<PlayerDTO, Player>();

            CreateMap<Player, PlayerResultDTO>();
        }
    }
}
