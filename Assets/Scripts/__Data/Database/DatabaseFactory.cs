using Core;

namespace Data.Database
{
    public class DatabaseFactory<T> : ILoadData
    {
        IDatabaseHandler<T> _databaseHandler;
        IUseDatabase<T> _databaseUser;

        public DatabaseFactory(IDatabaseHandler<T> databaseHandler, IUseDatabase<T> databaseUser)
        {
            _databaseHandler = databaseHandler;
            _databaseUser = databaseUser;
        }

        public void LoadData()
        {
            T data = _databaseHandler.Load();
            
            _databaseUser.LoadData(data);
        }
    }
}
