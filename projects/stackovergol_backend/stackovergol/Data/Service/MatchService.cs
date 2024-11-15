using AutoMapper;
using stackovergol.Data.Repository;

namespace stackovergol.Data.Service
{
    public class MatchService : BaseRepository
    {
        public MatchService(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
