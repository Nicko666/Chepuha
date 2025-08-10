using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OldQuestionPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerText;
    [SerializeField] private TMP_Text _questionText;
    [SerializeField] private TMP_InputField _answerInputField;
    [SerializeField] private Button _randomAnswerButton;
    private StringBuilder _answerModel;
    string[] _randomAnswers;

    internal event Action<StringBuilder, string> onInputAnswerModel;

    internal void OutputQuestion(int playerIndex, QuestionModel question, StringBuilder answerModel)
    {
        _answerModel = answerModel;
        _randomAnswers = question.randomAnswers;

        _playerText.text = $"{playerIndex + 1}";
        _questionText.text = question.questionText;
        _answerInputField.SetTextWithoutNotify(_answerModel.ToString());
        _answerInputField.Select();
    }

    internal void OutputFontModel(TMP_FontAsset fontModel)
    {
        _playerText.font = fontModel;
        _questionText.font = fontModel;
        _answerInputField.fontAsset = fontModel;
    }

    private void Awake()
    {
        _answerInputField.onValueChanged.AddListener(InputAnswerModel);
        _randomAnswerButton.onClick.AddListener(InputRandomAnswer);
        _answerInputField.onSelect.AddListener(OutputAnserSelected);
    }

    private void OnDestroy()
    {
        _answerInputField.onValueChanged.RemoveListener(InputAnswerModel);
        _randomAnswerButton.onClick.RemoveListener(InputRandomAnswer);
        _answerInputField.onSelect.RemoveListener(OutputAnserSelected);
    }

    private void InputAnswerModel(string text) =>
        onInputAnswerModel.Invoke(_answerModel, text);

    private void InputRandomAnswer() =>
        onInputAnswerModel.Invoke(_answerModel, _randomAnswers[UnityEngine.Random.Range(0, _randomAnswers.Length)]);

    private void OutputAnserSelected(string text) =>
       _answerInputField.MoveToEndOfLine(false, false);
}
