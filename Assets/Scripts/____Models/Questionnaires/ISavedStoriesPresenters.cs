using System;
using UnityEngine;

namespace Models.Questionnaires
{
    public abstract class ISavedStoriesPresenters : MonoBehaviour
    {
        public abstract event Action<string[]> onSavedStoriesRequest;
        public abstract void OnSavedStoriesChanged(string[] savedStories);
    }
}
