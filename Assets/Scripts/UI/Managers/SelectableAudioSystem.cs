using UnityEngine;

public class SelectableAudioSystem : Singleton<SelectableAudioSystem>
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip buttonSound;
    [SerializeField] AudioClip inputSound;

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }

    public void PlayInputSound()
    {
        audioSource.PlayOneShot(inputSound);
    }


}
