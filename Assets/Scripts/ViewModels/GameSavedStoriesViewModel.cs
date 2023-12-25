public class GameSavedStoriesViewModel : GameViewModel
{
    public ReactiveProperty<string[]> stories = new();
    public ReactiveProperty<int> selectedStoryIndex = new();
    public ReactiveProperty<string> selectedStoryText = new();
    public ReactiveProperty<bool> isLast = new();
    public ReactiveProperty<bool> isFirst = new();
    public ReactiveProperty<bool> invertDirrection = new();

    public GameSavedStoriesViewModel(GameModel model) : base(model)
    {
        ViewModelUpdate();
    }

    protected override void ViewModelSubscribe()
    {
        model.savedStores.onValueChanged += OutputStories;
    }
    protected override void ViewModelUnsubscribe()
    {
        model.savedStores.onValueChanged -= OutputStories;
    }

    void ViewModelUpdate()
    {
        OutputStories(model.savedStores.Value);
    }

    public void InputRemoveSelectedStory()
    {
        string[] newStories = new string[stories.Value.Length - 1];

        int newStoriesIndex = 0;

        for (int i = 0; i < stories.Value.Length; i++)
            if (i != selectedStoryIndex.Value)
            {
                newStories[newStoriesIndex] = stories.Value[i];
                newStoriesIndex++;
            }

        model.savedStores.Value = newStories;

    }
    void OutputStories(string[] collection)
    {
        stories.Value = collection;

        OutputSelectedStoryIndex();

        OutputSelectedStoryText();

    }
    void OutputSelectedStoryIndex()
    {
        if (selectedStoryIndex.Value >= stories.Value.Length)
        {
            OutputSelectedStoryInvertDirrection(true);
            selectedStoryIndex.Value = stories.Value.Length - 1;
        }

        if (selectedStoryIndex.Value < 0)
        {
            OutputSelectedStoryInvertDirrection(false);
            selectedStoryIndex.Value = 0;
        }
    }

    public void InputNextStory()
    {
        if (selectedStoryIndex.Value < stories.Value.Length - 1)
        {
            invertDirrection.Value = false;
            selectedStoryIndex.Value++;

            OutputSelectedStoryText();
        }

    }
    public void InputPreviousStory()
    {
        if (selectedStoryIndex.Value > 0)
        {
            invertDirrection.Value = true;
            selectedStoryIndex.Value--;

            OutputSelectedStoryText();
        }

    }
    void OutputSelectedStoryInvertDirrection(bool value)
    {
        invertDirrection.Value = value;
    }
    void OutputSelectedStoryText()
    {
        if (stories.Value == null || stories.Value.Length == 0)
        {
            selectedStoryText.Value = null;
        }
        else
        {
            selectedStoryText.Value = stories.Value[selectedStoryIndex.Value];
        }

        OutputSelectedStoryIsFirst();
        OutputSelectedStoryIsLast();

    }
    void OutputSelectedStoryIsFirst() => isFirst.Value = selectedStoryIndex.Value <= 0;
    void OutputSelectedStoryIsLast() => isLast.Value = selectedStoryIndex.Value >= stories.Value.Length - 1;


}