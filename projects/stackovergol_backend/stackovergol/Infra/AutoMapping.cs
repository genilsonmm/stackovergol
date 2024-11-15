using AutoMapper;
using stackovergol.Data.Entity;
using stackovergol.Dto;

namespace stackovergol.Infra
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Player, PlayerAuthDTO>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (src.Role.Name)));
            
            CreateMap<PlayerDTO, Player>()
                .ForMember(dest => dest.RoleId, opt => opt.Ignore());

            CreateMap<Player, PlayerDTO>();

            CreateMap<PlayerDTO, Player>()
                .ForMember(dest => dest.Role, opt=>opt.Ignore());

            CreateMap<Player, PlayerResponseDTO>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (src.Role.Name)));

            CreateMap<EventResponse, Event>();
            CreateMap<Event, EventResponse>();

            CreateMap<EventRequest, Event>();
            CreateMap<Event, EventRequest>();

            CreateMap<InOrOutEventDTO, EventPlayer>();
        }
    }
}
