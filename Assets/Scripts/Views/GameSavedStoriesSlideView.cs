using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSavedStoriesSlideView : GameSavedStoriesView
{
    int lingth;
    int selectedIndex;

    [SerializeField] DOSlideTMP_Text textObject;
    [SerializeField] Selectable buttonNext;
    [SerializeField] Selectable buttonPrevious;
    [SerializeField] Selectable buttonDelete;
    [SerializeField] TMP_Text selectedIndexText;


    protected override void OutputMaxStoryIndex(int value)
    {
        lingth = value;
        OutputSelectedIndexText();
    }
    protected override void OutputSelectedStoryIndex(int value)
    {
        selectedIndex = value;
        OutputSelectedIndexText();
    }
    void OutputSelectedIndexText()
    {
        selectedIndexText.text = $"{selectedIndex+1}/{lingth}";
    }

    protected override void OutputIsFirst(bool value)
    {
        buttonPrevious.interactable = !value;
    }
    protected override void OutputIsLast(bool value)
    {
        buttonNext.interactable = !value;
    }

    protected override void OutputStoryText(string value)
    {
        if (value == null)
        {
            textObject.text = "Нет сохранённых историй";
            OutputDelete(false);
        }
        else
        {
            textObject.text = value;
            OutputDelete(true);
        }

    }
    protected override void OutputStoryDirection(bool value)
    {
        textObject.invert = value;

    }

    protected override void OutputDelete(bool value)
    {
        buttonDelete.interactable = value;

    }

    
}
