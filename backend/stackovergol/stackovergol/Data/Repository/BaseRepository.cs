namespace stackovergol.Data.Repository
{
    public class BaseRepository
    {
        protected readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
    }
}
