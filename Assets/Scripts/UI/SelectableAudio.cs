using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableAudio : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Selectable selectable;
    SelectableAudioSystem soundSystem;


    private void Awake()
    {
        soundSystem = SelectableAudioSystem.Instance;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (selectable.interactable)
            soundSystem.PlayButtonSound();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (selectable.interactable)
            soundSystem.PlayInputSound();
    }


}
