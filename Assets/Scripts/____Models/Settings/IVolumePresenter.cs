using System;
using UnityEngine;

namespace Models.Settings
{
    public abstract class IVolumePresenter : MonoBehaviour
    {
        public abstract event Action<float> onVolumeRequest;
        public abstract void OnMaxVolumeChanged(float maxVolume);
        public abstract void OnVolumeChanged(float volume);
    }
}
