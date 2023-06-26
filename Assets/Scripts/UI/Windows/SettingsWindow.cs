using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : Window
{
    [SerializeField] Slider[] _sliders;

    [SerializeField] Button _volume;
    [SerializeField] Slider _volumeSlider;
    [SerializeField] Button _color;
    [SerializeField] Slider _colorSlider;
    [SerializeField] Button _font;
    [SerializeField] Slider _fontSlider;
    [SerializeField] Button _menu;

    SettingsManager _settingsManager;

    protected override void Awake()
    {
        base.Awake();

        _settingsManager = SettingsManager.Instance;

        _volumeSlider.onValueChanged.AddListener(OnVolume);
        _colorSlider.onValueChanged.AddListener(OnColor);
        _fontSlider.onValueChanged.AddListener(OnFont);
        _menu.onClick.AddListener(OnMenu);

    }

    public override void OnEscape() => _windowsManager.OpenWindow(0);

    public override void OnEscapeHold() => Application.Quit();

    protected override void OnEnable()
    {
        base.OnEnable();

        _volumeSlider.maxValue = SoundManager.Instance.MaxVolume;
        _volumeSlider.SetValueWithoutNotify(SoundManager.Instance.Volume);
        _colorSlider.maxValue = _settingsManager.colors.Length - 1;
        _colorSlider.SetValueWithoutNotify(Array.IndexOf(_settingsManager.colors, _settingsManager.Color));
        _fontSlider.maxValue = _settingsManager.fontAssets.Length - 1;
        _fontSlider.SetValueWithoutNotify(Array.IndexOf(_settingsManager.fontAssets, _settingsManager.Font));

    }

    void OnVolume(float value) => SoundManager.Instance.ChangeVolume(value);

    void OnColor(float value) => _settingsManager.ChangeColor(Mathf.RoundToInt(value));

    void OnFont(float value) => _settingsManager.ChangeFont(Mathf.RoundToInt(value));

    public void OnMenu() => _windowsManager.OpenWindow(0);


}
