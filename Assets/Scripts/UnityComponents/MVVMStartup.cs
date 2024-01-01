using System.Collections.Generic;
using UnityEngine;

public class MVVMStartup : MonoBehaviour, IDataPersistence
{
    [SerializeField] StaticData staticData;

    List<ILocaldataModel> localdataModels;


    public void LoadData(LocalData localData)
    {
        localdataModels = new();


        GameModel gameModel = new(localData);
        localdataModels.Add(gameModel);

        GameQuestionnaireSelectViewModel gameQuestionnaireViewModel = new GameQuestionnaireSelectViewModel(gameModel, staticData);
        var gameQuestionnaireViews = GetComponents<IInit<GameQuestionnaireSelectViewModel>>();
        foreach(var view in gameQuestionnaireViews)
            view.Init(gameQuestionnaireViewModel);

        GameSavedStoriesSelectViewModel gameSavedStoriesViewModel = new GameSavedStoriesSelectViewModel(gameModel);
        var gameSavedStoriesViews = GetComponents<GameSavedStoriesView>();
        foreach (var view in gameSavedStoriesViews)
            view.Init(gameSavedStoriesViewModel);


        SettingsModel settingsModel = new(localData);
        localdataModels.Add(settingsModel);

        SettingsVolumeViewModel settingsVolumeViewModel = new(settingsModel);
        var settingsVolumeViews = GetComponents<SettingsVolumeView>();
        foreach (var view in settingsVolumeViews)
            view.Init(settingsVolumeViewModel);

        SettingsColorViewModel settingsColorViewModel = new(settingsModel, staticData);
        var settingsColorViews = GetComponents<SettingsColorView>();
        foreach (var view in settingsColorViews)
            view.Init(settingsColorViewModel);

        SettingsFonrViewModel settingsFonrViewModel = new(settingsModel, staticData);
        var settingsFontView = GetComponents<IInit<SettingsFonrViewModel>>();
        foreach (var view in settingsFontView)
            view.Init(settingsFonrViewModel);

    }

    public void SaveData(ref LocalData data)
    {
        foreach(var model in localdataModels)
        {
            model.Save(ref data);
        }
        
    }


}
