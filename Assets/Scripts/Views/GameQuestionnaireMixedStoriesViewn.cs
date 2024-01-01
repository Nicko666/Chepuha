using UnityEngine;

public abstract class GameQuestionnaireMixedStoriesViewn : MonoBehaviour, IInit<GameQuestionnaireSelectViewModel> 
{
    protected GameQuestionnaireSelectViewModel viewModel;


    public void Init(GameQuestionnaireSelectViewModel viewModel)
    {
        if (this.viewModel != null)
            ViewModelUnsubscribe();

        this.viewModel = viewModel;

        if (this.viewModel != null)
            ViewModelSubscribe();

        ViewModelUpdate();

    }

    void ViewModelSubscribe()
    {
        viewModel.selectedMixedStoryText.onValueChanged += OutputMixedStoryText;
        viewModel.selectedMixedStoryIsSaved.onValueChanged += OutputSelectedMixedStoryIsSaved;
        viewModel.isFirstMixedStory.onValueChanged += OutputPreviousButtonInteractive;
        viewModel.isLastMixedStory.onValueChanged += OutputNextButtonInteractive;
    }

    void ViewModelUnsubscribe()
    {
        viewModel.selectedMixedStoryText.onValueChanged -= OutputMixedStoryText;
        viewModel.selectedMixedStoryIsSaved.onValueChanged -= OutputSelectedMixedStoryIsSaved;
        viewModel.isFirstMixedStory.onValueChanged -= OutputPreviousButtonInteractive;
        viewModel.isLastMixedStory.onValueChanged -= OutputNextButtonInteractive;
    }

    void ViewModelUpdate()
    {
        OutputMixedStoryText(viewModel.selectedMixedStoryText.Value);
        OutputSelectedMixedStoryIsSaved(viewModel.selectedMixedStoryIsSaved.Value);
        OutputPreviousButtonInteractive(viewModel.isFirstMixedStory.Value);
        OutputNextButtonInteractive(viewModel.isLastMixedStory.Value);
    }


    public virtual void InputNextMixedStory()
    {
        viewModel.InputNextMixedStory();
    }

    public virtual void InputPreviousMixedStory()
    {
        viewModel.InputPreviousMixedStory();
    }

    protected abstract void OutputMixedStoryDirection(bool value);

    protected abstract void OutputMixedStoryText(string value);
    
    protected abstract void OutputNextButtonInteractive(bool value);
    
    protected abstract void OutputPreviousButtonInteractive(bool value);

    public virtual void InputSaveSelectedMixedStory()
    {
        viewModel.InputSaveMixedStory();
    }

    protected abstract void OutputSelectedMixedStoryIsSaved(bool value);
    

}