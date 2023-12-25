using UnityEngine;

public class SoundManager : Singleton<SoundManager>, IDataPersistence
{
    [SerializeField] AudioSource _audioSource;

    float volume;


    public void LoadData(LocalData data)
    {
        ChangeVolume(data.Volume);

    }

    public void SaveData(ref LocalData data)
    {
        data.Volume = volume;

    }


    public void ChangeVolume(float value)
    {
        volume = value;

        _audioSource.volume = volume;

    }

    public void Play()
    {
        _audioSource.Play();

    }


}
