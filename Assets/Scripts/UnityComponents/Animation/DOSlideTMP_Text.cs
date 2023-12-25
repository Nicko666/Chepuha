using TMPro;
using UnityEngine;

public class DOSlideTMP_Text : DOSlideRects
{
    [SerializeField] TMP_Text currentText;
    [SerializeField] TMP_Text nextText;
   

    public virtual string text 
    {
        get { return currentText.text; }
        set 
        { 
            nextText.text = value; 
            Next(); 
        }
    }

    public override void Next()
    {
        base.Next();

        var temp = currentText;
        currentText = nextText;
        nextText = temp;

    }


}
