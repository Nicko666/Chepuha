using UnityEngine;

public abstract class GameSavedStoriesView : InitView<GameSavedStoriesSelectViewModel>
{
    protected GameSavedStoriesSelectViewModel viewModel;


    public override void Init(GameSavedStoriesSelectViewModel viewModel)
    {
        if (this.viewModel != null)
            ViewUnsubscribe();

        this.viewModel = viewModel;

        if (this.viewModel != null)
            ViewSubscribe();

        if (this.viewModel != null)
            ViewUpdate();

    }

    void ViewSubscribe()
    {
        viewModel.maxStoryIndex.onValueChanged += OutputMaxStoryIndex;
        viewModel.selectedStoryIndex.onValueChanged += OutputSelectedStoryIndex;
        viewModel.selectedStoryText.onValueChanged += OutputStoryText;
        viewModel.isFirst.onValueChanged += OutputIsFirst;
        viewModel.isLast.onValueChanged += OutputIsLast;
        viewModel.invertDirrection.onValueChanged += OutputStoryDirection;
    }

    void ViewUnsubscribe()
    {
        viewModel.maxStoryIndex.onValueChanged -= OutputMaxStoryIndex;
        viewModel.selectedStoryIndex.onValueChanged -= OutputSelectedStoryIndex;
        viewModel.selectedStoryText.onValueChanged -= OutputStoryText;
        viewModel.isFirst.onValueChanged -= OutputIsFirst;
        viewModel.isLast.onValueChanged -= OutputIsLast;
        viewModel.invertDirrection.onValueChanged -= OutputStoryDirection;
    }

    protected void ViewUpdate()
    {
        OutputMaxStoryIndex(viewModel.maxStoryIndex.Value);
        OutputSelectedStoryIndex(viewModel.selectedStoryIndex.Value);
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


    protected abstract void OutputMaxStoryIndex(int value);

    protected abstract void OutputSelectedStoryIndex(int value);

    protected abstract void OutputIsFirst(bool value);

    protected abstract void OutputIsLast(bool value);

    protected abstract void OutputStoryText(string value);

    protected abstract void OutputStoryDirection(bool value);

    public void InputDelete()
    {
        viewModel.InputRemoveSelectedStory();
    }

    protected abstract void OutputDelete(bool value);


}