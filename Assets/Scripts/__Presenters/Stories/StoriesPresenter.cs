using UnityEngine;
using System;
using System.Collections.Generic;
using Models.Questionnaires;
using System.Text;
using UnityEngine.Pool;

namespace Presenters.Stories
{
    public class StoriesPresenter : IStoriesPresenter
    {
        private QuestionModel[] _questionModels;

        [SerializeField] private string prefix;
        [SerializeField] private StoryPresenter storyPrefab;
        [SerializeField] private Transform storyContent;
        private List<StoryPresenter> _stories = new();

        IObjectPool<StoryPresenter> pool;

        public override event Predicate<string> onSaveStoryRequest;

        public override void SetQuestionnaire(QuestionModel[] questionModels) =>
            _questionModels = questionModels;

        public override void SetAnswers(string[,] answers)
        {
            for (int i = _stories.Count - 1; i >= 0; i--)
                RemoveStory(_stories[i]);
            
            int playersCount = answers.GetLength(0);
            int answersCount = answers.GetLength(1);

            StringBuilder[] stories = new StringBuilder[playersCount];
            for (int i = 0; i < playersCount; i++)
            {
                stories[i] = new StringBuilder();
                int tempPlayerNumber = i;
                for (int j = 0; j < answersCount; j++)
                {
                    stories[i].Append(answers[tempPlayerNumber % playersCount, j]);
                    stories[i].Append(_questionModels[j].TextAfter);
                    
                    tempPlayerNumber++;
                }
            }
            
            for (int i = 0; i < stories.Length; i++)
                AddStory(stories[i].ToString(), i);
        }

        private void AddStory(string story, int index)
        {
            StoryPresenter newStory = Instantiate(storyPrefab, storyContent);
            newStory.StoryText = story;
            newStory.onSaveRequest += SaveRequest;
            newStory.StoryName = $"{prefix} {index + 1}";
            _stories.Add(newStory);
        }

        private void RemoveStory(StoryPresenter storyPresenter)
        {
            _stories.Remove(storyPresenter);
            storyPresenter.onSaveRequest -= SaveRequest;
            Destroy(storyPresenter.gameObject);
        }

        private void SaveRequest(StoryPresenter storyPresenter) =>
             storyPresenter.IsSaved = onSaveStoryRequest.Invoke(storyPresenter.StoryText);
    }
}