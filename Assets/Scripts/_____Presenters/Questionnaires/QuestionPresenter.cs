using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Text;

namespace Presenters.Questionnaires
{
    public class QuestionPresenter : MonoBehaviour
    {
        private System.Random _random;
        private string[] _randomAnswers;

        [SerializeField] private TMP_Text questionText;
        [SerializeField] private TMP_InputField answerInputField;
        [SerializeField] private Button randomAnswerButton;

        public Action onInputAnswer;

        public string Answer => answerInputField.text;

        private void Start()
        {
            answerInputField.onValueChanged.AddListener(InputAnswer);
            randomAnswerButton.onClick.AddListener(InputRandomAnswer);
        }

        public void Init(string question, string[] randomAnswers, System.Random randomSystem)
        {
            questionText.text = question;
            _randomAnswers = randomAnswers;
            _random = randomSystem;

            InputRandomAnswer();
        }

        private void InputAnswer(string text) =>
            onInputAnswer?.Invoke();

        public void InputRandomAnswer() =>
            answerInputField.text = _randomAnswers[_random.Next(_randomAnswers.Length)];

        private void OnDestroy()
        {
            answerInputField.onValueChanged.RemoveListener(InputAnswer);
            randomAnswerButton.onClick.RemoveListener(InputRandomAnswer);
        }
    }
}
