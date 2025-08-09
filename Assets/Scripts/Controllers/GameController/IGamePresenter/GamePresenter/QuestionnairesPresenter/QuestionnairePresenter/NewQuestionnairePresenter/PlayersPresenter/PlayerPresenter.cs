using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class PlayerPresenter : MonoBehaviour
{
    [SerializeField] private string _playerPrefix;
    [SerializeField] private TMP_Text _playerText;
    [SerializeField] private QuestionPresenter _questionPresenterPrefab;
    [SerializeField] private Transform _questionPresentersContent;
    [SerializeField] private Button _removePlayerButton;
    [SerializeField] private Button _clearPlayerButton;
    private TMP_FontAsset _fontModel;
    private List<(QuestionPresenter presenter, QuestionModel questionModel)> _questionPresenters = new();

    internal Action<StringBuilder, string> onInputAnswerChanged;
    internal Action<PlayerPresenter> onInputRemovePlayerModel;
    internal Action<PlayerPresenter> onInputClearPlayerModel;

    internal void OutputQuestionsModel(QuestionModel[] questionsModel)
    {
        while (_questionPresenters.Count < questionsModel.Length)
        {
            QuestionPresenter presenter;
            presenter = Instantiate(_questionPresenterPrefab, _questionPresentersContent);
            presenter.onInputAnswerChanged += InputAnswerChanged;
            presenter.onInputAnswerSelect += InputAnswerSelect;
            presenter.onInputAnswerSubmit += InputAnswerSubmit;
            _questionPresenters.Add(new (presenter, null));

            if (_fontModel != null) presenter.OutputFontModel(_fontModel);
        }

        while (_questionPresenters.Count > questionsModel.Length)
        {
            QuestionPresenter presenter = _questionPresenters[^1].presenter;
            presenter.onInputAnswerChanged -= InputAnswerChanged;
            presenter.onInputAnswerSelect -= InputAnswerSelect;
            presenter.onInputAnswerSubmit -= InputAnswerSubmit;
            Destroy(presenter.gameObject);
            _questionPresenters.RemoveAll(i => i.presenter == presenter);
        }

        for (int i = 0; i < questionsModel.Length; i++)
        {
            if (_questionPresenters[i].questionModel == questionsModel[i]) 
                continue;
            
            _questionPresenters[i].presenter.OutputQuestionModel(questionsModel[i]);
        }
    }

    internal void OutputAnswersModel(StringBuilder[] answersModel)
    {
        for (int i = 0; i < _questionPresenters.Count && i < answersModel.Length; i++)
            _questionPresenters[i].presenter.OutputAnswerModel(answersModel[i]);
    }

    internal void OutputFontModel(TMP_FontAsset fontModel)
    {
        _fontModel = fontModel;
        _playerText.font = _fontModel;
        _questionPresenters.ForEach(i => i.presenter.OutputFontModel(fontModel));
    }

    internal void OutputIndexModel(int i) =>
        _playerText.text = $"{_playerPrefix} {i + 1}";

    internal void OutputCanRemoveModel(bool canRemove) =>
        _removePlayerButton.interactable = canRemove;

    private void Awake()
    {
        _removePlayerButton.onClick.AddListener(InputRemovePlayerModel);
        _clearPlayerButton.onClick.AddListener(InputClearPlayerButton);
    }
    private void OnDestroy()
    {
        _removePlayerButton.onClick.RemoveListener(InputRemovePlayerModel);
        _clearPlayerButton.onClick.RemoveListener(InputClearPlayerButton);
    }

    private void InputAnswerChanged(StringBuilder answerModel, string text) =>
        onInputAnswerChanged(answerModel, text);

    private void InputAnswerSubmit(QuestionPresenter presenter)
    {
        
    }

    private void InputAnswerSelect(QuestionPresenter presenter)
    {
        
    }

    private void InputRemovePlayerModel() =>
        onInputRemovePlayerModel.Invoke(this);

    private void InputClearPlayerButton() =>
        onInputClearPlayerModel.Invoke(this);
}
