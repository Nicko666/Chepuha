using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWindow : Window
{
    [SerializeField] TMP_Text _playerName;
    [SerializeField] TMP_Text _qwestion;
    [SerializeField] TMP_InputField _inputField;

    [SerializeField] Button _input;
    [SerializeField] Button _back;

    TouchScreenKeyboard _keyboard;

    protected override void Awake()
    {
        base.Awake();

        _input.onClick.AddListener(OnInput);
        _back.onClick.AddListener(OnBack);

        _inputField.onEndEdit.AddListener(OnEndEdit);

        _keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        _keyboard.active = false;

    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _gameEventManager.OnPositionChange += OnPositionChange;

        OnPositionChange(_gameManager.Que.Players[_gameManager.Position], _gameManager.Que.Questions[_gameManager.Position]);

    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _gameEventManager.OnPositionChange -= OnPositionChange;

    }

    public override void OnEscape() => OnBack();

    public override void OnEscapeHold() => _windowsManager.OpenWindow(0);

    public void OnEndEdit(string text)
    {
        //Save(text);

        _inputField.text = text;

        if (_keyboard.status == TouchScreenKeyboard.Status.Done)
        {
            OnInput();

        }

    }

    void OnInput()
    {
        Save(_inputField.text);

        _gameManager.ChangePosition(_gameManager.Position + 1);

        _inputField.ActivateInputField();

    }

    void OnBack()
    {
        Save(_inputField.text);
        
        _gameManager.ChangePosition(_gameManager.Position - 1);

    }

    void OnPositionChange(Player player, string qwestion)
    {
        _playerName.text = $"Игрок {player.name}";

        _qwestion.text = qwestion;

        _inputField.text = player.answers[Array.IndexOf(new Form().Questions, qwestion)];

    }

    void Save(string text)
    {
        _gameManager.Que.Players[_gameManager.Position].answers[Array.IndexOf(new Form().Questions, _gameManager.Que.Questions[_gameManager.Position])] = text;

    }

}
