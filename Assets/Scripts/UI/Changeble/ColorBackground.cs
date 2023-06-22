using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColorBackground : MonoBehaviour
{
    [SerializeField] Light2D light;

    SettingsManager _settingsManager;
    SettingsEventsManager _settingsEventsManager;

    private void Awake()
    {
        _settingsManager = SettingsManager.Instance;
        _settingsEventsManager = SettingsEventsManager.Instance;

    }

    private void OnEnable()
    {
        _settingsEventsManager.OnColorChange += OnColorChange;

        OnColorChange(_settingsManager.Color);

    }

    private void OnDisable()
    {
        _settingsEventsManager.OnColorChange -= OnColorChange;

    }

    void OnColorChange(Color color)
    {
        light.color = color;

    }


}
