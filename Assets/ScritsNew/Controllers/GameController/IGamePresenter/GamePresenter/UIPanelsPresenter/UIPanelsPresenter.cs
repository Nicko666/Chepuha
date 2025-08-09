using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
internal class UIPanelsPresenter : MonoBehaviour
{
    [SerializeField] private List<Animator> _animators;
    [SerializeField] private string _openBool;
    [SerializeField] private Animator _defaultAnimator;

    internal Action<int> onPanelChanged;

    internal void Output(int index)
    {
        _animators.ForEach(i => i.SetBool(_openBool, _animators.IndexOf(i) == index));
        onPanelChanged.Invoke(index);
    }

    private void Start()
    {
        _animators.ForEach(i => i.SetBool(_openBool, i == _defaultAnimator));
        onPanelChanged.Invoke(_animators.IndexOf(_defaultAnimator));
    }
}
