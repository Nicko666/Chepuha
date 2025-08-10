using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class OldSavedStoriesPresenter : SavedStoriesPresenter
{
    [SerializeField] private OldSavedStoriesPagesControl _pagesControl;
    [SerializeField] private OldSavedStoryPresenter _currentStoryPresenter;
    //[SerializeField] private OldSavedStoryPresenter _previousStoryPresenter;
    [SerializeField] private TMP_Text[] _fontTexts;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private string _noPagesText;
    //[SerializeField] private Animator _pageAnimation;
    private List<StringBuilder> _storyModels = new();
    private int _currentPage = 0;

    //private const string DeleteTrigger = "Delete";
    //private const string NextPageTrigger = "Next";
    //private const string PreviousPageTrigger = "Previous";

    internal override event Action<StringBuilder> onInputSavedStoryModelRemove;

    internal override void OutputFont(TMP_FontAsset font)
    {
        Array.ForEach(_fontTexts, fontText => fontText.font = font);
        _pagesControl.OutputFont(font);
    }

    internal override void OutputSavedStories(List<StringBuilder> storyModels)
    {
        _storyModels = storyModels;
        _currentPage = Math.Clamp(_currentPage, 0, _storyModels.Count - 1);

        _currentStoryPresenter.OutputStory(_storyModels.Count > 0 ? _storyModels[_currentPage].ToString() : _noPagesText, 0);
        _deleteButton.interactable = _storyModels.Count > 0;

        _pagesControl.OutputPagesCount(_currentPage, _storyModels.Count);
    }

    private void Awake()
    {
        _pagesControl.onInputNextPage += NextPage;
        _pagesControl.onInputPreviousPage += PreviousPage;
        _deleteButton.onClick.AddListener(DeletePage);
        //_currentStoryPresenter.onStoryChanged += _previousStoryPresenter.OutputStory;
    }
    private void OnDestroy()
    {
        _pagesControl.onInputNextPage -= NextPage;
        _pagesControl.onInputPreviousPage -= PreviousPage;
        _deleteButton.onClick.RemoveListener(DeletePage);
        //_currentStoryPresenter.onStoryChanged -= _previousStoryPresenter.OutputStory;
    }

    private void PreviousPage() 
    {
        _currentPage = Math.Clamp(_currentPage - 1, 0, _storyModels.Count - 1);
        _currentStoryPresenter.OutputStory(_storyModels[_currentPage].ToString(), 0);
        //_pageAnimation?.SetTrigger(PreviousPageTrigger);
        _pagesControl.OutputPagesCount(_currentPage, _storyModels.Count);
    }

    private void NextPage() 
    {
        _currentPage = Math.Clamp(_currentPage + 1, 0, _storyModels.Count - 1);
        _currentStoryPresenter.OutputStory(_storyModels[_currentPage].ToString(), 0);
        //_pageAnimation?.SetTrigger(NextPageTrigger);
        _pagesControl.OutputPagesCount(_currentPage, _storyModels.Count);
    }

    private void DeletePage()
    {
        //_pageAnimation?.SetTrigger(DeleteTrigger);
        onInputSavedStoryModelRemove.Invoke(_storyModels[_currentPage]);
    }
}