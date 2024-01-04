using System.Text;

public abstract class GameQuestionnaireQuestionsView : InitView<GameQuestionnaireViewModel>
{
    protected GameQuestionnaireViewModel viewModel;

    public override void Init(GameQuestionnaireViewModel viewModel)
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
        viewModel.selectedPlayerNumber.onValueChanged += OutputPlayerName;
        viewModel.selectedQuestionText.onValueChanged += OutputQuestion;
        viewModel.selectedAnswerText.onValueChanged += OutputAnswer;
        viewModel.isFirstQuestion.onValueChanged += OutputFirstQuestionButtons;
        viewModel.isLastQuestion.onValueChanged += OutputLastQuestionButtons;
    }

    void ViewModelUnsubscribe()
    {
        viewModel.selectedPlayerNumber.onValueChanged -= OutputPlayerName;
        viewModel.selectedQuestionText.onValueChanged -= OutputQuestion;
        viewModel.selectedAnswerText.onValueChanged -= OutputAnswer;
        viewModel.isFirstQuestion.onValueChanged -= OutputFirstQuestionButtons;
        viewModel.isLastQuestion.onValueChanged -= OutputLastQuestionButtons;
    }

    void ViewModelUpdate()
    {
        OutputPlayerName(viewModel.selectedPlayerNumber.Value);
        OutputQuestion(viewModel.selectedQuestionText.Value);
        OutputAnswer(viewModel.selectedAnswerText.Value);
        OutputFirstQuestionButtons(viewModel.isFirstQuestion.Value);
        OutputLastQuestionButtons(viewModel.isLastQuestion.Value);

    }

    protected abstract void OutputFirstQuestionButtons(bool value);

    protected abstract void OutputLastQuestionButtons(bool value);

    public virtual void InputNextQuestion()
    {
        viewModel.InputNextQuestion();
    }

    public virtual void InputPreviousQuestion()
    {
        viewModel.InputPreviousQuestion();
    }

    protected abstract void OutputPlayerName(int value);

    protected abstract void OutputQuestion(string value);

    public void InputAnswer(string value)
    {
        viewModel.InputAnswer(value);
    }

    protected abstract void OutputAnswer(StringBuilder value);

    public void InputCreateStories()
    {
        viewModel.InputMixStories();
    }


}