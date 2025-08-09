using System;
using UnityEngine;
using UnityEngine.UI;

internal class UIPanelButtonPresenter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _highliteBool;

    internal Action<UIPanelButtonPresenter> onInput;

    internal void Output(bool value) =>
        _animator.SetBool(_highliteBool, value);

    private void Awake() =>
        _button.onClick.AddListener(Input);
    private void OnDestroy() =>
        _button.onClick.RemoveListener(Input);

    private void Input() =>
        onInput.Invoke(this);
}
