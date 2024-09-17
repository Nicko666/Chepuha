using UnityEngine;
using System;
using System.Collections.Generic;
using Models.Questionnaires;
using System.Text;

namespace Presenters.Stories
{
    public class StoriesPresenter : IStoriesPresenter
    {
        private QuestionModel[] _questionModels;

        [SerializeField] private StoryPresenter storyPrefab;
        [SerializeField] private Transform storyContent;
        private List<StoryPresenter> _stories = new();

        public override event Predicate<string> onSaveStoryRequest;

        public override void SetQuestionnaire(QuestionModel[] questionModels) =>
            _questionModels = questionModels;

        public override void SetAnswers(string[,] answers)
        {
            StringBuilder[] stories = new StringBuilder[answers.GetLength(0)];
            
            for (int i = 0; i < stories.Length; i++)
            {
                int playerAnswerNumber = i;

                stories[i] = new StringBuilder();

                for (int j = 0; j < answers.GetLength(1); j++)
                {
                    stories[i].Append(answers[playerAnswerNumber, j]);
                    stories[i].Append(_questionModels[j].TextAfter);
                    playerAnswerNumber = (playerAnswerNumber >= answers.GetLength(0)) ? 0 : playerAnswerNumber++;
                }
            }

            for (int i = 0; i < _stories.Count; i++)
                RemoveStory(_stories[i]);
            for (int i = 0; i < stories.Length; i++)
                AddStory(stories[i].ToString());
        }

        private void AddStory(string story)
        {
            StoryPresenter newStory = Instantiate(storyPrefab, storyContent);
            newStory.Text = story;
            newStory.onSaveRequest += SaveRequest;
            _stories.Add(newStory);
        }

        private void RemoveStory(StoryPresenter storyPresenter)
        {
            _stories.Remove(storyPresenter);
            storyPresenter.onSaveRequest -= SaveRequest;
            Destroy(storyPresenter.gameObject);
        }

        private void SaveRequest(StoryPresenter storyPresenter) =>
             storyPresenter.IsSaved = onSaveStoryRequest.Invoke(storyPresenter.Text);
    }
}