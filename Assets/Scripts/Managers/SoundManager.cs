using Unity.Mathematics;
using UnityEngine;


public class SoundManager : Singleton<SoundManager>, IDataPersistence
{
    [SerializeField] AudioSource _audioSource;

    public float MaxVolume { get; private set; } = 1;

    public float Volume { get; private set; } = 0;


    public void LoadData(Data data)
    {
        ChangeVolume(data.Volume);

    }

    public void SaveData(ref Data data)
    {
        data.Volume = Volume;

    }

    public void Play()
    {
        _audioSource.Play();

    }

    public void ChangeVolume(float value)
    {
        value = math.clamp(value, 0, MaxVolume);

        Volume = value;

        _audioSource.volume = Volume;
  
    }


}
