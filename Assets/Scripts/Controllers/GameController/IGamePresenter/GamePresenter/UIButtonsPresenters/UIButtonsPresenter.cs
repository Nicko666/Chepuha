using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
internal class UIButtonsPresenter : MonoBehaviour
{
    [SerializeField] private List<UIPanelButtonPresenter> _uiButtonPresenters;

    internal Action<int> onInput;

    internal void Output(int index) =>
        _uiButtonPresenters.ForEach(i => i.Output(_uiButtonPresenters.IndexOf(i) == index));    

    private void Awake() =>
        _uiButtonPresenters.ForEach(i => i.onInput += Input);
    private void OnDestroy() =>
        _uiButtonPresenters.ForEach(i => i.onInput -= Input);

    private void Input(UIPanelButtonPresenter uIButtonPresenter) =>
        onInput.Invoke(_uiButtonPresenters.IndexOf(uIButtonPresenter));
}
