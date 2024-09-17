using UnityEngine;
using System;
using System.Collections.Generic;
using Models.Questionnaires;
using UnityEngine.UI;

namespace Presenters.Questionnaires
{
    public class QuestionnairePresenter : IQuestionnairePresenter
    {
        private QuestionModel[] _questionModels;
        private string[,] _answers;
        private System.Random _randomSystem = new System.Random();

        private int _minPlayersNumber;
        private int _maxPlayersNumber;
        private int _playersNumber;

        private List<QuestionsPresenter> _questions = new();
        [SerializeField] private Transform questionsContent;
        [SerializeField] private QuestionsPresenter questionPrefab;
        [SerializeField] private Button addPlayerButton;

        public override event Action<int> onPlayersNumberChanged;
        public override event Action<string[,]> onAnswersChanged;

        public override void SetQuestionnaire(QuestionModel[] questionModels) =>
            _questionModels = questionModels;

        public override void SetMinPlayersNumber(int value) =>
            _minPlayersNumber = value;

        public override void SetMaxPlayersNumber(int value) =>
            _maxPlayersNumber = value;

        public override void SetPlayersNumber(int playersNumber)
        {
            _playersNumber = Math.Clamp(playersNumber, _minPlayersNumber, _maxPlayersNumber);

            if (_questions.Count < _playersNumber)
                AddPlayer();
            if (_questions.Count > _playersNumber)
                RemovePlayer(_questions[_questions.Count - 1]);
        }

        private void Awake()
        {
            addPlayerButton.onClick.AddListener(AddPlayer);
        }

        private void AddPlayer()
        {
            QuestionsPresenter newQuestions = Instantiate(questionPrefab, questionsContent);
            _questions.Add(newQuestions);
            newQuestions.Init(_questionModels, _randomSystem);
            newQuestions.onRemoveRequest += RemovePlayer;

            onPlayersNumberChanged.Invoke(_questions.Count);

            OnPlayersNumberChanged();
        }

        private void RemovePlayer(QuestionsPresenter questions)
        {
            questions.onRemoveRequest -= RemovePlayer;
            _questions.Remove(questions);
            Destroy(questions.gameObject);

            onPlayersNumberChanged.Invoke(_questions.Count);
            
            OnPlayersNumberChanged();
        }

        private void OnPlayersNumberChanged()
        {
            UpdatePlayersButtons();

            string[,] answers = new string[_questions.Count, _questionModels.Length];
            for (int i = 0; i < answers.GetLength(0); i++)
                for (int j = 0; j < answers.GetLength(1); j++)
                    answers[i, j] = _questions[i].GetAnswer(j);

            onAnswersChanged.Invoke(answers);
        }

        private void UpdatePlayersButtons()
        {
            addPlayerButton.interactable = _questions.Count <= _maxPlayersNumber;

            foreach (var question in _questions)
                question.IsRemovable = _questions.Count >= _minPlayersNumber;
        }

        private void OnDestroy()
        {
            addPlayerButton.onClick.RemoveListener(AddPlayer);
        }
    }
}