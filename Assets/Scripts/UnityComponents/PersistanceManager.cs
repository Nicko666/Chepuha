using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PersistanceManager : MonoBehaviour
{
    LocalData _data;

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
        _data = new LocalData();
        MyDebug.Instance.Log("New");
    }

    void LoadData()
    {
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

    public void SaveData()
    {
        foreach (var item in _dataPersistanceObjects)
        {
            item.SaveData(ref _data);
        }

        _dataHandler.Save(_data);

    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveData();
        }

    }

    private void OnApplicationQuit()
    {
        SaveData();

    }

    //private List<IDataPersistence> DataPersistanceObjects()
    //{
    //    return new List<IDataPersistence>(GetComponents<IDataPersistence>());
    //}

    private List<IDataPersistence> DataPersistanceObjects()
    {
        return new List<IDataPersistence>(FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>());
    }


}
