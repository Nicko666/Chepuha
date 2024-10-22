namespace Core
{
    public class CoreMain
    {
        private ILoadData[] _databases;
        private ISaveData _playerPrefs;

        public CoreMain(ISaveData playerData, params ILoadData[] databases) 
        {
            _databases = databases;
            _playerPrefs = playerData;
        }

        public void LoadData()
        {
            foreach (var database in _databases)
                database.LoadData();

            _playerPrefs.LoadData();
        }

        public void SaveData()
        {
            _playerPrefs.SaveData();
        }
    }
}
