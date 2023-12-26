using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsFontFinderView : SettingsFontView
{
    [SerializeField] TMP_Text[] texts;
    [SerializeField] Slider slider;


    private void Awake()
    {
        texts = FindObjectsOfType<MonoBehaviour>(true).OfType<TMP_Text>().ToArray();
    }

    public override void OutputMaxIndex(int value)
    {
        slider.maxValue = value;
    }

    public override void OutputSelectedFont(TMP_FontAsset value)
    {
        foreach (TMP_Text text in texts)
            text.font = value;
    }

    public override void OutputSelectedFontIndex(int value)
    {
        slider.value = value;
    }


}
