public class GameSavedStoriesSelectViewModel : GameQuestionnaireViewModelAbstract
{
    public string[] stories;
    public ReactiveProperty<int> maxStoryIndex = new();
    public ReactiveProperty<int> selectedStoryIndex = new();
    public ReactiveProperty<string> selectedStoryText = new();
    public ReactiveProperty<bool> isLast = new();
    public ReactiveProperty<bool> isFirst = new();
    public ReactiveProperty<bool> invertDirrection = new();

    public GameSavedStoriesSelectViewModel(GameModel gameModel) : base(gameModel)
    {
        ViewModelUpdate();
    }

    protected override void OutputPlayersNumber(int value)
    {
        
    }

    protected override void OutputSavedStores(string[] collection)
    {
        stories = collection;




        OutputSelectedStoryIndex();
        OutputSelectedStoryText();
        OutputMaxIndex();

    }

    protected override void OutputByPlayer(bool value)
    {
        
    }


    public void InputRemoveSelectedStory()
    {
        string[] newStories = new string[stories.Length - 1];

        int newStoriesIndex = 0;

        for (int i = 0; i < stories.Length; i++)
            if (i != selectedStoryIndex.Value)
            {
                newStories[newStoriesIndex] = stories[i];
                newStoriesIndex++;
            }

        model.savedStores.Value = newStories;

    }

    public void InputNextStory()
    {
        if (selectedStoryIndex.Value < stories.Length - 1)
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








    void OutputSelectedStoryIndex()
    {
        if (selectedStoryIndex.Value >= stories.Length)
        {
            OutputSelectedStoryInvertDirrection(true);
            selectedStoryIndex.Value = stories.Length - 1;
        }

        if (selectedStoryIndex.Value < 0)
        {
            OutputSelectedStoryInvertDirrection(false);
            selectedStoryIndex.Value = 0;
        }
    }    
    void OutputSelectedStoryInvertDirrection(bool value)
    {
        invertDirrection.Value = value;
    }
    void OutputSelectedStoryText()
    {
        if (stories == null || stories.Length == 0)
        {
            selectedStoryText.Value = null;
        }
        else
        {
            selectedStoryText.Value = stories[selectedStoryIndex.Value];
        }

        OutputSelectedStoryIsFirst();
        OutputSelectedStoryIsLast();

    }
    void OutputSelectedStoryIsFirst() => 
        isFirst.Value = selectedStoryIndex.Value <= 0;
    void OutputSelectedStoryIsLast() => 
        isLast.Value = selectedStoryIndex.Value >= stories.Length - 1;
    void OutputMaxIndex() =>
        maxStoryIndex.Value = stories.Length;

}