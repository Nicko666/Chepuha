using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : Window
{
    [SerializeField] Button _players;
    [SerializeField] Button _queType;
    [SerializeField] Button _play;
    [SerializeField] Button _settings;
    [SerializeField] Button _saved;
    [SerializeField] Button _quit;

    protected override void Awake()
    {
        base.Awake();

        _players.onClick.AddListener(Players);
        _queType.onClick.AddListener(QueType);
        _play.onClick.AddListener(Play);
        _settings.onClick.AddListener(Settings);
        _saved.onClick.AddListener(Saved);
        _quit.onClick.AddListener(Quit);

    }

    public override void OnEscape() => _windowsManager.ShowСonfirmationMessage(Quit, Open, "Выйти из игры?");

    public override void OnEscapeHold() => Quit();

    void Players() => _gameManager.ChangePlayersAndQue(_gameManager.Players.Length + 1, _gameManager.Que.ByPlayer);

    void QueType() => _gameManager.ChangeQue(!_gameManager.Que.ByPlayer);

    void Play() => _windowsManager.OpenWindow(2);

    void Saved() => _windowsManager.OpenWindow(4);

    void Settings() => _windowsManager.OpenWindow(1);

    void Quit() => Application.Quit();

    
}
