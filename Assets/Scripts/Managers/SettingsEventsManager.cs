using System;
using UnityEngine;
using TMPro;

public class SettingsEventsManager : Singleton<SettingsEventsManager>
{
    public Action<float> OnVolumeChange;

    public Action<Color> OnColorChange;

    public Action<TMP_FontAsset> OnFontChange;


    public void OnVolumeChangeNotify(float value) => OnVolumeChange?.Invoke(value);

    public void OnColorChangeNotify(Color color) => OnColorChange?.Invoke(color);

    public void OnFontChangeNotify(TMP_FontAsset font) => OnFontChange?.Invoke(font);


}
