using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class FontManager : Singleton<FontManager>, IDataPersistence
{
    public TMP_FontAsset[] fontAssets;

    public Action<TMP_FontAsset> OnFontChange;

    [Header("Current values")]
    public int fontIndex;


    public void LoadData(LocalData data)
    {
        ChangeFont(data.Font);
    
    }

    public void SaveData(ref LocalData data)
    {
        data.Font = fontIndex;

    }


    public void ChangeFont(int value)
    {
        fontIndex = math.clamp(value, 0, fontAssets.Length - 1);

        OnFontChange?.Invoke(fontAssets[fontIndex]);        
    
    }


}
