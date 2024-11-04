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
        [SerializeField] private Button inputFieldButton;

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
            inputFieldButton.onClick.AddListener(Activate);
        }

        private void OnDestroy()
        {
            answerInputField.onSelect.RemoveListener(AnswerSelectInvoke);
            answerInputField.onValueChanged.RemoveListener(AnswerChangedInvoke);
            answerInputField.onSubmit.RemoveListener(AnswerSubmitInvoke);
            randomAnswerButton.onClick.RemoveListener(InputRandomAnswer);
            inputFieldButton.onClick.RemoveListener(Activate);
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
            answerInputField.ActivateInputField();
        }

        private void AnswerSelectInvoke(string text)
        {
            onAnswerSelect?.Invoke(transform.position);
        }

        private void AnswerChangedInvoke(string text)
        {
            onAnswerChanged?.Invoke();
        }

        private void AnswerSubmitInvoke(string text)
        {
            onAnswerSubmit?.Invoke(this);
        }

        private void InputRandomAnswer() =>
            answerInputField.text = _randomAnswers[_random.Next(_randomAnswers.Length)];
    }
}
