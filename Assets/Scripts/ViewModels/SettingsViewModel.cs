public abstract class SettingsViewModel
{
    protected SettingsModel model;


    public SettingsViewModel(SettingsModel model)
    {
        if (this.model != null)
            ViewModelUnsubscribe();

        this.model = model;

        if (this.model != null)
            ViewModelSubscribe();

    }

    protected abstract void ViewModelSubscribe();

    protected abstract void ViewModelUnsubscribe();


}