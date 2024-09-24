using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

namespace Presenters.Stories
{
    internal class StoryPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text storyName;
        [SerializeField] private TMP_Text storyText;
        [SerializeField] private Button button;

        public event Action<StoryPresenter> onSaveRequest;

        public string StoryName
        {
            set { storyName.text = value; }
        }

        public string StoryText
        {
            get { return storyText.text; }
            set { storyText.text = value; }
        }
        
        public bool IsSaved
        {
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
