using UnityEngine;
using UnityEngine.UI;

public class GameSavedStoriesView : MonoBehaviour
{
    protected GameSavedStoriesViewModel viewModel;

    [SerializeField] DOSlideTMP_Text textObject;
    [SerializeField] Selectable buttonNext;
    [SerializeField] Selectable buttonPrevious;
    [SerializeField] Selectable buttonDelete;


    public void Init(GameSavedStoriesViewModel viewModel)
    {
        if (this.viewModel != null)
            ViewModelUnsubscribe();

        this.viewModel = viewModel;

        if (this.viewModel != null)
            ViewModelSubscribe();

        if (this.viewModel != null)
            ViewModelUpdate();

    }

    protected void ViewModelSubscribe()
    {
        viewModel.selectedStoryText.onValueChanged += OutputStoryText;
        viewModel.invertDirrection.onValueChanged += OutputStoryDirection;
        viewModel.isFirst.onValueChanged += OutputIsFirst;
        viewModel.isLast.onValueChanged += OutputIsLast;
    }

    protected void ViewModelUnsubscribe()
    {
        viewModel.selectedStoryText.onValueChanged -= OutputStoryText;
        viewModel.invertDirrection.onValueChanged -= OutputStoryDirection;
        viewModel.isFirst.onValueChanged -= OutputIsFirst;
        viewModel.isLast.onValueChanged -= OutputIsLast;
    }

    protected void ViewModelUpdate()
    {
        OutputStoryText(viewModel.selectedStoryText.Value);
        OutputStoryDirection(viewModel.invertDirrection.Value);
        OutputIsFirst(viewModel.isFirst.Value);
        OutputIsLast(viewModel.isLast.Value);
    }


    public void InputNextStory()
    {
        viewModel.InputNextStory();
    }
    public void InputPrevoiusStory()
    {
        viewModel.InputPreviousStory();
    }
    void OutputIsFirst(bool value)
    {
        buttonPrevious.interactable = !value;
    }
    void OutputIsLast(bool value)
    {
        buttonNext.interactable = !value;
    }

    void OutputStoryText(string value)
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
    void OutputStoryDirection(bool value)
    {
        textObject.invert = value;

    }

    public void InputDelete()
    {
        viewModel.InputRemoveSelectedStory();
    }
    void OutputDelete(bool value)
    {
        buttonDelete.interactable = value;

    }


}
