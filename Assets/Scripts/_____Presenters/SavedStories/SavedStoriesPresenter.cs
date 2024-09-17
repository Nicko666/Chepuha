using UnityEngine;
using System;
using System.Collections.Generic;
using Models.Questionnaires;

namespace Presenters.SavedStories
{
    public class SavedStoriesPresenter : ISavedStoriesPresenters
    {
        [SerializeField] private Transform savedStoriesContent;
        [SerializeField] private SavedStoryPresenter savedStoriesPrefab;
        private List<SavedStoryPresenter> _savedStories = new();

        public override event Action<string[]> onSavedStoriesChanged;

        public override void SetSaveStories(string[] savedStories)
        {
            for (int i = 0; i < savedStories.Length; i++)
                AddSavedStory(savedStories[i]);
        }

        public override bool SaveStory(string story)
        {
            AddSavedStory(story);
            return true;
        }

        private void AddSavedStory(string story)
        {
            SavedStoryPresenter savedStory = Instantiate(savedStoriesPrefab, savedStoriesContent);
            savedStory.Text = story;
            savedStory.onRemoveRequest += RemoveSavedStory;
            _savedStories.Add(savedStory);

            OnStoriesChanged();
        }

        private void RemoveSavedStory(SavedStoryPresenter savedStory)
        {
            _savedStories.Remove(savedStory);
            savedStory.onRemoveRequest -= RemoveSavedStory;
            Destroy(savedStory.gameObject);

            OnStoriesChanged();
        }

        private void OnStoriesChanged()
        {
            var savedStories = new string[_savedStories.Count];
            for (int i = 0; i < _savedStories.Count; i++)
                savedStories[i] = _savedStories[i].Text;

            onSavedStoriesChanged?.Invoke(savedStories);
        }
    }
}