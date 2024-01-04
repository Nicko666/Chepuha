using UnityEngine;

public abstract class SettingsVolumeView : InitView<SettingsVolumeViewModel>
{
    protected SettingsVolumeViewModel viewModel;


    public override void Init(SettingsVolumeViewModel viewModel)
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
