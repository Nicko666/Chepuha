using UnityEngine;

public abstract class SettingsVolumeView : MonoBehaviour
{
    protected SettingsVolumeViewModel viewModel;


    public virtual void Init(SettingsVolumeViewModel viewModel)
    {
        if (this.viewModel != null)
            ViewModelUnsubscribe();

        this.viewModel = viewModel;

        if (this.viewModel != null)
            ViewModelSubscribe();

    }

    protected abstract void ViewModelSubscribe();

    protected abstract void ViewModelUnsubscribe();


}
