using TMPro;
using UnityEngine;

public class TextFont : MonoBehaviour
{
    //[SerializeField] List<TMP_Text> _texts;
    [SerializeField] TMP_Text _text;
    SettingsManager _settingsManager;
    SettingsEventsManager _settingsEvents;

    private void Awake()
    {
        if (_text == null) _text = GetComponent<TMP_Text>();
        
        _settingsManager = SettingsManager.Instance;
        _settingsEvents = SettingsEventsManager.Instance;

    }

    private void OnEnable()
    {
        _settingsEvents.OnFontChange += OnFontChenge;

        OnFontChenge(_settingsManager.Font);

    }

    private void OnDisable()
    {
        _settingsEvents.OnFontChange -= OnFontChenge;

    }

    //List<TMP_Text> FindAllTexts()
    //{
    //    IEnumerable<TMP_Text> texts = FindObjectsOfType<TMP_Text>();

    //    return new(texts);
    //}

    void OnFontChenge(TMP_FontAsset font)
    {
        _text.font = font;

    }


}
