using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

internal class SettingsPresenter : MonoBehaviour
{
    [SerializeField] private ListSettingPresenter<TMP_FontAsset> _fontSettingPresenter;
    [SerializeField] private ListSettingPresenter<Color> _backgroundSettingPresenter;
    [SerializeField] private ListSettingPresenter<int> _presenterSettingPresenter;
    [SerializeField] private FloatSettingPresenter _volumeSettingPresenter;
    [SerializeField] private FloatSettingPresenter _vignetteSettingPresenter;

    internal Action<TMP_FontAsset> onInputFont;
    internal Action<Color> onInputBackground;
    internal Action<float> onInputVolume;
    internal Action<float> onInputVignette;
    internal Action<int> onInputPresenter;

    internal void OutputBackgroundsModel(List<Color> colors) =>
        _backgroundSettingPresenter.OutputValues(colors);
    internal void OutputBackgroundModel(Color color) =>
        _backgroundSettingPresenter.OutputValue(color);

    internal void OutputVignetteBoundsModel(Vector2 vignetteBoundsModel) => 
        _vignetteSettingPresenter.OutputBoundsModel(vignetteBoundsModel);
    internal void OutputVignetteModel(float vignetteModel) =>
        _vignetteSettingPresenter.OutputValueModel(vignetteModel);

    internal void OutputVolumeBoundsModel(Vector2 limits) =>
        _volumeSettingPresenter.OutputBoundsModel(limits);
    internal void OutputVolumeModel(float value) =>
        _volumeSettingPresenter.OutputValueModel(value);

    internal void OutputPresentersModel(List<int> values) =>
        _presenterSettingPresenter.OutputValues(values);
    internal void OutputPresenterModel(int value) =>
        _presenterSettingPresenter.OutputValue(value);

    internal void OutputFontsModel(List<TMP_FontAsset> fonts) =>
        _fontSettingPresenter.OutputValues(fonts);
    internal void OutputFontModel(TMP_FontAsset font)
    {
        _fontSettingPresenter.OutputValue(font);
        _fontSettingPresenter.OutputFont(font);
        _backgroundSettingPresenter.OutputFont(font);
        _volumeSettingPresenter.OutputFont(font);
        _vignetteSettingPresenter.OutputFont(font);
        _presenterSettingPresenter.OutputFont(font);
    }
    
    private void Awake()
    {
        _fontSettingPresenter.onValueChanged += InputFont;
        _backgroundSettingPresenter.onValueChanged += InputBackground;
        _volumeSettingPresenter.onValueChanged += InputVolume;
        _vignetteSettingPresenter.onValueChanged += InputVignette;
        _presenterSettingPresenter.onValueChanged += InputPresenter;
    }
    private void OnDestroy()
    {
        _fontSettingPresenter.onValueChanged -= InputFont;
        _backgroundSettingPresenter.onValueChanged -= InputBackground;
        _volumeSettingPresenter.onValueChanged -= InputVolume;
        _vignetteSettingPresenter.onValueChanged -= InputVignette;
        _presenterSettingPresenter.onValueChanged -= InputPresenter;
    }

    private void InputFont(TMP_FontAsset font) => 
        onInputFont.Invoke(font);
    private void InputBackground(Color color) => 
        onInputBackground.Invoke(color);
    private void InputVolume(float volume) => 
        onInputVolume.Invoke(volume);
    private void InputVignette(float value) => 
        onInputVignette.Invoke(value);
    private void InputPresenter(int value) => 
        onInputPresenter.Invoke(value);
}
