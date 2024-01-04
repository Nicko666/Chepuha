using System;
using System.Collections.Generic;
using UnityEngine;

public class MVVMStartup : MonoBehaviour, IDataPersistence
{
    [SerializeField] StaticData staticData;

    List<ILocaldataModel> localdataModels;


    [SerializeField] InitView<GameQuestionnaireViewModel>[] gameQuestionnaireViews;
    [SerializeField] InitView<GameSavedStoriesSelectViewModel> gameSavedStoriesView;

    [SerializeField] InitView<SettingsVolumeViewModel> settingsVolumeViews;
    [SerializeField] InitView<SettingsColorViewModel> settingsColorViews;
    [SerializeField] InitView<SettingsFonrViewModel> settingsFontView;


    public void LoadData(LocalData localData)
    {
        MyDebug.Instance.Log("MVVMStartup.LoadData.0");

        localdataModels = new();


        GameModel gameModel = new(localData);
        localdataModels.Add(gameModel);
        //problems starts here

        GameQuestionnaireViewModel gameQuestionnaireViewModel = new(gameModel, staticData);
        foreach (var view in gameQuestionnaireViews)
            view.Init(gameQuestionnaireViewModel);

        GameSavedStoriesSelectViewModel gameSavedStoriesViewModel = new(gameModel);
        gameSavedStoriesView.Init(gameSavedStoriesViewModel);


        SettingsModel settingsModel = new(localData);
        localdataModels.Add(settingsModel);

        SettingsVolumeViewModel settingsVolumeViewModel = new(settingsModel);
        settingsVolumeViews.Init(settingsVolumeViewModel);

        SettingsColorViewModel settingsColorViewModel = new(settingsModel, staticData);
        settingsColorViews.Init(settingsColorViewModel);

        SettingsFonrViewModel settingsFonrViewModel = new(settingsModel, staticData);
        settingsFontView.Init(settingsFonrViewModel);

    }

    public void SaveData(ref LocalData data)
    {
        foreach(var model in localdataModels)
        {
            model.Save(ref data);
        }
        
    }


}
