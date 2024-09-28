using UnityEngine;
using Core;
using Data.Database;
using Data.Player;
using DataHandlers.FileData;
using Models.Settings;
using Models.Questionnaires;

public class ProjectInstaller : MonoBehaviour
{
    private CoreMain _core;

    [SerializeField] private IDatabaseHandler<QuestionnaireDatabase> questionnaireDatabeseObject;
    [SerializeField] private IDatabaseHandler<SettingsDatabase> settingsDatabaseObject;
    [SerializeField] private IVolumePresenter volumePresenter;
    [SerializeField] private IBackgroundPresenter backgroundPresenter;
    [SerializeField] private IFontPresenter fontPresenter;
    [SerializeField] private IQuestionnairePresenter questionnairePresenter;
    [SerializeField] private IStoriesPresenter storiesPresenter;
    [SerializeField] private ISavedStoriesPresenters savedStoriesPresenter;

    private void Awake()
    {
        QuestionnaireModel questionnaireModel = new(questionnairePresenter, storiesPresenter, savedStoriesPresenter);
        SettingsModel settingsModel = new(volumePresenter, fontPresenter, backgroundPresenter);

        FileDataHandler<PlayerData> dataHandler = new FileDataHandler<PlayerData>(Application.persistentDataPath, "ChepuhaData");

        ILoadData questionnaireDatabese = new DatabaseFactory<QuestionnaireDatabase>(questionnaireDatabeseObject, questionnaireModel);
        ILoadData settingsDatabase = new DatabaseFactory<SettingsDatabase>(settingsDatabaseObject, settingsModel);
        ISaveData playerData = new DataFactory<PlayerData>(dataHandler, settingsModel, questionnaireModel);

        _core = new (playerData, questionnaireDatabese, settingsDatabase);

        _core?.LoadData();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            _core?.SaveData();
    }

    private void OnDestroy()
    {
        _core?.SaveData();
    }
}
