using TMPro;
using UnityEngine;

public class TextScrollAnimation : MonoBehaviour
{
    [SerializeField] TMP_Text currentText;
    TMP_Text nextText;

    public Vector2 direction;

    [SerializeField] Canvas canvas;

    private void Awake()
    {
        
    }

    void Next(string text)
    {

    }

}
