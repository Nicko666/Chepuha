using System.Text;
using UnityEngine;

public abstract class GameQuestionnaireQuestionsView : MonoBehaviour, IInit<GameQuestionnaireSelectViewModel>
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
        viewModel.selectedAnswersListNumber.onValueChanged += OutputPlayerName;
        viewModel.selectedQuestion.onValueChanged += OutputQuestion;
        viewModel.selectedAnswer.onValueChanged += OutputAnswer;
        viewModel.isFirstQuestion.onValueChanged += OutputFirstQuestionButtons;
        viewModel.isLastQuestion.onValueChanged += OutputLastQuestionButtons;
    }

    void ViewModelUnsubscribe()
    {
        viewModel.selectedAnswersListNumber.onValueChanged -= OutputPlayerName;
        viewModel.selectedQuestion.onValueChanged -= OutputQuestion;
        viewModel.selectedAnswer.onValueChanged -= OutputAnswer;
        viewModel.isFirstQuestion.onValueChanged -= OutputFirstQuestionButtons;
        viewModel.isLastQuestion.onValueChanged -= OutputLastQuestionButtons;
    }

    void ViewModelUpdate()
    {
        OutputPlayerName(viewModel.selectedAnswersListNumber.Value);
        OutputQuestion(viewModel.selectedQuestion.Value);
        OutputAnswer(viewModel.selectedAnswer.Value);
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