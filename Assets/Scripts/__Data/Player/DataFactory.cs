using UData;

namespace Data.Player
{
    public class DataFactory<T> : ISaveData where T : class, new()
    {
        T _data;

        IDataHandler<T> _dataHandler; 

        IUseData<T>[] _dataUsers;

        //private void Start()
        //{
        //    _dataHandler = new FileDataHandler(Application.persistentDataPath, "ChepuhaData");

        //    _dataPersistanceObjects = DataPersistanceObjects();

        //    LoadData();

        //}

        public DataFactory (IDataHandler<T> dataHandler, params IUseData<T>[] dataUsers)
        {
            _dataHandler = dataHandler;
            _dataUsers = dataUsers;
        }

        public void LoadData()
        {
            _data = _dataHandler.Load();

            if (_data == null)
            {
                NewData();
            }

            foreach (var item in _dataUsers)
            {
                item.LoadData(_data);
            }

        }

        void NewData()
        {
            _data = new T();
        }

        public void SaveData()
        {
            foreach (var item in _dataUsers)
            {
                item.SaveData(ref _data);
            }

            _dataHandler.Save(_data);
        }

        //private void OnApplicationFocus(bool focus)
        //{
        //    if (!focus)
        //    {
        //        SaveData();
        //    }

        //}

        //private void OnApplicationQuit()
        //{
        //    SaveData();

        //}

        ////private List<IDataPersistence> DataPersistanceObjects()
        ////{
        ////    return new List<IDataPersistence>(GetComponents<IDataPersistence>());
        ////}

        //private List<IUseData> DataPersistanceObjects()
        //{
        //    return new List<IUseData>(FindObjectsOfType<MonoBehaviour>().OfType<IUseData>());
        //}


    }
}