using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DatabaseController : IDatabaseController
{
    [SerializeField] private DatabaseModel _databaseModel;
    
    public event Action<DatabaseModel> onLoadDatabaseModel;
    public event Action<List<QuestionModel[]>> onQuestionsModels;

    public DatabaseController(DatabaseModel databaseModel) => 
        _databaseModel = databaseModel;

    public void LoadData()
    {
        onLoadDatabaseModel.Invoke(_databaseModel);
    }
    
    public void Dispose() { }
}