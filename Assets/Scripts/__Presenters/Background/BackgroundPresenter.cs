using Models.Settings;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters.Background
{
    public class BackgroundPresenter : IBackgroundPresenter
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private MaskableGraphic _background;
        private Color[] _backgroundAssets;

        public override event Action<int> onBackgroundRequest;

        private void Start() =>
            _slider.onValueChanged.AddListener(OnBackgroundRequest);

        public void OnBackgroundRequest(float index) =>
            onBackgroundRequest.Invoke((int)index);

        public override void OnBackgroundChanged(int backgroundIndex)
        {
            _background.color = _backgroundAssets[backgroundIndex];
            _slider.value = backgroundIndex;
        }

        public override void OnBackgroundAssetsChanged(Color[] backgroundAssets)
        {
            _backgroundAssets = backgroundAssets;
            _slider.maxValue = backgroundAssets.Length - 1;
        }

        private void OnDestroy() =>
            _slider.onValueChanged.RemoveListener(OnBackgroundRequest);
    }
}