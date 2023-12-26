using UnityEngine;
using UnityEngine.UI;

public class SettingsVolumeSliderView : SettingsVolumeView
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource audioSource;

    public override void Init(SettingsVolumeViewModel viewModel)
    {
        base.Init(viewModel);

        ViewModelUpdate();

    }

    protected override void ViewModelSubscribe()
    {
        viewModel.volume.onValueChanged += OutputVolume;
    }

    protected override void ViewModelUnsubscribe()
    {
        viewModel.volume.onValueChanged -= OutputVolume;
    }

    protected void ViewModelUpdate()
    {
        OutputVolume(viewModel.volume.Value);
    }


    public void InputVolume(float value)
    {
        viewModel.InputVolume(value);
    }
    void OutputVolume(float value)
    {
        audioSource.volume = value;
        volumeSlider.value = value;
    }


}
