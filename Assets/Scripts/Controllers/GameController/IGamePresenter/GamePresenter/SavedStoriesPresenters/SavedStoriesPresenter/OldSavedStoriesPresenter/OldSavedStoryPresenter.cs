using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OldSavedStoryPresenter : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private TMP_Text _storyText;

    internal Action<string, float> onStoryChanged;

    internal void OutputStory(string text, float scrollValue)
    {
        onStoryChanged?.Invoke(_storyText.text, _scrollRect.verticalNormalizedPosition);

        _storyText.text = text;
        _scrollRect.verticalNormalizedPosition = scrollValue;
    }
}
