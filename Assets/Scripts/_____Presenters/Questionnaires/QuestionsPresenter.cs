using System;
using UnityEngine;
using UnityEngine.UI;
using Models.Questionnaires;
using System.Collections.Generic;

namespace Presenters.Questionnaires
{
    internal class QuestionsPresenter : MonoBehaviour
    {
        [SerializeField] private QuestionPresenter questionPrefab;
        [SerializeField] private Transform questionContent;
        private List<QuestionPresenter> _questions = new();
        [SerializeField] private Button removeButton;

        public Action<QuestionsPresenter> onRemoveRequest;
        public Action onAnswersChanged;

        public Action onAnswerRequest;

        public string GetAnswer(int index) => _questions[index].Answer;

        public bool IsRemovable
        {
            get { return removeButton.interactable; }
            set { removeButton.interactable = value; }
        }

        private void Awake() =>
            removeButton.onClick.AddListener(RemoveRequest);

        public void RemoveRequest() =>
            onRemoveRequest.Invoke(this);

        public void Init(QuestionModel[] questions, System.Random randomSystem)
        {
            foreach (var question in questions)
            {
                QuestionPresenter questionPresenter = Instantiate(questionPrefab, questionContent);
                questionPresenter.gameObject.SetActive(true);
                questionPresenter.Init(question.Question, question.Answers, randomSystem);
                questionPresenter.onInputAnswer += AnswersChangrRequest;
                _questions.Add(questionPresenter);
            }
        }

        private void AnswersChangrRequest()
        {
            
            onAnswersChanged.Invoke();
        }

        private void OnDestroy() =>
            removeButton.onClick.RemoveListener(RemoveRequest);
    }
}