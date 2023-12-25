using UnityEngine;
using UnityEngine.UI;

public class GameQuestionnaireMixedStoriesView : GameQuestionnaireView
{
    [SerializeField] DOSlideTMP_Text textObject;
    [SerializeField] Selectable buttonNext;
    [SerializeField] Selectable buttonPrevious;
    [SerializeField] Selectable saveButton;


    protected override void ViewModelSubscribe()
    {
        viewModel.selectedMixedStoryText.onValueChanged += OutputMixedStoryText;
        viewModel.selectedMixedStoryIsSaved.onValueChanged += OutputSelectedMixedStoryIsSaved;
        viewModel.isFirstMixedStory.onValueChanged += OutputPreviousButtonInteractive;
        viewModel.isLastMixedStory.onValueChanged += OutputNextButtonInteractive;
    }

    protected override void ViewModelUnsubscribe()
    {
        viewModel.selectedMixedStoryText.onValueChanged -= OutputMixedStoryText;
        viewModel.selectedMixedStoryIsSaved.onValueChanged -= OutputSelectedMixedStoryIsSaved;
        viewModel.isFirstMixedStory.onValueChanged -= OutputPreviousButtonInteractive;
        viewModel.isLastMixedStory.onValueChanged -= OutputNextButtonInteractive;
    }

    protected override void ViewModelUpdate()
    {
        OutputMixedStoryText(viewModel.selectedMixedStoryText.Value);
        OutputSelectedMixedStoryIsSaved(viewModel.selectedMixedStoryIsSaved.Value);
        OutputPreviousButtonInteractive(viewModel.isFirstMixedStory.Value);
        OutputNextButtonInteractive(viewModel.isLastMixedStory.Value);
    }

    
    public void InputNextMixedStory()
    {
        OutputMixedStoryDirection(false);
        viewModel.InputNextMixedStory();
    }
    public void InputPreviousMixedStory()
    {
        OutputMixedStoryDirection(true);
        viewModel.InputPreviousMixedStory();
    }
    void OutputMixedStoryDirection(bool value)
    {
        textObject.invert = value;
    }
    void OutputMixedStoryText(string value)
    {
        textObject.text = value;
    }
    void OutputNextButtonInteractive(bool value)
    {
        buttonNext.interactable = !value;
    }
    void OutputPreviousButtonInteractive(bool value)
    {
        buttonPrevious.interactable = !value;
    }

    public void InputSaveSelectedMixedStory()
    {
        viewModel.InputSaveMixedStory();
    }
    void OutputSelectedMixedStoryIsSaved(bool value)
    {
        saveButton.interactable = !value;
    }


}
