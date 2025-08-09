using System;
using UnityEngine;

public class SoundController : ISoundController
{
    private AudioClip _clickAudioClip;
    private Vector2 _volumeBounds;
    private float _volume;

    public event Action<Vector2> onSoundValueBoundsChanged;
    public event Action<float> onSoundValueChanged;
    public event Action<AudioClip> onOutputSound;

    public void SetValueModel(DataModel dataModel) =>
        onSoundValueChanged?.Invoke(_volume = dataModel.Volume);
    public void GetValueModel(ref DataModel dataModel) =>
        dataModel.Volume = _volume;
    public void SetBoundsModel(DatabaseModel databaseModel)
    {
        _clickAudioClip = databaseModel.ClickAudioClip;
        onSoundValueBoundsChanged?.Invoke(_volumeBounds = databaseModel._volumeBounds);
    }

    public void SetVolume(float value) =>
        onSoundValueChanged?.Invoke(_volume = value);

    public void OutputInput() =>
        onOutputSound.Invoke(_clickAudioClip);
    
    public void Dispose() { }
}
