using System;
using UnityEngine;

public interface ISoundController : IDisposable
{
    public event Action<Vector2> onSoundValueBoundsChanged;
    public event Action<float> onSoundValueChanged;
    public event Action<AudioClip> onOutputSound;

    public void SetValueModel(DataModel dataModel);
    public void GetValueModel(ref DataModel dataModel);
    public void SetVolume(float value);
    public void OutputInput();
    public void SetBoundsModel(DatabaseModel model);
}
