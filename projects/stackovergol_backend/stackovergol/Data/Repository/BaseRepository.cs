using AutoMapper;

namespace stackovergol.Data.Repository
{
    public class BaseRepository
    {
        protected readonly DataContext _dataContext;
        protected readonly IMapper _mapper;

        public BaseRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
    }
}
