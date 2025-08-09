using System;
using UnityEngine;

public class DataController : IDataController
{
    private const string FileName = "ChepuhaData";

    private DataModel _dataModel;
    private JsonFileHandler _fileHandler = new();

    public event Action<DataModel> onLoadDataModel;
    public event RefAction<DataModel> onSaveDataModel;

    public void LoadData()
    {
        _dataModel = _fileHandler.Load<DataModel>(Application.persistentDataPath, FileName, "");
        
        _dataModel ??= new();

        onLoadDataModel?.Invoke(_dataModel);
    }
    public void SaveData()
    {
        _dataModel ??= new();

        onSaveDataModel?.Invoke(ref _dataModel);
        
        _fileHandler.Save(Application.persistentDataPath, FileName, "", _dataModel);
    }

    public void Dispose() { }
}
