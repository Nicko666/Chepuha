using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using Models.Questionnaires;

namespace Presenters.SavedStories
{
    public class SavedStoriesPresenters : ISavedStoriesPresenters
    {
        [SerializeField] GameObject savedStoriesContent;
        [SerializeField] TMP_Text savedStoriesPrefab;
        [SerializeField] string[] _savedStories;

        public override event Action<string[]> onSavedStoriesRequest;

        public override void OnSavedStoriesChanged(string[] savedStories)
        {
            this._savedStories = savedStories;
        }

        public void RemoveSavedStory(string story)
        {
            List<string> newSavedStories = new();
            newSavedStories.AddRange(_savedStories);
            newSavedStories.Remove(story);

            onSavedStoriesRequest?.Invoke(_savedStories);
        }
    }
}