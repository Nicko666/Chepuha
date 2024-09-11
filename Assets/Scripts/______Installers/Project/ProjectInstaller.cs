using UnityEngine;
using UData;
using Data.Database;
using Data.Player;
using DataHandlers.ObjectData;
using DataHandlers.FileData;
using Models.Settings;
using Models.Questionnaires;
using Presenters.Volume;
using Presenters.Background;
using Presenters.Font;
using Presenters.Questionnaires;
using Presenters.SavedStories;

public class ProjectInstaller : MonoBehaviour
{
    DataFactory<PlayerData> _dataFactory;

    [SerializeField] private QuestionnaireDatabaseObject questionnaireDatabeseObject;
    [SerializeField] private SettingsDatabseObject settingsDatabaseObject;
    [SerializeField] private IVolumePresenter volumeView;
    [SerializeField] private IBackgroundPresenter backgroundView;
    [SerializeField] private IFontPresenter fontView;
    [SerializeField] private IQuestionnairePresenter questionnaireView;
    [SerializeField] private ISavedStoriesPresenters savedStoriesView;

    private void Awake()
    {
        QuestionnaireModel questionnaireModel = new(questionnaireView, savedStoriesView);
        SettingsModel settingsModel = new(volumeView, fontView, backgroundView);

        FileDataHandler<PlayerData> dataHandler = new FileDataHandler<PlayerData>(Application.persistentDataPath, "ChepuhaData");

        DatabaseFactory<QuestionnaireDatabase> questionnaireDatabese = new(questionnaireDatabeseObject, questionnaireModel);
        DatabaseFactory<SettingsDatabase> settingsDatabase = new(settingsDatabaseObject, settingsModel);
        _dataFactory = new DataFactory<PlayerData>(dataHandler, settingsModel, questionnaireModel);

        questionnaireDatabese?.LoadData();
        settingsDatabase?.LoadData();
        _dataFactory?.LoadData();
    }

    private void OnDestroy()
    {
        _dataFactory?.SaveData();
    }
}
