using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _storyHeader;
    [SerializeField] private TMP_Text _storyText;
    [SerializeField] private Button _storySaveButton;

    public event Action<StoryPresenter> onInputRemoveStory;

    internal void OutputIsSaved(bool value) =>
        _storySaveButton.interactable = !value;

    internal void OutputFontModel(TMP_FontAsset fontModel)
    {
        _storyHeader.font = fontModel;
        _storyText.font = fontModel;
    }

    internal void OutputStoryModel(StringBuilder stringBuilder) =>
        _storyText.text = stringBuilder.ToString();
        
    internal void OutputHeader(string text) =>
        _storyHeader.text = text;

    private void Start() =>
        _storySaveButton.onClick.AddListener(InputRemoveStory);
    private void OnDestroy() =>
        _storySaveButton.onClick.RemoveListener(InputRemoveStory);

    private void InputRemoveStory() =>
        onInputRemoveStory.Invoke(this);
}
