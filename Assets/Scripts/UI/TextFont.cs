using TMPro;
using UnityEngine;

public class TextFont : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    
    private void Awake()
    {
        //FontManager.Instance.OnFontChange += OnFontChenge;

    }

    void OnFontChenge(TMP_FontAsset font)
    {
        //text.font = font;

    }


}
