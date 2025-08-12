using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SoundPresenter : MonoBehaviour
{
    [SerializeField] private AudioClip _clickAudioClip;
    [SerializeField] private AudioSource _uiAudioSource;

    private List<AudioClip> _audioClips = new();
    bool _isActive;

    private IEnumerator Start()
    {
        yield return null;

        _isActive = true;
    }

    internal void OutputVolume(float value) =>
        _uiAudioSource.volume = value;

    internal void OutputInputSound()
    {
        if (_isActive)
            StartCoroutine(OutputSoundAsync(_clickAudioClip));
    }

    private IEnumerator OutputSoundAsync(AudioClip audioClip)
    {
        _audioClips.Add(audioClip);

        if (_audioClips.Count > 1) yield break;

        yield return null;

        _uiAudioSource.PlayOneShot(_audioClips[0]);

        //Debug.Log($"Sound recuests count {_audioClips.Count}");
        _audioClips.Clear();
    }


}
