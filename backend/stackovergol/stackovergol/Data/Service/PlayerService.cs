using stackovergol.Data.Repository;

namespace stackovergol.Data.Service
{
    public class PlayerService : BaseRepository
    {

        public PlayerService(DataContext dataContext) : base(dataContext) { }
    }
}
