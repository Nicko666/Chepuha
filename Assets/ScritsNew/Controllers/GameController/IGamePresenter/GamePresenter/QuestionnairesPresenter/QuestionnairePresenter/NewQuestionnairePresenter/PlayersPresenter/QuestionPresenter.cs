using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class QuestionPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _questionText;
    [SerializeField] private TMP_InputField _answerInputField;
    [SerializeField] private Button _randomAnswerButton;
    [SerializeField] private Button _inputFieldButton;

    private string[] _randomAnswers;
    private StringBuilder _answerModel;

    internal Action<StringBuilder, string> onInputAnswerChanged;
    internal Action<QuestionPresenter> onInputAnswerSubmit;
    internal Action<QuestionPresenter> onInputAnswerSelect;

    internal void OutputQuestionModel(QuestionModel questionModel)
    {
        _questionText.text = questionModel.questionText;
        _randomAnswers = questionModel.randomAnswers;
    }

    internal void OutputAnswerModel(StringBuilder answerModel)
    {
        _answerModel = answerModel;
        _answerInputField.SetTextWithoutNotify(_answerModel.ToString());
    }

    internal void OutputFontModel(TMP_FontAsset fontModel)
    {
        _questionText.font = fontModel;
        _answerInputField.fontAsset = fontModel;
    }

    private void Awake()
    {
        _answerInputField.onSelect.AddListener(InputAnswerSelect);
        _answerInputField.onValueChanged.AddListener(InputAnswerChanged);
        _answerInputField.onSubmit.AddListener(InputAnswerSubmit);
        _randomAnswerButton.onClick.AddListener(InputRandomAnswer);
        _inputFieldButton.onClick.AddListener(_answerInputField.Select);
    }
    private void OnDestroy()
    {
        _answerInputField.onSelect.RemoveListener(InputAnswerSelect);
        _answerInputField.onValueChanged.RemoveListener(InputAnswerChanged);
        _answerInputField.onSubmit.RemoveListener(InputAnswerSubmit);
        _randomAnswerButton.onClick.RemoveListener(InputRandomAnswer);
        _inputFieldButton.onClick.RemoveListener(_answerInputField.Select);
    }

    private void InputAnswerSelect(string text) =>
        onInputAnswerSelect.Invoke(this);

    private void InputAnswerChanged(string text) =>
        onInputAnswerChanged.Invoke(_answerModel, text);

    private void InputAnswerSubmit(string text) =>
        onInputAnswerSubmit.Invoke(this);

    private void InputRandomAnswer() =>
        _answerInputField.text = _randomAnswers[UnityEngine.Random.Range(0, _randomAnswers.Length)];
}