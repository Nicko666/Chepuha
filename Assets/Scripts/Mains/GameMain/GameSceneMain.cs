using TMPro;
using UnityEngine;

public class GameSceneMain : Main
{
    [SerializeField] private DatabaseModel _databaseModel;
    [SerializeField] private IGamePresenter _gamePresenter;
    [SerializeField] private ILoadingPresenter _loadingPresenter;

    private IDatabaseController _databaseController;
    private IDataController _dataController = new DataController();
    private ISoundController _soundController = new SoundController();
    private IListSettingController<Color> _backgroundSettingController = new ListSettingController<Color>();
    private IFloatSettingController _vignetteSettingController = new FloatSettingController();
    private IListSettingController<TMP_FontAsset> _fontSettingController = new ListSettingController<TMP_FontAsset>();
    private IListSettingController<int> _presenterSettingController = new ListSettingController<int>();
    private IListSettingController<QuestionsData> _questionsSettingController = new ListSettingController<QuestionsData>();
    private IListSettingController<int> _queueSettingController = new ListSettingController<int>();
    private IQuestionnaireController _questionnaireController = new QuestionnaireController();
    private IStoriesController _storiesController = new StoriesController();

    GameController _gameController;

    protected override void Awake()
    {
        _databaseController ??= new DatabaseController(_databaseModel);

        base.Awake();

        _gameController = new GameController(
            _databaseController,
            _dataController,
            _soundController,
            _backgroundSettingController,
            _vignetteSettingController,
            _fontSettingController,
            _presenterSettingController,
            _questionsSettingController,
            _queueSettingController,
            _questionnaireController,
            _storiesController,
            _gamePresenter,
            _loadingPresenter
        );
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();

        _gameController.Dispose();
        
        _databaseController.Dispose();
        _dataController.Dispose();
        _soundController.Dispose();
        _backgroundSettingController.Dispose();
        _vignetteSettingController.Dispose();
        _fontSettingController.Dispose();
        _presenterSettingController.Dispose();
        _questionsSettingController.Dispose();
        _questionnaireController.Dispose();
        _storiesController.Dispose();        
    }
}