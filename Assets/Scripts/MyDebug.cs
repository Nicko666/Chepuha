using TMPro;
using UnityEngine;

public class MyDebug : Singleton<MyDebug>
{
    [SerializeField] TMP_Text textLine;


    public void Log(string text)
    {
        if (textLine != null)
            textLine.text += text + "\n";
    }


}
