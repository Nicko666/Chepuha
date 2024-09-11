using Data.Player;
using Data.Database;

namespace Models.Settings 
{
    public class SettingsModel : IUseData<PlayerData>, IUseDatabase<SettingsDatabase>
    {
        private float _volume;
        private IVolumePresenter _volumeUser;

        private int _fontIndex;
        private IFontPresenter _fontUser;
        
        private int _backgroundIndex;
        private IBackgroundPresenter _backgroundUser;

        public SettingsModel(IVolumePresenter volumeUser, IFontPresenter fontUser, IBackgroundPresenter colorUser)
        {
            if (_volumeUser != null) _volumeUser.onVolumeRequest -= ChangeVolume;
            _volumeUser = volumeUser;
            if (_volumeUser != null) _volumeUser.onVolumeRequest += ChangeVolume;

            if (_fontUser != null) _fontUser.onFontRequest -= ChangeFont;
            _fontUser = fontUser;
            if (_fontUser != null) _fontUser.onFontRequest += ChangeFont;

            if (_backgroundUser != null) _backgroundUser.onBackgroundRequest -= ChangeBackground;
            _backgroundUser = colorUser;
            if (_backgroundUser != null) _backgroundUser.onBackgroundRequest += ChangeBackground;
        }

        public void LoadData(SettingsDatabase data)
        {
            _volumeUser.OnMaxVolumeChanged(data.MaxVolume);
            _fontUser.OnFontsAssetsChanged(data.FontAssets);
            _backgroundUser.OnBackgroundAssetsChanged(data.Colors);
        }

        public void LoadData(PlayerData data)
        {
            ChangeVolume(data.Volume);
            ChangeFont(data.Font);
            ChangeBackground(data.Color);
        }
        public void SaveData(ref PlayerData data)
        {
            data.Volume = _volume;
            data.Font = _fontIndex;
            data.Color = _backgroundIndex;
        }

        public void ChangeVolume(float volume)
        {
            _volume = volume;
            _volumeUser?.OnVolumeChanged(volume);
        }

        public void ChangeFont(int fontIndex)
        {
            _fontIndex = fontIndex;
            _fontUser?.OnFontChanged(fontIndex);
        }

        public void ChangeBackground(int backgroundIndex)
        {
            _backgroundIndex = backgroundIndex;
            _backgroundUser?.OnBackgroundChanged(backgroundIndex);
        }
    }
}