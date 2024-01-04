using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameQuestionnaireMixedStoriesDOSlideTMPView : GameQuestionnaireMixedStoriesViewn
{
    [SerializeField] DOSlideTMP_Text textObject;
    [SerializeField] Selectable buttonNext;
    [SerializeField] Selectable buttonPrevious;
    [SerializeField] Selectable saveButton;
    [SerializeField] TMP_Text numberText;

    int length;
    int selectedIndex;

    public override void InputNextMixedStory()
    {
        OutputMixedStoryDirection(false);

        base.InputNextMixedStory();
    }
    public override void InputPreviousMixedStory()
    {
        OutputMixedStoryDirection(true);
        
        base.InputPreviousMixedStory();
    }

    protected override void OutputMixedStoriesLength(int value)
    {
        length = value;
        OutputSelectedMixedStoriyNumberText();
    }
    protected override void OutputSelectedMixedStoriyIndex(int value)
    {
        selectedIndex = value;
        OutputSelectedMixedStoriyNumberText();
    }
    void OutputSelectedMixedStoriyNumberText()
    {
        numberText.text = $"{selectedIndex + 1} / {length}";
    }

    protected override void OutputMixedStoryDirection(bool value)
    {
        textObject.invert = value;
    }
    protected override void OutputMixedStoryText(string value)
    {
        textObject.text = value;
    }

    protected override void OutputNextButtonInteractive(bool value)
    {
        buttonNext.interactable = !value;
    }
    protected override void OutputPreviousButtonInteractive(bool value)
    {
        buttonPrevious.interactable = !value;
    }

    protected override void OutputSelectedMixedStoryIsSaved(bool value)
    {
        saveButton.interactable = !value;
    }


}
