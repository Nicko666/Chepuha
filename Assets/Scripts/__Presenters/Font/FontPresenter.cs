using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Models.Settings;

namespace Presenters.Font
{
    public class FontPresenter : IFontPresenter
    {
        [SerializeField] Slider _slider;

        private TMP_FontAsset[] _fontsAssets;
        
        public override event Action<int> onFontRequest;

        private void Awake() =>
            _slider.onValueChanged.AddListener(OnFontRequest);

        public override void OnFontChanged(int fontIndex)
        {
            TMP_Text[] texts = FindObjectsOfType<MonoBehaviour>(true).OfType<TMP_Text>().ToArray();

            foreach (TMP_Text text in texts)
                text.font = _fontsAssets[fontIndex];

            _slider.wholeNumbers = true;
            _slider.value = fontIndex;
        }

        public override void OnFontsAssetsChanged(TMP_FontAsset[] fontsAssets)
        {
            _fontsAssets = fontsAssets;
            _slider.maxValue = _fontsAssets.Length - 1;
        }
        
        private void OnFontRequest(float value) =>
            onFontRequest?.Invoke((int)value);

        private void OnDestroy() =>
            _slider.onValueChanged.RemoveListener(OnFontRequest);
    }
}
