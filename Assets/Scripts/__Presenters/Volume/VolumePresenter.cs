using System;
using UnityEngine;
using UnityEngine.UI;
using Models.Settings;

namespace Presenters.Volume
{
    public class VolumePresenter : IVolumePresenter
    {
        [SerializeField] AudioSource _audioSource;
        [SerializeField] Slider _volumeSlider;

        public override event Action<float> onVolumeRequest;

        private void Start() =>
            _volumeSlider.onValueChanged.AddListener(VolumeRequest);

        private void VolumeRequest(float value) =>
            onVolumeRequest?.Invoke(value);

        public override void OnMaxVolumeChanged(float maxVolume) =>
            _volumeSlider.maxValue = maxVolume;
        
        public override void OnVolumeChanged(float volume)
        {
            _audioSource.volume = volume;
            _volumeSlider.value = volume;
        }

        private void OnDestroy() =>
            _volumeSlider.onValueChanged.RemoveListener(VolumeRequest);
    }
}