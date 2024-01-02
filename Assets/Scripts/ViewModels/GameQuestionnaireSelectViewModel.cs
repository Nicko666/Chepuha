using System.Text;

public class GameQuestionnaireSelectViewModel : GameQuestionnaireViewModel
{
    StaticData staticData;

    public StringBuilder[][] answersLists;
    public ReactiveProperty<bool> isByPlayer = new();
    public ReactiveProperty<int> answersListsCount = new();
    public ReactiveProperty<int> selectedAnswersListNumber = new(); //reactive cose is playerNumber
    public ReactiveProperty<StringBuilder> selectedAnswer = new();
    public ReactiveProperty<int> selectedQuestionNumber = new();
    public ReactiveProperty<string> selectedQuestion = new();
    public ReactiveProperty<bool> isFirstQuestion = new();
    public ReactiveProperty<bool> isLastQuestion = new();

    public MixedStory[] mixedStories = new MixedStory[1] {new("")};
    public ReactiveProperty<int> selectedMixedStoryNumber = new();
    public ReactiveProperty<string> selectedMixedStoryText = new();
    public ReactiveProperty<bool> selectedMixedStoryIsSaved = new();
    public ReactiveProperty<bool> isFirstMixedStory = new();
    public ReactiveProperty<bool> isLastMixedStory = new();


    public GameQuestionnaireSelectViewModel(GameModel gameModel, StaticData staticData) : base(gameModel)
    {
        this.staticData = staticData;

        ViewModelUpdate();
    }


    public void InputAnswersListsCount()
    {
        model.playersNumber.Value = 
            (model.playersNumber.Value < staticData.maxPlayersNumber) ? 
            (model.playersNumber.Value + 1) : 1 ;
    }
   
    void OutputAnswersLists()
    {
        StringBuilder[][] newAnswersLists = new StringBuilder[answersListsCount.Value][];
        
        for (int i = 0; i < newAnswersLists.Length; i++)
        {
            newAnswersLists[i] = new StringBuilder[staticData.blank.Lines.Length];

            for (int j = 0; j < newAnswersLists[i].Length; j++)
                newAnswersLists[i][j] = new StringBuilder();
        }

        answersLists = newAnswersLists;

        InputFirstQuestion();

    } //playersCount

    public void InputQueue()
    {
        model.isByPlayer.Value = !model.isByPlayer.Value;
    }    
 
    public void InputFirstQuestion()
    {
        selectedAnswersListNumber.Value = 0;
        selectedQuestionNumber.Value = 0;

        OutputQwestion();
    }
    public void InputNextQuestion()
    {
        if (isByPlayer.Value)
        {
            if (selectedAnswersListNumber.Value >= answersLists.Length - 1)
            {
                selectedAnswersListNumber.Value = 0;
                selectedQuestionNumber.Value++;
            }
            else
                selectedAnswersListNumber.Value++;
        }
        else
        {
            if (selectedQuestionNumber.Value >= answersLists[0].Length - 1)
            {
                selectedQuestionNumber.Value = 0;
                selectedAnswersListNumber.Value++;
            }
            else
                selectedQuestionNumber.Value++;
        }

        OutputQwestion();

    }
    public void InputPreviousQuestion()
    {
        if (isByPlayer.Value)
        {
            if (selectedAnswersListNumber.Value <= 0)
            {
                selectedAnswersListNumber.Value = (answersLists.Length - 1);
                selectedQuestionNumber.Value--;
            }
            else
                selectedAnswersListNumber.Value--;
        }
        else
        {
            if (selectedQuestionNumber.Value <= 0)
            {
                selectedQuestionNumber.Value = (answersLists[0].Length - 1);
                selectedAnswersListNumber.Value--;
            }
            else
                selectedQuestionNumber.Value--;
        }

        OutputQwestion();

    }
    void OutputQwestion()
    {
        selectedQuestion.Value = staticData.blank.Lines[selectedQuestionNumber.Value].question;
        OutputAnswer();

        isFirstQuestion.Value = (selectedAnswer.Value == answersLists[0][0]);
        isLastQuestion.Value = selectedAnswersListNumber.Value == (answersLists.Length - 1) && selectedQuestionNumber.Value == (answersLists[0].Length - 1);

    }

    public void InputAnswer(string value)
    {
        selectedAnswer.Value.Clear();
        selectedAnswer.Value.Append(value);
    }
    public void OutputAnswer()
    {
        selectedAnswer.Value = answersLists[selectedAnswersListNumber.Value][selectedQuestionNumber.Value];
    }

    
    public void InputMixStories()
    {
        OutputMixStories();
        OutputPlayersNumber(answersListsCount.Value);
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

        InputFirstMixedStory();
    
    }

    public void InputFirstMixedStory()
    {
        selectedMixedStoryNumber.Value = 0;

        OutputMixedStory();

    }
    public void InputNextMixedStory()
    {
        if (selectedMixedStoryNumber.Value < mixedStories.Length - 1)
            selectedMixedStoryNumber.Value++;

        OutputMixedStory();

    }
    public void InputPreviousMixedStory()
    {
        if (selectedMixedStoryNumber.Value > 0)
            selectedMixedStoryNumber.Value--;

        OutputMixedStory();

    }
    public void OutputMixedStory()
    {
        selectedMixedStoryText.Value = mixedStories[selectedMixedStoryNumber.Value].text;
        OutputSaveMixedStory();

        isFirstMixedStory.Value = selectedMixedStoryNumber.Value <= 0;
        isLastMixedStory.Value = selectedMixedStoryNumber.Value >= mixedStories.Length - 1;


    }

    public void InputSaveMixedStory()
    {
        string[] newStories = new string[model.savedStores.Value.Length + 1];

        for (int i = 0; i < model.savedStores.Value.Length; i++)
            newStories[i] = model.savedStores.Value[i];

        newStories[newStories.Length - 1] = selectedMixedStoryText.Value;

        model.savedStores.Value = newStories;

        mixedStories[selectedMixedStoryNumber.Value].isSaved = true;
        OutputSaveMixedStory();

    }
    void OutputSaveMixedStory()
    {
        selectedMixedStoryIsSaved.Value = mixedStories[selectedMixedStoryNumber.Value].isSaved;
    
    }


    protected override void OutputPlayersNumber(int value)
    {
        answersListsCount.Value = value;
        OutputAnswersLists();
    }

    protected override void OutputByPlayer(bool value)
    {
        isByPlayer.Value = value;

        InputFirstQuestion();
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
