using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections;

namespace Presenters.Questionnaires
{
    public class QuestionPresenter : MonoBehaviour
    {
        private System.Random _random;
        private string[] _randomAnswers;

        [SerializeField] private TMP_Text questionText;
        [SerializeField] private TMP_InputField answerInputField;
        [SerializeField] private Button randomAnswerButton;

        public Action onAnswerChanged;
        public Action<QuestionPresenter> onAnswerSubmit;
        public Action<Vector3> onAnswerSelect;

        public string GetAnswer() => answerInputField.text;

        private void Start()
        {
            answerInputField.onSelect.AddListener(AnswerSelectInvoke);
            answerInputField.onValueChanged.AddListener(AnswerChangedInvoke);
            answerInputField.onSubmit.AddListener(AnswerSubmitInvoke);
            randomAnswerButton.onClick.AddListener(InputRandomAnswer);
        }

        private void OnDestroy()
        {
            answerInputField.onSelect.RemoveListener(AnswerSelectInvoke);
            answerInputField.onValueChanged.RemoveListener(AnswerChangedInvoke);
            answerInputField.onSubmit.RemoveListener(AnswerSubmitInvoke);
            randomAnswerButton.onClick.RemoveListener(InputRandomAnswer);
        }

        public void Init(string question, string[] randomAnswers, System.Random randomSystem)
        {
            questionText.text = question;
            _randomAnswers = randomAnswers;
            _random = randomSystem;

            InputEmpryAnswer();
        }

        public void InputEmpryAnswer() =>
            answerInputField.text = "";

        public void Activate()
        {
            answerInputField.Select();
        }

        private void AnswerSelectInvoke(string text)
        {
            onAnswerSelect?.Invoke(transform.position);
            Debug.Log($"AnswerSelectInvoke: {text}");
        }

        private void AnswerChangedInvoke(string text)
        {
            onAnswerChanged?.Invoke();
            Debug.Log($"AnswerChangedInvoke: {text}");
        }

        private void AnswerSubmitInvoke(string text)
        {
            onAnswerSubmit?.Invoke(this);
            Debug.Log($"AnswerSubmitInvoke: {text}");
        }

        private void InputRandomAnswer() =>
            answerInputField.text = _randomAnswers[_random.Next(_randomAnswers.Length)];
    }
}
