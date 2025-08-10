using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class NewQuestionPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _questionText;
    [SerializeField] private TMP_InputField _answerInputField;
    [SerializeField] private Button _randomAnswerButton;

    private string[] _randomAnswers;
    private StringBuilder _answerModel;

    internal Action<StringBuilder, string> onInputAnswerChanged;
    internal Action<StringBuilder> onInputAnswerSubmit;

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
        _answerInputField.onEndEdit.AddListener(InputAnswerChanged);
        //_answerInputField.onTouchScreenKeyboardStatusChanged
        _answerInputField.onSubmit.AddListener(InputAnswerSubmit);
        _answerInputField.onSelect.AddListener(OutputAnserSelected);
        _randomAnswerButton.onClick.AddListener(InputRandomAnswer);
    }
    private void OnDestroy()
    {
        _answerInputField.onEndEdit.RemoveListener(InputAnswerChanged);
        _answerInputField.onSubmit.RemoveListener(InputAnswerSubmit);
        _answerInputField.onSelect.RemoveListener(OutputAnserSelected);
        _randomAnswerButton.onClick.RemoveListener(InputRandomAnswer);
    }

    private void InputAnswerChanged(string text) =>
        onInputAnswerChanged.Invoke(_answerModel, text);
    
    private void InputRandomAnswer()
    {
        string randomAnswer = _randomAnswers[UnityEngine.Random.Range(0, _randomAnswers.Length)];
        onInputAnswerChanged.Invoke(_answerModel, randomAnswer);
    }

    internal void OutputSelectAnswer() =>
        _answerInputField.Select();

    private void InputAnswerSubmit(string text) =>
        onInputAnswerSubmit.Invoke(_answerModel);

    private void OutputAnserSelected(string text) =>
        _answerInputField.MoveToEndOfLine(false, false);
}