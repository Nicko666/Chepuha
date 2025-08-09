using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class OldSavedStoriesPresenter : SavedStoriesPresenter
{
    [SerializeField] private Pages _pages;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private TMP_Text _deleteButtonTexts;
    [SerializeField] private TMP_Text _storyText;
    [SerializeField] private string _noPagesText;
    private List<StringBuilder> _storyModels = new();
    private int _currentPage = 0;

    internal override event Action<StringBuilder> onInputSavedStoryModelRemove;

    internal override void OutputFont(TMP_FontAsset font)
    {
        _storyText.font = font;
        _deleteButtonTexts.font = font;
        _pages.OutputFont(font);
    }

    internal override void OutputSavedStories(List<StringBuilder> storyModels)
    {
        _storyModels = storyModels;
        _currentPage = Math.Clamp(_currentPage, 0, _storyModels.Count - 1);

        _storyText.text = _storyModels.Count > 0? _storyModels[_currentPage].ToString() : _noPagesText;
        _deleteButton.interactable = _storyModels.Count > 0;

        _pages.OutputPages(_currentPage, _storyModels.Count);
    }

    private void Awake()
    {
        _pages.onInputPageChangeValue += InputPageChange;
        _deleteButton.onClick.AddListener(DeletePage);
    }
    private void OnDestroy()
    {
        _pages.onInputPageChangeValue -= InputPageChange;
        _deleteButton.onClick.RemoveListener(DeletePage);
    }

    private void InputPageChange(int value)
    {
        _currentPage = Math.Clamp(_currentPage + value, 0, _storyModels.Count - 1);
        _storyText.text = _storyModels[_currentPage].ToString();
        _pages.OutputPages(_currentPage, _storyModels.Count);
    }

    private void DeletePage() =>
        onInputSavedStoryModelRemove.Invoke(_storyModels[_currentPage]);
}