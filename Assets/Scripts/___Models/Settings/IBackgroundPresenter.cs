using System;
using UnityEngine;

namespace Models.Settings
{
    public abstract class IBackgroundPresenter : MonoBehaviour
    {
        public abstract event Action<int> onBackgroundRequest;
        public abstract void OnBackgroundChanged(int backgroundIndex);
        public abstract void OnBackgroundAssetsChanged(Color[] backgroundAssets);
    }
}
