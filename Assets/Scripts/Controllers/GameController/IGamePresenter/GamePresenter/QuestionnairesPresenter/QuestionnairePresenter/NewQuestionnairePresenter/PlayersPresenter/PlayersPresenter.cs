using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class PlayersPresenter : MonoBehaviour
{
    [SerializeField] private Button _addPlayerButton;
    [SerializeField] private PlayerPresenter _playerPresenterPrefab;
    [SerializeField] private Transform _playerPresentersContent;
    private List<(PlayerPresenter presenter, StringBuilder[] playerModel)> _playerPresenters = new ();
    private TMP_FontAsset _fontModel;

    internal Action<StringBuilder, string> onInputAnswerModel;
    internal Action<QuestionsData> onInputQuestionsModel;
    internal Action<int> onInputPlayersCountModel;
    internal Action onInputAddPlayerModels;
    internal Action<StringBuilder[]> onInputRemovePlayerModel;
    internal Action<StringBuilder[]> onInputClearPlayerModel;

    internal void OutputFontModel(TMP_FontAsset fontModel)
    {
        _fontModel = fontModel;
        
        if (_fontModel != null)
            _playerPresenters.ForEach(i => i.presenter.OutputFontModel(_fontModel));
    }

    internal void OutputQuestionnaireModel(QuestionnaireModel questionnaireModel)
    {
        while (_playerPresenters.Count < questionnaireModel.playersModel.Count)
        {
            PlayerPresenter presenter = Instantiate(_playerPresenterPrefab, _playerPresentersContent);
            
            presenter.onInputAnswerChanged += InputAnswerChanged;
            presenter.onInputClearPlayerModel += InputClearPlayerModel;
            presenter.onInputRemovePlayerModel += InputRemovePlayerModel;
            
            if (_fontModel != null) presenter.OutputFontModel(_fontModel);
            _playerPresenters.Add(new (presenter, null));
        }
        while (_playerPresenters.Count > questionnaireModel.playersModel.Count)
        {
            PlayerPresenter presenter = _playerPresenters[^1].presenter;

            presenter.onInputAnswerChanged -= InputAnswerChanged;
            presenter.onInputClearPlayerModel -= InputClearPlayerModel;
            presenter.onInputRemovePlayerModel -= InputRemovePlayerModel;

            _playerPresenters.Remove(_playerPresenters[^1]);
            Destroy(presenter.gameObject);
        }

        for (int i = 0; i < _playerPresenters.Count; i++)
        {
            _playerPresenters[i] = new(_playerPresenters[i].presenter, questionnaireModel.playersModel[i]);
            _playerPresenters[i].presenter.OutputIndexModel(i);
            _playerPresenters[i].presenter.OutputQuestionsModel(questionnaireModel.questionsModel);
            _playerPresenters[i].presenter.OutputAnswersModel(questionnaireModel.playersModel[i]);
            _playerPresenters[i].presenter.OutputCanRemoveModel(questionnaireModel.playersBoundsModel.x < questionnaireModel.playersModel.Count);
        }

        _addPlayerButton.interactable = questionnaireModel.playersBoundsModel.y > questionnaireModel.playersModel.Count;
    }

    private void Awake() =>
        _addPlayerButton.onClick.AddListener(InputAddPlayerModel);
    private void OnDestroy() =>
        _addPlayerButton.onClick.RemoveListener(InputAddPlayerModel);

    private void InputAnswerChanged(StringBuilder answerModel, string text) =>
        onInputAnswerModel.Invoke(answerModel, text);

    private void InputAddPlayerModel() =>
        onInputAddPlayerModels.Invoke();

    private void InputRemovePlayerModel(PlayerPresenter presenter) =>
        onInputRemovePlayerModel.Invoke(_playerPresenters.Find(i => i.presenter == presenter).playerModel);
    
    private void InputClearPlayerModel(PlayerPresenter presenter) =>
        onInputClearPlayerModel.Invoke(_playerPresenters.Find(i => i.presenter == presenter).playerModel);
}
