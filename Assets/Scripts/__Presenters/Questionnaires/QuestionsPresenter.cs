using System;
using UnityEngine;
using UnityEngine.UI;
using Models.Questionnaires;
using System.Collections.Generic;
using TMPro;

namespace Presenters.Questionnaires
{
    internal class QuestionsPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private QuestionPresenter questionPrefab;
        [SerializeField] private Transform questionContent;
        private List<QuestionPresenter> _questions = new();
        [SerializeField] private Button clearButton;
        [SerializeField] private Button removeButton;

        public Action<QuestionsPresenter> onRemoveRequest;
        public Action onAnswersChanged;
        public Action<Vector3> onFocusRequest;
        public Action<QuestionsPresenter> onLastQuestionChanged;
        public string NameText { set { nameText.text = value; } }
        public string GetAnswer(int index) => _questions[index].GetAnswer();

        public bool IsRemovable
        {
            get { return removeButton.interactable; }
            set { removeButton.interactable = value; }
        }

        private void Awake()
        {
            removeButton.onClick.AddListener(RemoveRequest);
            clearButton.onClick.AddListener(ClearRequest);
        }

        private void OnDestroy()
        {
            removeButton.onClick.RemoveListener(RemoveRequest);
            clearButton.onClick.RemoveListener(ClearRequest);
        }

        public void Init(QuestionModel[] questionModels, System.Random randomSystem)
        {
            foreach (var question in questionModels)
            {
                QuestionPresenter questionPresenter = Instantiate(questionPrefab, questionContent);
                questionPresenter.Init(question.Question, question.Answers, randomSystem);
                questionPresenter.onAnswerSelect += FocusAnswe;
                questionPresenter.onAnswerChanged += InvokeAnswersChanged;
                questionPresenter.onAnswerSubmit += ActivateNextAnswer;
                _questions.Add(questionPresenter);
            }
        }

        public void ClearRequest() 
        {
            foreach (QuestionPresenter questionPresenter in _questions)
                questionPresenter.InputEmpryAnswer();
        }

        private void RemoveRequest() =>
            onRemoveRequest.Invoke(this);

        private void InvokeAnswersChanged() =>
            onAnswersChanged?.Invoke();

        private void ActivateNextAnswer(QuestionPresenter questionPresenter)
        {
            int index = _questions.IndexOf(questionPresenter);

            if (index == _questions.Count - 1)
                onLastQuestionChanged.Invoke(this);
            else
            {
                QuestionPresenter nextQuestion = _questions[index + 1];
                nextQuestion.Activate();
                //onFocusRequest.Invoke(nextQuestion.transform.position);
            }
        }

        private void FocusAnswe(Vector3 position) =>
            onFocusRequest.Invoke(position);

        internal void ActivateFirstAnswer() =>
            _questions[0].Activate();
    }
}