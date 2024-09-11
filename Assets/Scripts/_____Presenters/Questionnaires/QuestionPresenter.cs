using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace Presenters.Questionnaires
{
    public class QuestionPresenter : MonoBehaviour
    {
        private System.Random _random;
        private string[] _randomAnswers;

        [SerializeField] private TMP_Text questionText;
        [SerializeField] private InputField answerInputField;
        [SerializeField] private Button randomAnswerButton;

        public Action<string> onInputAnswer;

        private void Start()
        {
            answerInputField.onValueChanged.AddListener(onInputAnswer.Invoke);
            randomAnswerButton.onClick.AddListener(InputRandomAnswer);
        }

        public QuestionPresenter(string question, string[] randomAnswers, System.Random random)
        {
            questionText.text = question;
            _randomAnswers = randomAnswers;
            _random = random;
            InputRandomAnswer();
        }

        public void InputRandomAnswer() =>
            answerInputField.text = _randomAnswers[_random.Next(_randomAnswers.Length)];

        private void OnDestroy()
        {
            answerInputField.onValueChanged.RemoveListener(onInputAnswer.Invoke);
            randomAnswerButton.onClick.RemoveListener(InputRandomAnswer);
        }
    }
}
