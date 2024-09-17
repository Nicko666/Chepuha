using System;
using UnityEngine;

namespace Models.Questionnaires
{
    public abstract class ISavedStoriesPresenters : MonoBehaviour
    {
        public abstract event Action<string[]> onSavedStoriesChanged;
        public abstract void SetSaveStories(string[] savedStories);
        public abstract bool SaveStory(string story);
    }
}
