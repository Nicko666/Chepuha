using System;

public interface IDataController : IDisposable
{
    public event Action<DataModel> onLoadDataModel;
    public event RefAction<DataModel> onSaveDataModel;
    
    public void LoadData();
    public void SaveData();
}
