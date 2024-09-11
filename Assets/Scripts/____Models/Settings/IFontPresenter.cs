using System;
using TMPro;
using UnityEngine;

namespace Models.Settings
{
    public abstract class IFontPresenter : MonoBehaviour
    {
        public abstract event Action<int> onFontRequest;
        public abstract void OnFontChanged(int fontIndex);
        public abstract void OnFontsAssetsChanged(TMP_FontAsset[] fontsAssets);
    }
}
