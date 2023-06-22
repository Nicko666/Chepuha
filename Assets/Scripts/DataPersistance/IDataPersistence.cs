using UnityEngine;

public interface IDataPersistence
{
    void LoadData(Data data);

    void SaveData(ref Data data);


}
