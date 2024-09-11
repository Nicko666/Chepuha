using TMPro;
using UnityEngine;

namespace Data.Database
{
    public class SettingsDatabase
    {
        public readonly Color[] Colors;
        public readonly TMP_FontAsset[] FontAssets;
        public readonly float MaxVolume;

        public SettingsDatabase(Color[] colors, TMP_FontAsset[] fontAssets, float maxVolume) 
        {
            Colors = colors;
            FontAssets = fontAssets;
            MaxVolume = maxVolume;
        }
    }
}