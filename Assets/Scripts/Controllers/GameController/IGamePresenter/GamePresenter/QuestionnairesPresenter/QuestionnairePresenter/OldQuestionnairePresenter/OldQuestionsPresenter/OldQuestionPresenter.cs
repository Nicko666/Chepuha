using System;
using System.Text;
using TMPro;
using UnityEngine;

public class OldQuestionPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerText;
    [SerializeField] private TMP_Text _questionText;
    [SerializeField] private TMP_InputField _answerInputField;
    private StringBuilder _answerModel;

    internal event Action<StringBuilder, string> onInputAnswerModel;

    internal void OutputQuestion(int playerIndex, QuestionModel question, StringBuilder answerModel)
    {
        _answerModel = answerModel;

        _playerText.text = $"{playerIndex + 1}";
        _questionText.text = question.questionText;
        _answerInputField.text = _answerModel.ToString();
        _answerInputField.Select();
    }

    private void Awake() =>
        _answerInputField.onValueChanged.AddListener(InputAnswerModel);
    private void OnDestroy() =>
        _answerInputField.onValueChanged.RemoveListener(InputAnswerModel);

    private void InputAnswerModel(string text) =>
        onInputAnswerModel.Invoke(_answerModel, text);

    internal void OutputFontModel(TMP_FontAsset fontModel)
    {
        _playerText.font = fontModel;
        _questionText.font = fontModel;
        _answerInputField.fontAsset = fontModel;
    }
}
