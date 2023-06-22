using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class SettingsManager : Singleton<SettingsManager>, IDataPersistence
{
    SettingsEventsManager _settingsEvents;


    public Color[] colors;

    public TMP_FontAsset[] fontAssets;
    

    public Color Color { get; private set; }

    public TMP_FontAsset Font { get; private set; }


    private void Awake()
    {
        _settingsEvents = SettingsEventsManager.Instance;
        
    }

    public void LoadData(Data data)
    {
        ChangeColor(data.Color);
        ChangeFont(data.Font);

    }

    public void SaveData(ref Data data)
    {
        data.Color = Array.IndexOf(colors, Color);
        data.Font = Array.IndexOf(fontAssets, Font);

    }

    public void ChangeColor(int value)
    {
        value = math.clamp(value, 0, colors.Length - 1);

        Color = colors[value];

        _settingsEvents.OnColorChangeNotify(Color);

    }

    public void ChangeFont(int value)
    {
        value = math.clamp(value, 0, fontAssets.Length - 1);

        Font = fontAssets[value];

        _settingsEvents.OnFontChangeNotify(Font);

    }


}
