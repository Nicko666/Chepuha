using Data.Database;
using TMPro;
using UnityEngine;

namespace DataHandlers.ObjectData
{
    [CreateAssetMenu]
    public class SettingsDatabseObject : ScriptableObject, IDatabaseHandler<SettingsDatabase>
    {
        public Color[] colors;
        public TMP_FontAsset[] fontAssets;
        public float maxVolume;

        public SettingsDatabase Load()
        {
            return new SettingsDatabase(colors, fontAssets, maxVolume);
        }
    }
}
