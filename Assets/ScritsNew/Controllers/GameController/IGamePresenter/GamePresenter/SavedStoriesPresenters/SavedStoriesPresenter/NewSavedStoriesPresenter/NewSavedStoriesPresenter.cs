using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

internal class NewSavedStoriesPresenter : SavedStoriesPresenter
{
    [SerializeField] private SavedStoryPresenter _savedStoryPresenterPrefab;
    [SerializeField] private Transform _savedStoryPresentersContent;
    private TMP_FontAsset _font;
    private List<(SavedStoryPresenter presenter, StringBuilder storyModel)> _savedStoryPresenters = new();

    internal override event Action<StringBuilder> onInputSavedStoryModelRemove;

    internal override void OutputSavedStories(List<StringBuilder> storyModels)
    {
        while (storyModels.Count > _savedStoryPresenters.Count)
        {
            SavedStoryPresenter savedStoryPresenter;
            savedStoryPresenter = Instantiate(_savedStoryPresenterPrefab, _savedStoryPresentersContent);
            savedStoryPresenter.onInputRemove += InputSavedStoryModelRemove;
            _savedStoryPresenters.Add(new (savedStoryPresenter, null));

            if (_font != null) savedStoryPresenter.OutputFont(_font);
        }
        while (storyModels.Count < _savedStoryPresenters.Count)
        {
            SavedStoryPresenter savedStoryPresenter = _savedStoryPresenters[^1].presenter;
            savedStoryPresenter.onInputRemove -= InputSavedStoryModelRemove;
            Destroy(savedStoryPresenter.gameObject);
            _savedStoryPresenters.Remove(_savedStoryPresenters[^1]);
        }

        for (int i = 0; i < storyModels.Count; i++)
        {
            if (_savedStoryPresenters[i].storyModel != storyModels[i])
            {
                _savedStoryPresenters[i] = new(_savedStoryPresenters[i].presenter, storyModels[i]);
                _savedStoryPresenters[i].presenter.Output(_savedStoryPresenters[i].storyModel);
            }
        }
    }

    internal override void OutputFont(TMP_FontAsset font)
    {
        _font = font;
        _savedStoryPresenters.ForEach(i => i.presenter.OutputFont(_font));
    }

    private void InputSavedStoryModelRemove(SavedStoryPresenter savedStoryPresenter) =>
        onInputSavedStoryModelRemove.Invoke(_savedStoryPresenters.Find(i => i.presenter == savedStoryPresenter).storyModel);
}