using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class SavedStoryPresenter : MonoBehaviour
{
    [SerializeField] private Button _removeButton;
    [SerializeField] private TMP_Text _storyText;

    internal Action<SavedStoryPresenter> onInputRemove;

    internal void Output(StringBuilder _storyModel) =>
        _storyText.text = _storyModel.ToString();

    internal void OutputFont(TMP_FontAsset fontModel) =>
        _storyText.font = fontModel;

    private void Awake() =>
        _removeButton.onClick.AddListener(InputRemove);
    private void OnDestroy() =>
        _removeButton.onClick.RemoveListener(InputRemove);

    private void InputRemove() =>
        onInputRemove.Invoke(this);
}
