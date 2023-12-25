using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameQuestionnaireQuestionsView : GameQuestionnaireView
{
    public DOSlideTMP_Text playerName;
    public DOSlideTMP_Text question;
    public DOSlideTMP_InputField answer;

    public Selectable buttonPrevious, buttonMenu;
    public Selectable buttonNext, buttonCreateStories;


    protected override void ViewModelSubscribe()
    {
        viewModel.selectedAnswersListNumber.onValueChanged += OutputPlayerName;
        viewModel.selectedQuestion.onValueChanged += OutputQuestion;
        viewModel.selectedAnswer.onValueChanged += OutputAnswer;
        viewModel.isFirstQuestion.onValueChanged += OutputFirstQuestionButtons;
        viewModel.isLastQuestion.onValueChanged += OutputLastQuestionButtons;

    }

    protected override void ViewModelUnsubscribe()
    {
        viewModel.selectedAnswersListNumber.onValueChanged -= OutputPlayerName;
        viewModel.selectedQuestion.onValueChanged -= OutputQuestion;
        viewModel.selectedAnswer.onValueChanged -= OutputAnswer;
        viewModel.isFirstQuestion.onValueChanged -= OutputFirstQuestionButtons;
        viewModel.isLastQuestion.onValueChanged -= OutputLastQuestionButtons;

    }

    protected override void ViewModelUpdate()
    {
        OutputPlayerName(viewModel.selectedAnswersListNumber.Value);
        OutputQuestion(viewModel.selectedQuestion.Value);
        OutputAnswer(viewModel.selectedAnswer.Value);
        OutputFirstQuestionButtons(viewModel.isFirstQuestion.Value);
        OutputLastQuestionButtons(viewModel.isLastQuestion.Value);

    }

    void OutputFirstQuestionButtons(bool value)
    {
        buttonPrevious.interactable = !value;
        buttonMenu.interactable = value;
    }

    void OutputLastQuestionButtons(bool value)
    {
        buttonNext.interactable = !value;
        buttonCreateStories.interactable = value;
    }

    public void InputNextQuestion()
    {
        playerName.invert = false;
        question.invert = false;
        answer.invert = false;
        viewModel.InputNextQuestion();
    }

    public void InputPreviousQuestion()
    {
        playerName.invert = true;
        question.invert = true;
        answer.invert = true;
        viewModel.InputPreviousQuestion();
    }

    void OutputPlayerName(int value)
    {
        playerName.text = $"Игрок {value + 1}";
    }

    void OutputQuestion(string value)
    {
        question.text = value;
    }

    public void InputAnswer(string value)
    {
        viewModel.InputAnswer(value);
    }

    void OutputAnswer(StringBuilder value)
    {
        answer.text = value.ToString();
    }

    public void InputCreateStories()
    {
        viewModel.InputMixStories();
    }


}