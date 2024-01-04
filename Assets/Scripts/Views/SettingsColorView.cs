using UnityEngine;

public abstract class SettingsColorView : InitView<SettingsColorViewModel>
{
    protected SettingsColorViewModel viewModel;


    public override void Init(SettingsColorViewModel viewModel)
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
