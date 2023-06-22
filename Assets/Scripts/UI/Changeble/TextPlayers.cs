using TMPro;
using UnityEngine;

public class TextPlayers : MonoBehaviour
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
         _gameEventManager.OnPlayersChange += ChangePlayers;

    }

    private void OnDisable()
    {
        _gameEventManager.OnPlayersChange -= ChangePlayers;

    }

    void ChangePlayers(int number)
    {
        string text = (number).ToString() + " игрок" + ((number > 1)? "а" : "");
        this._tmpText.text = text;

    }

    
}
