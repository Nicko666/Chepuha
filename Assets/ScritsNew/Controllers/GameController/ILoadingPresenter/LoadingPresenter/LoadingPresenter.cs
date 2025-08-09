using UnityEngine;

public class LoadingPresenter : ILoadingPresenter
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _isLoadingBool;

    public override void Loaded() =>
        _animator?.SetBool(_isLoadingBool, true);
    public override void Unloaded() =>
        _animator?.SetBool(_isLoadingBool, true);
}
