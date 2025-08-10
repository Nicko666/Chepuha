using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Controllers, IDisposable
{
    private IDatabaseController _databaseController;
    private IDataController _dataController;
    private ISoundController _soundController;
    private IListSettingController<Color> _backgroundSettingController;
    private IFloatSettingController _vignetteSettingController;
    private IListSettingController<TMP_FontAsset> _fontSettingController;
    private IListSettingController<int> _presenterSettingController;
    private IListSettingController<QuestionsData> _questionsSettingController;
    private IListSettingController<int> _queueSettingController;
    private IQuestionnaireController _questionnaireController;
    private IStoriesController _storiesController;
    private IGamePresenter _gamePresenter;
    private ILoadingPresenter _loadingPresenter;

    public GameController(
        IDatabaseController databaseController,
        IDataController dataController,
        ISoundController soundController,
        IListSettingController<Color> backgroundSettingController,
        IFloatSettingController vignetteSettingController,
        IListSettingController<TMP_FontAsset> fontSettingController,
        IListSettingController<int> presenterSettingController,
        IListSettingController<QuestionsData> questionsSettingController,
        IListSettingController<int> queueSettingController,
        IQuestionnaireController questionnaireController,
        IStoriesController storiesController,
        IGamePresenter gamePresenter,
        ILoadingPresenter loadingPresenter
        ) : base()
    {
        _databaseController = databaseController;
        _dataController = dataController;
        _soundController = soundController;
        _backgroundSettingController = backgroundSettingController;
        _vignetteSettingController = vignetteSettingController;
        _fontSettingController = fontSettingController;
        _presenterSettingController = presenterSettingController;
        _questionsSettingController = questionsSettingController;
        _queueSettingController = queueSettingController;
        _questionnaireController = questionnaireController;
        _storiesController = storiesController;
        _gamePresenter = gamePresenter;
        _loadingPresenter = loadingPresenter;

        SceneManager.sceneLoaded += SetSceneLoaded;
        Application.focusChanged += SetFocusChanged;
        _databaseController.onLoadDatabaseModel += LoadDatabaseModel;
        _dataController.onLoadDataModel += LoadDataModel;
        _dataController.onSaveDataModel += SaveDataModel;

        _questionsSettingController.onValueChanged += _questionnaireController.SetQuestionsModel;
        _questionnaireController.onQuestionnaireModel += _gamePresenter.OutputQuestionnaireModel;
        _questionnaireController.onQuestionnaireModel += _storiesController.SetQuestionnaireModels;
        _storiesController.onCreatedStorieModelsChanged += _gamePresenter.OutputCreatedStoriesModel;
        _storiesController.onSavedStorieModelsChanged += _gamePresenter.OutputSavedStoryModels;
        _backgroundSettingController.onValuesChanged += _gamePresenter.OutputBackgroundsModel;
        _backgroundSettingController.onValueChanged += _gamePresenter.OutputBackgroundModel;
        _vignetteSettingController.onValueLimitsChanged += _gamePresenter.OutputVignetteBoundsModel;
        _vignetteSettingController.onValueChanged += _gamePresenter.OutputVignetteModel;
        _fontSettingController.onValuesChanged += _gamePresenter.OutputFontsModel;
        _fontSettingController.onValueChanged += _gamePresenter.OutputFontModel;
        _presenterSettingController.onValuesChanged += _gamePresenter.OutputPresentersModel;
        _presenterSettingController.onValueChanged += _gamePresenter.OutputPresenterModel;
        _queueSettingController.onValuesChanged += _gamePresenter.OutputQueuesModel;
        _queueSettingController.onValueChanged += _gamePresenter.OutputQueueModel;
        _soundController.onSoundValueBoundsChanged += _gamePresenter.OutputVolumeBoundsModel;
        _soundController.onSoundValueChanged += _gamePresenter.OutputVolumeModel;

        _gamePresenter.onInputBackground += _backgroundSettingController.SetValueModel;
        _gamePresenter.onInputFont += _fontSettingController.SetValueModel;
        _gamePresenter.onInputVolume += _soundController.SetVolume;
        _gamePresenter.onInputPresenter += _presenterSettingController.SetDataModel;
        _gamePresenter.onInputSavedStoryModelRemove += _storiesController.RemoveSavedStoryModel;
        _gamePresenter.onInputVignette += _vignetteSettingController.SetValueModel;
        _gamePresenter.onInputQuestionsModel += _questionsSettingController.SetValueModel;
        _gamePresenter.onInputPlayersCountModel += _questionnaireController.SetPlayersCountModel;
        _gamePresenter.onInputRemovePlayerModel += _questionnaireController.RemovePlayerModel;
        _gamePresenter.onInputClearPlayerModel += _questionnaireController.ClearPlayerModel;
        _gamePresenter.onInputAddNewAnswerModels += _questionnaireController.AddPlayerModel;
        _gamePresenter.onInputAnswerModel += _questionnaireController.SetAnswerModel;
        _gamePresenter.onInputAddSavedStoryModel += _storiesController.AddSavedStoryModel;
        _gamePresenter.onInputQueueModel += _queueSettingController.SetValueModel;

        Debug.Log("IsBinded");
    }

    public void Dispose()
    {
        SceneManager.sceneLoaded -= SetSceneLoaded;
        Application.focusChanged -= SetFocusChanged;
        _databaseController.onLoadDatabaseModel -= LoadDatabaseModel;
        _dataController.onLoadDataModel -= LoadDataModel;
        _dataController.onSaveDataModel -= SaveDataModel;

        _questionsSettingController.onValueChanged -= _questionnaireController.SetQuestionsModel;
        _questionnaireController.onQuestionnaireModel -= _gamePresenter.OutputQuestionnaireModel;
        _questionnaireController.onQuestionnaireModel -= _storiesController.SetQuestionnaireModels;
        _storiesController.onCreatedStorieModelsChanged -= _gamePresenter.OutputCreatedStoriesModel;
        _storiesController.onSavedStorieModelsChanged -= _gamePresenter.OutputSavedStoryModels;
        _backgroundSettingController.onValuesChanged -= _gamePresenter.OutputBackgroundsModel;
        _backgroundSettingController.onValueChanged -= _gamePresenter.OutputBackgroundModel;
        _vignetteSettingController.onValueLimitsChanged += _gamePresenter.OutputVignetteBoundsModel;
        _vignetteSettingController.onValueChanged += _gamePresenter.OutputVignetteModel;
        _fontSettingController.onValuesChanged -= _gamePresenter.OutputFontsModel;
        _fontSettingController.onValueChanged -= _gamePresenter.OutputFontModel;
        _presenterSettingController.onValuesChanged -= _gamePresenter.OutputPresentersModel;
        _presenterSettingController.onValueChanged -= _gamePresenter.OutputPresenterModel;
        _queueSettingController.onValuesChanged -= _gamePresenter.OutputQueuesModel;
        _queueSettingController.onValueChanged -= _gamePresenter.OutputQueueModel;
        _soundController.onSoundValueBoundsChanged -= _gamePresenter.OutputVolumeBoundsModel;
        _soundController.onSoundValueChanged -= _gamePresenter.OutputVolumeModel;

        _gamePresenter.onInputBackground -= _backgroundSettingController.SetValueModel;
        _gamePresenter.onInputFont -= _fontSettingController.SetValueModel;
        _gamePresenter.onInputVolume -= _soundController.SetVolume;
        _gamePresenter.onInputPresenter -= _presenterSettingController.SetDataModel;
        _gamePresenter.onInputSavedStoryModelRemove -= _storiesController.RemoveSavedStoryModel;
        _gamePresenter.onInputVignette -= _vignetteSettingController.SetValueModel;
        _gamePresenter.onInputQuestionsModel -= _questionsSettingController.SetValueModel;
        _gamePresenter.onInputPlayersCountModel -= _questionnaireController.SetPlayersCountModel;
        _gamePresenter.onInputRemovePlayerModel -= _questionnaireController.RemovePlayerModel;
        _gamePresenter.onInputClearPlayerModel -= _questionnaireController.ClearPlayerModel;
        _gamePresenter.onInputAddNewAnswerModels -= _questionnaireController.AddPlayerModel;
        _gamePresenter.onInputAnswerModel -= _questionnaireController.SetAnswerModel;
        _gamePresenter.onInputQueueModel -= _queueSettingController.SetValueModel;

        Debug.Log("IsUnbinded");
    }

    private void SetSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        _databaseController.LoadData();
        _dataController.LoadData();
        _loadingPresenter.Loaded();
    }
    private void SetFocusChanged(bool focus)
    {
        if (!focus)
            _dataController.SaveData();
    }
    private void LoadDatabaseModel(DatabaseModel databaseModel)
    {
        _soundController.SetBoundsModel(databaseModel);
        _backgroundSettingController.SetValuesModel(databaseModel.Colors);
        _vignetteSettingController.SetBoundsModel(databaseModel.VignetteBounds);
        _fontSettingController.SetValuesModel(databaseModel.FontAssets);
        _presenterSettingController.SetValuesModel(databaseModel.Presenters);
        _questionsSettingController.SetValuesModel(databaseModel.QuestionsDatas);
        _queueSettingController.SetValuesModel(databaseModel.Queues);
        _questionnaireController.SetBoundsModel(databaseModel.PlayersBounds);
    }
    private void LoadDataModel(DataModel dataModel)
    {
        _soundController.SetValueModel(dataModel);
        _backgroundSettingController.SetDataModel(dataModel.Color);
        _vignetteSettingController.SetValueModel(dataModel.Vignette);
        _fontSettingController.SetDataModel(dataModel.Font);
        _presenterSettingController.SetDataModel(dataModel.Presenter);
        _questionsSettingController.SetDataModel(dataModel.questionsList);
        _questionnaireController.SetDataModel(dataModel);
        _storiesController.SetDataModel(dataModel);
        _queueSettingController.SetDataModel(dataModel.queueType);
    }
    private void SaveDataModel(ref DataModel dataModel)
    {
        _soundController.GetValueModel(ref dataModel);
        _backgroundSettingController.GetDataModel(ref dataModel.Color);
        _vignetteSettingController.GetValueModel(ref dataModel.Vignette);
        _fontSettingController.GetDataModel(ref dataModel.Font);
        _presenterSettingController.GetDataModel(ref dataModel.Presenter);
        _questionsSettingController.GetDataModel(ref dataModel.questionsList);
        _questionnaireController.GetDataModel(ref dataModel);
        _storiesController.GetDataModel(ref dataModel);
        _queueSettingController.GetDataModel(ref dataModel.queueType);
    }
}
