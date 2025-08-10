using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class NewStoriesPresenter : MonoBehaviour
{
    [SerializeField] private StoryPresenter _storyPresenterPrefab;
    [SerializeField] private RectTransform _storyPresentersContent;
    [SerializeField] private string _prefix;
    private List<(StoryPresenter presenter, StringBuilder storyModel)> _storyPresenters = new();
    private List<StringBuilder> _savedStoriesModel = new();
    private TMP_FontAsset _fontModel;

    internal Action<StringBuilder> onInputSaveStoryModel;

    internal void OutputCreatedStoriesModel(List<StringBuilder> storiesModel)
    {
        while (_storyPresenters.Count < storiesModel.Count)
        {
            StoryPresenter presenter = Instantiate(_storyPresenterPrefab, _storyPresentersContent);
            presenter.onInputRemoveStory += InputSaveStory;
            (StoryPresenter presenter, StringBuilder storyModel) storyPresenter = new(presenter, null);
            _storyPresenters.Add(storyPresenter);
            
        }
        while (_storyPresenters.Count > storiesModel.Count)
        {
            (StoryPresenter presenter, StringBuilder storyModel) storyPresenter = _storyPresenters[^1];
            storyPresenter.presenter.onInputRemoveStory -= InputSaveStory;
            _storyPresenters.Remove(storyPresenter);
            Destroy(storyPresenter.presenter.gameObject);
        }

        for (int i = 0; i < storiesModel.Count; i++)
        {
            _storyPresenters[i] = new(_storyPresenters[i].presenter, storiesModel[i]);
            if (_fontModel != null) _storyPresenters[i].presenter.OutputFontModel(_fontModel);
            _storyPresenters[i].presenter.OutputStoryModel(storiesModel[i]);
            _storyPresenters[i].presenter.OutputHeader($"{_prefix} {i + 1}");
            _storyPresenters[i].presenter.OutputIsSaved(_savedStoriesModel.Contains(_storyPresenters[i].storyModel));
        }
    }

    internal void OutputFontModel(TMP_FontAsset fontModel)
    {
        _fontModel = fontModel;
        _storyPresenters.ForEach(i => i.presenter.OutputFontModel(fontModel));
    }
    internal void OutputSavedStories(List<StringBuilder> storiesModel)
    {
        _savedStoriesModel = storiesModel;
        _storyPresenters.ForEach(i => i.presenter.OutputIsSaved(_savedStoriesModel.Contains(i.storyModel)));
    }

    private void InputSaveStory(StoryPresenter presenter) =>
        onInputSaveStoryModel.Invoke(_storyPresenters.Find(i => i.presenter == presenter).storyModel);
}