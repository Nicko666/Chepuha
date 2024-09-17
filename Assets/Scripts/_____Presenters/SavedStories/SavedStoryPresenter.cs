using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

namespace Presenters.SavedStories
{
    internal class SavedStoryPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text story;
        [SerializeField] private Button button;

        public event Action<SavedStoryPresenter> onRemoveRequest;

        public string Text
        {
            get { return story.text; }
            set { story.text = value; }
        }
        
        private void Start() =>
            button.onClick.AddListener(OnRemoveRequest);

        private void OnRemoveRequest() =>
            onRemoveRequest?.Invoke(this);
        
        private void OnDestroy() =>
            button.onClick.RemoveListener(OnRemoveRequest);
    }
}
