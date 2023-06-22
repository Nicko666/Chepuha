using TMPro;
using UnityEngine;

public class TextQue : MonoBehaviour
{
    TMP_Text _tmpText;
    GameEventManager _gameEventManager;

    private void Awake()
    {
        _tmpText = GetComponentInChildren<TMP_Text>();

        _gameEventManager = GameEventManager.Instance;

    }

    private void OnEnable()
    {
        _gameEventManager.OnQueTypeChange += OnQueTypeChange;

    }

    private void OnDisable()
    {
        _gameEventManager.OnQueTypeChange -= OnQueTypeChange;

    }

    void OnQueTypeChange(bool byStory)
    {   
        this._tmpText.text = byStory? "по истории" : "по игроку";

    }


}
