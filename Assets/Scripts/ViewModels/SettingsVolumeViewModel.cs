public class SettingsVolumeViewModel : SettingsViewModel
{
    public ReactiveProperty<float> volume = new();


    public SettingsVolumeViewModel(SettingsModel model) : base(model)
    {
        ViewModelUpdate();
    }

    protected override void ViewModelSubscribe()
    {
        model.volume.onValueChanged += OutputVolume;
    }

    protected override void ViewModelUnsubscribe()
    {
        model.volume.onValueChanged -= OutputVolume;
    }

    void ViewModelUpdate()
    {
        OutputVolume(model.volume.Value);
    }


    public void InputVolume(float value)
    {
        model.volume.Value = value;
    }

    void OutputVolume(float value)
    {
        volume.Value = value;
    }


}