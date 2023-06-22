using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PersistanceManager : Singleton<PersistanceManager>
{
    Data _data;

    FileDataHandler _dataHandler;

    List<IDataPersistence> _dataPersistanceObjects;

    


    private void Start()
    {
        _dataHandler = new FileDataHandler(Application.persistentDataPath, "ChepuhaData");
        
        _dataPersistanceObjects = DataPersistanceObjects();
        
        LoadData();
        
    }

    void NewData()
    {
        _data = new Data();

    }

    void LoadData()
    {
        Debug.Log("LoadingData");

        _data = _dataHandler.Load();

        if ( _data == null )
        {
            NewData();
        }

        foreach (var item in _dataPersistanceObjects)
        {
            item.LoadData(_data);
        }

    }

    void SaveData()
    {
        Debug.Log("SaveData");

        foreach (var item in _dataPersistanceObjects)
        {
            item.SaveData(ref _data);
        }

        _dataHandler.Save(_data);

    }

    private void OnApplicationQuit()
    {
        SaveData();

    }

    private List<IDataPersistence> DataPersistanceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistanceObjects);

    }


}
