using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using Models.Questionnaires;

namespace Presenters.Questionnaires
{
    public class QuestionnairePresenter : IQuestionnairePresenter
    {
        QuestionModel[] _questionModels;

        private int _minPlayersNumber;
        private int _maxPlayersNumber;
        private int _playersNumber;
        private List<QuestionsView> _questionsViews;
        [SerializeField] private QuestionsView questionsViewPrefab;
        [SerializeField] private Transform questionsViewContent;

        string[] _savedStories;
        private List<QuestionsStoryView> _questionsStoryViews;
        [SerializeField] private QuestionsStoryView questionsStoryViewPrefab;
        [SerializeField] private Transform questionsStoryContent;

        public override event Action<int> onPlayersNumberRequest;
        public override event Action<string[]> onSavedStoriesRequest;

        public override void OnQuestionnaireChanged(QuestionModel[] questionModels) =>
            _questionModels = questionModels;

        public override void OnMinPlayersNumberChanged(int value) =>
            _minPlayersNumber = value;

        public override void OnMaxPlayersNumberChanged(int value) =>
            _maxPlayersNumber = value;

        public override void OnPlayersNumberChanged(int playersNumber)
        {
            _playersNumber = Math.Clamp(playersNumber, _minPlayersNumber, _maxPlayersNumber);

            UpdateQuestionsViews();
        }

        public override void OnSavedStoriesChanged(string[] savedStories)
        {
            _savedStories = savedStories;

            UpdateQuestionsViews();
        }

        public void SaveStory(string story)
        {
            List<string> newSavedStories = new();
            newSavedStories.AddRange(_savedStories);
            newSavedStories.Add(story);
            onSavedStoriesRequest?.Invoke(_savedStories);
        }

        private void UpdateQuestionsViews()
        {


            while (_playersNumber > _questionsViews.Count)
                _questionsViews.Add(new QuestionsView());
            while (_playersNumber < _questionsViews.Count)
                _questionsViews.Remove(_questionsViews[_questionsViews.Count - 1]);
            
            
            foreach (var savedStory in _savedStories)
                foreach (var storyViews in _questionsStoryViews)
                    storyViews.SetIsSaveable(storyViews.Story != savedStory);
        }
    }

    public class QuestionsView
    {
        public Action<int> saveStory;

        private QuestionPresenter questionPrefab;
        private Transform content;
        private QuestionPresenter[] questions;

        public QuestionsView() 
        {
            

        }

        private string[] _questions;
        private string[] _stories;
        
        public void OnSave()
        {
            // hide save button
        }
    }

    public class QuestionsStoryView : MonoBehaviour
    {
        private TMP_Text _storyText;
        private Button _saveButton;

        public Action onSaveInput;

        public string Story
        {
            get => _storyText.text;
            set => _storyText.text = value;
        }

        private void Start() =>
            _saveButton.onClick.AddListener(onSaveInput.Invoke);

        public void SetIsSaveable(bool value) =>
            _saveButton.interactable = value;

        private void OnDestroy() =>
            _saveButton.onClick.RemoveListener(onSaveInput.Invoke);
    }

}