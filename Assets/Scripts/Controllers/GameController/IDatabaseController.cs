using System;
using System.Collections.Generic;

public interface IDatabaseController : IDisposable
{
    public event Action<DatabaseModel> onLoadDatabaseModel;
    public event Action<List<QuestionModel[]>> onQuestionsModels;
    public void LoadData();
}
