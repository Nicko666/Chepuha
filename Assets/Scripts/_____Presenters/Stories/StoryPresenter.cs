using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

namespace Presenters.Stories
{
    internal class StoryPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text story;
        [SerializeField] private Button button;

        public event Action<StoryPresenter> onSaveRequest;

        public string Text
        {
            get { return story.text; }
            set { story.text = value; }
        }
        
        public bool IsSaved
        {
            get { return button.interactable!; }
            set { button.interactable = value!; }
        }

        private void Start() =>
            button.onClick.AddListener(OnRemoveRequest);

        private void OnRemoveRequest() =>
            onSaveRequest?.Invoke(this);
        
        private void OnDestroy() =>
            button.onClick.RemoveListener(OnRemoveRequest);
    }
}
