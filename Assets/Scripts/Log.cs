using TMPro;
using UnityEngine;

public class Log : Singleton<Log>
{
    [SerializeField] TMP_Text textLine;

    public void WriteLine(string text)
    {
        textLine.text += text + "\n";
    }


}
