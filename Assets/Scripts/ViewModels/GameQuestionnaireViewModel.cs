using System.Text;
using Unity.Mathematics;

public class GameQuestionnaireViewModel
{
    GameModel model;
    StaticData staticData;

    public ReactiveProperty<bool> isByPlayer = new();

    StringBuilder[][] answersLists;
    int selectedAnswersListIndex; //is playerNumber - 1
    int selectedAnswerIndex;

    public ReactiveProperty<int> playersNumber = new();
    public ReactiveProperty<int> selectedPlayerNumber = new();
    public ReactiveProperty<bool> isFirstQuestion = new();
    public ReactiveProperty<bool> isLastQuestion = new();
    public ReactiveProperty<StringBuilder> selectedAnswerText = new();
    public ReactiveProperty<string> selectedQuestionText = new();

    MixedStory[] mixedStories;

    public ReactiveProperty<int> selectedMixedStoryIndex = new();
    public ReactiveProperty<int> mixedStoriesLength = new();
    public ReactiveProperty<string> selectedMixedStoryText = new();
    public ReactiveProperty<bool> selectedMixedStoryIsSaved = new();
    public ReactiveProperty<bool> isFirstMixedStory = new();
    public ReactiveProperty<bool> isLastMixedStory = new();


    public GameQuestionnaireViewModel(GameModel gameModel, StaticData staticData)
    {
        this.staticData = staticData;

        if (this.model != null)
            ViewModelUnsubscribe();

        this.model = gameModel;

        if (this.model != null)
            ViewModelSubscribe();

        if (this.model != null)
            ViewModelUpdate();

    }

    void ViewModelSubscribe()
    {
        model.playersNumber.onValueChanged += OutputPlayersNumber;
        model.isByPlayer.onValueChanged += OutputByPlayer;
    }
    void ViewModelUnsubscribe()
    {
        model.playersNumber.onValueChanged -= OutputPlayersNumber;
        model.isByPlayer.onValueChanged -= OutputByPlayer;
    }
    protected virtual void ViewModelUpdate()
    {
        OutputPlayersNumber(model.playersNumber.Value);
        OutputByPlayer(model.isByPlayer.Value);
    }

    public virtual void InputPlayersNumber(int value)
    {
        model.playersNumber.Value = value;
    }
    public virtual void InputByPlayer(bool value)
    {
        model.isByPlayer.Value = value;
    }
    void OutputPlayersNumber(int value)
    {
        value = math.clamp(value, 1, staticData.maxPlayersNumber);

        StringBuilder[][] newAnswersLists = new StringBuilder[value][];

        for (int i = 0; i < newAnswersLists.Length; i++)
        {
            newAnswersLists[i] = new StringBuilder[staticData.blank.Lines.Length];

            for (int j = 0; j < newAnswersLists[i].Length; j++)
            {
                newAnswersLists[i][j] = new StringBuilder("");
            }
        }

        answersLists = newAnswersLists;

        playersNumber.Value = value;

        FirstQuestion();

    }
    void OutputByPlayer(bool value)
    {
        isByPlayer.Value = value;

        FirstQuestion();
    }


    public void InputNextPlayersNumber()
    {
        InputPlayersNumber((playersNumber.Value < staticData.maxPlayersNumber) ?
            (playersNumber.Value + 1) : 1);
    }


    public void InputQueue()
    {
        model.isByPlayer.Value = !model.isByPlayer.Value;
    }


    void FirstQuestion()
    {
        selectedAnswersListIndex = 0;
        selectedAnswerIndex = 0;

        OutputSelectedAnswer(selectedAnswersListIndex, selectedAnswerIndex);
    }
    public void InputNextQuestion()
    {
        if (isByPlayer.Value)
        {
            if (selectedAnswersListIndex >= answersLists.Length - 1)
            {
                selectedAnswersListIndex = 0;
                selectedAnswerIndex++;
            }
            else
                selectedAnswersListIndex++;
        }
        else
        {
            if (selectedAnswerIndex >= answersLists[0].Length - 1)
            {
                selectedAnswerIndex = 0;
                selectedAnswersListIndex++;
            }
            else
                selectedAnswerIndex++;
        }

        OutputSelectedAnswer(selectedAnswersListIndex, selectedAnswerIndex);

    }
    public void InputPreviousQuestion()
    {
        if (isByPlayer.Value)
        {
            if (selectedAnswersListIndex <= 0)
            {
                selectedAnswersListIndex = (answersLists.Length - 1);
                selectedAnswerIndex--;
            }
            else
                selectedAnswersListIndex--;
        }
        else
        {
            if (selectedAnswerIndex <= 0)
            {
                selectedAnswerIndex = (answersLists[0].Length - 1);
                selectedAnswersListIndex--;
            }
            else
                selectedAnswerIndex--;
        }

        OutputSelectedAnswer(selectedAnswersListIndex, selectedAnswerIndex);
    
    }
    void OutputSelectedAnswer(int answersListIndex, int answerIndex)
    {
        selectedPlayerNumber.Value = answersListIndex + 1;

        isFirstQuestion.Value = (answersListIndex <= 0 && answerIndex <= 0);
        isLastQuestion.Value = (answersListIndex >= answersLists.Length - 1 && answerIndex >= answersLists[answersLists.Length - 1].Length - 1);

        selectedQuestionText.Value = staticData.blank.Lines[answerIndex].question;
        selectedAnswerText.Value = answersLists[answersListIndex][answerIndex];

    }


    public void InputAnswer(string value)
    {
        selectedAnswerText.Value.Clear();
        selectedAnswerText.Value.Append(value);
    }


    public void InputMixStories()
    {
        OutputMixStories();
        OutputPlayersNumber(answersLists.Length);
    }
    void OutputMixStories()
    {
        string[] mixedStoriesTexts = StoriesLibrary.GetMixedStories(staticData.blank, answersLists);

        MixedStory[] tempMixedStories = new MixedStory[mixedStoriesTexts.Length];

        for (int i = 0; i < mixedStoriesTexts.Length; i++)
        {
            tempMixedStories[i] = new(mixedStoriesTexts[i]);
        }

        mixedStories = tempMixedStories;

        mixedStoriesLength.Value = mixedStories.Length;

        InputFirstMixedStory();

    }


    void InputFirstMixedStory()
    {
        selectedMixedStoryIndex.Value = 0;

        OutputSelectedMixedStory(selectedMixedStoryIndex.Value);

    }
    public void InputNextMixedStory()
    {
        if (selectedMixedStoryIndex.Value < mixedStories.Length - 1)
            selectedMixedStoryIndex.Value++;

        OutputSelectedMixedStory(selectedMixedStoryIndex.Value);

    }
    public void InputPreviousMixedStory()
    {
        if (selectedMixedStoryIndex.Value > 0)
            selectedMixedStoryIndex.Value--;

        OutputSelectedMixedStory(selectedMixedStoryIndex.Value);

    }
    public void OutputSelectedMixedStory(int mixedStoryIndex)
    {
        selectedMixedStoryText.Value = mixedStories[selectedMixedStoryIndex.Value].text;
        selectedMixedStoryIsSaved.Value = mixedStories[selectedMixedStoryIndex.Value].isSaved;
        isFirstMixedStory.Value = selectedMixedStoryIndex.Value <= 0;
        isLastMixedStory.Value = selectedMixedStoryIndex.Value >= mixedStories.Length - 1;

    }

    public void InputSaveMixedStory()
    {
        string[] newStories = new string[model.savedStores.Value.Length + 1];

        for (int i = 0; i < model.savedStores.Value.Length; i++)
            newStories[i] = model.savedStores.Value[i];

        newStories[newStories.Length - 1] = selectedMixedStoryText.Value;

        model.savedStores.Value = newStories;

        mixedStories[selectedMixedStoryIndex.Value].isSaved = true;
        selectedMixedStoryIsSaved.Value = mixedStories[selectedMixedStoryIndex.Value].isSaved;

    }


}

public class MixedStory
{
    public bool isSaved;
    public string text;

    public MixedStory(string text)
    {
        this.text = text;
        isSaved = false;
    }

}
