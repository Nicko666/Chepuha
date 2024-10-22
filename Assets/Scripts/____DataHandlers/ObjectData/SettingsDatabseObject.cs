using Data.Database;
using TMPro;
using UnityEngine;

namespace DataHandlers.ObjectData
{
    [CreateAssetMenu]
    public class SettingsDatabseObject : IDatabaseHandler<SettingsDatabase>
    {
        public Color[] colors;
        public TMP_FontAsset[] fontAssets;
        public float maxVolume;

        public override SettingsDatabase Load()
        {
            return new SettingsDatabase(colors, fontAssets, maxVolume);
        }
    }
}
