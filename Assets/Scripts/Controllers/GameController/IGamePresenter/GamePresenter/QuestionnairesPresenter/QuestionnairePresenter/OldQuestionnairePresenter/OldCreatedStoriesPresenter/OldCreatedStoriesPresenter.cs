using System.Collections.Generic;
using System.Text;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OldCreatedStoriesPresenter : MonoBehaviour
{
    [SerializeField] private OldCreatedStoriesPagesPresenter _pages;
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private TMP_Text _storyText;
    [SerializeField] private TMP_Text[] _fontTexts;
    [SerializeField] private string _noPagesText;

    private List<StringBuilder> _createdStoriesModel = new();
    private List<StringBuilder> _savedStoriesModel = new();
    private int _currentPage = 0;

    internal Action<StringBuilder> onInputAddSavedStoryModel;
    internal Action onInputSettings;

    internal void OutputFontModel(TMP_FontAsset fontModel)
    {
        foreach (TMP_Text text in _fontTexts)
            text.font = fontModel;

        _pages.OutputFont(fontModel);
    }

    internal void OutputSavedStoriesModel(List<StringBuilder> storiesModel)
    {
        _savedStoriesModel = storiesModel;
        
        _saveButton.interactable = _createdStoriesModel.Count > 0 ? !_savedStoriesModel.Contains(_createdStoriesModel[_currentPage]) : false;
    }

    internal void OutputCreatedStoriesModel(List<StringBuilder> storiesModel)
    {
        _createdStoriesModel = storiesModel;
        
        _currentPage = Math.Clamp(_currentPage, 0, _createdStoriesModel.Count - 1);

        _storyText.text = _createdStoriesModel.Count > 0 ? _createdStoriesModel[_currentPage].ToString() : _noPagesText;
        _saveButton.interactable =  _createdStoriesModel.Count > 0 ? !_savedStoriesModel.Contains(_createdStoriesModel[_currentPage]) : false;

        _pages.OutputPages(_currentPage, _createdStoriesModel.Count);
    }

    private void Awake()
    {
        _pages.onInputPageChangeValue += InputPageChange;
        _saveButton.onClick.AddListener(SavePage);
        _menuButton.onClick.AddListener(InputSettings);
    }

    private void OnDestroy()
    {
        _pages.onInputPageChangeValue -= InputPageChange;
        _saveButton.onClick.RemoveListener(SavePage);
        _menuButton.onClick.RemoveListener(InputSettings);
    }

    private void InputPageChange(int value)
    {
        _currentPage = Math.Clamp(_currentPage + value, 0, _createdStoriesModel.Count - 1);
        _storyText.text = _createdStoriesModel[_currentPage].ToString();
        _saveButton.interactable = _createdStoriesModel.Count > 0 ? !_savedStoriesModel.Contains(_createdStoriesModel[_currentPage]) : false;
        _pages.OutputPages(_currentPage, _createdStoriesModel.Count);
    }

    private void SavePage() =>
        onInputAddSavedStoryModel.Invoke(_createdStoriesModel[_currentPage]);

    private void InputSettings() =>
        onInputSettings.Invoke();
}
