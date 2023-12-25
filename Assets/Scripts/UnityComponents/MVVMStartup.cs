using System.Collections.Generic;
using UnityEngine;

public class MVVMStartup : MonoBehaviour, IDataPersistence
{
    [SerializeField] StaticData staticData;

    List<ILocaldataModel> localdataModels;


    public void LoadData(LocalData data)
    {
        localdataModels = new();

        GameModel gameModel = new(data);
        localdataModels.Add(gameModel);

        GameQuestionnaireViewModel gameQuestionnaireViewModel = new GameQuestionnaireViewModel(gameModel, staticData);
        var gameQuestionnaireViews = GetComponents<GameQuestionnaireView>();
        foreach(var view in gameQuestionnaireViews)
        {
            view.Init(gameQuestionnaireViewModel);
        }

        GameSavedStoriesViewModel gameSavedStoriesViewModel = new GameSavedStoriesViewModel(gameModel);
        var gameSavedStoriesViews = GetComponents<GameSavedStoriesView>();
        foreach (var view in gameSavedStoriesViews)
        {
            view.Init(gameSavedStoriesViewModel);
        }

    }

    public void SaveData(ref LocalData data)
    {
        foreach(var model in localdataModels)
        {
            model.Save(ref data);
        }
        
    }


}
