using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class NewPlayersPresenter : MonoBehaviour
{
    [SerializeField] private Button _addPlayerButton;
    [SerializeField] private NewPlayerPresenter _playerPresenterPrefab;
    [SerializeField] private Transform _playerPresentersContent;
    private List<(NewPlayerPresenter presenter, StringBuilder[] playerModel)> _playerPresenters = new ();
    private TMP_FontAsset _fontModel;

    internal Action<StringBuilder, string> onInputAnswerModel;
    internal Action<QuestionsData> onInputQuestionsModel;
    internal Action<int> onInputPlayersCountModel;
    internal Action onInputAddPlayerModels;
    internal Action<StringBuilder[]> onInputRemovePlayerModel;
    internal Action<StringBuilder[]> onInputClearPlayerModel;
    internal Action<RectTransform> onInputScroll;

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
            NewPlayerPresenter presenter = Instantiate(_playerPresenterPrefab, _playerPresentersContent);
            
            presenter.onInputAnswerChanged += InputAnswerChanged;
            presenter.onInputAnswerSubmit += InputAnswerSubmit;
            presenter.onInputClearPlayerModel += InputClearPlayerModel;
            presenter.onInputRemovePlayerModel += InputRemovePlayerModel;
            presenter.onInputScroll += InputScroll;
            
            if (_fontModel != null) presenter.OutputFontModel(_fontModel);
            _playerPresenters.Add(new (presenter, null));
        }
        while (_playerPresenters.Count > questionnaireModel.playersModel.Count)
        {
            NewPlayerPresenter presenter = _playerPresenters[^1].presenter;

            presenter.onInputAnswerChanged -= InputAnswerChanged;
            presenter.onInputAnswerSubmit -= InputAnswerSubmit;
            presenter.onInputClearPlayerModel -= InputClearPlayerModel;
            presenter.onInputRemovePlayerModel -= InputRemovePlayerModel;
            presenter.onInputScroll -= InputScroll;

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

    private void InputAnswerSubmit(StringBuilder answerModel)
    {
        var playerPresenter =
            _playerPresenters.Find(i => Array.Exists(i.playerModel, j => j == answerModel));

        int answeIndex = Array.IndexOf(playerPresenter.playerModel, answerModel);

        if (playerPresenter.playerModel.Length - 1 > answeIndex)
            playerPresenter.presenter.OutputSelectAnswer(playerPresenter.playerModel[answeIndex + 1]);
    }

    private void InputAddPlayerModel() =>
        onInputAddPlayerModels.Invoke();

    private void InputRemovePlayerModel(NewPlayerPresenter presenter) =>
        onInputRemovePlayerModel.Invoke(_playerPresenters.Find(i => i.presenter == presenter).playerModel);
    
    private void InputClearPlayerModel(NewPlayerPresenter presenter) =>
        onInputClearPlayerModel.Invoke(_playerPresenters.Find(i => i.presenter == presenter).playerModel);

    private void InputScroll(RectTransform rectTransform) =>
        onInputScroll.Invoke(rectTransform);
}
