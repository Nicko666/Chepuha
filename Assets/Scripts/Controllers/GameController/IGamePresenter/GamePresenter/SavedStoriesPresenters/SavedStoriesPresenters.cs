using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

internal class SavedStoriesPresenters : MonoBehaviour
{
    [SerializeField] private SavedStoriesPresenter[] _savedStoriesPresenters;
    
    internal Action<StringBuilder> onInputSavedStoryModelRemove;

    private void Awake()
    {
        foreach (SavedStoriesPresenter savedStoriesPresenter in _savedStoriesPresenters)
            savedStoriesPresenter.onInputSavedStoryModelRemove += InputSavedStoryModelRemove;
    }
    private void OnDestroy()
    {
        foreach (SavedStoriesPresenter savedStoriesPresenter in _savedStoriesPresenters)
            savedStoriesPresenter.onInputSavedStoryModelRemove -= InputSavedStoryModelRemove;
    }

    internal void OutputFontModel(TMP_FontAsset font)
    {
        foreach (SavedStoriesPresenter savedStoriesPresenter in _savedStoriesPresenters)
            savedStoriesPresenter.OutputFont(font);
    }

    internal void OutputSavedStories(List<StringBuilder> savedStoriesModel)
    {
        foreach (SavedStoriesPresenter savedStoriesPresenter in _savedStoriesPresenters)
            savedStoriesPresenter.OutputSavedStories(savedStoriesModel);
    }

    private void InputSavedStoryModelRemove(StringBuilder stringBuilder) =>
        onInputSavedStoryModelRemove?.Invoke(stringBuilder);

    internal void OutputPresenterModel(int value)
    {
        for (int i = 0; i < _savedStoriesPresenters.Length; i++)
            _savedStoriesPresenters[i].gameObject.SetActive(i == value);
    }
}
