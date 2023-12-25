using System.Text;
using TMPro;
using UnityEngine.UI;

public class GameQuestionnaireSimpleView : GameQuestionnaireView
{
    public TMP_Text playerName;
    public TMP_Text question;
    public TMP_InputField answer;

    public Button buttonPreviouse, buttonMenu;
    public Button buttonNext, buttonStories;

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
        if (viewModel!= null)
        {
            OutputPlayerName(viewModel.selectedAnswersListNumber.Value);
            OutputQuestion(viewModel.selectedQuestion.Value);
            OutputAnswer(viewModel.selectedAnswer.Value);
            OutputFirstQuestionButtons(viewModel.isFirstQuestion.Value);
            OutputLastQuestionButtons(viewModel.isLastQuestion.Value);

        }

    }

    void OutputFirstQuestionButtons(bool value)
    {
        buttonPreviouse.gameObject.SetActive(!value);
        buttonMenu.gameObject.SetActive(value);
    }

    void OutputLastQuestionButtons(bool value)
    {
        buttonNext.gameObject.SetActive(!value);
        buttonStories.gameObject.SetActive(value);
    }

    public void InputNextQuestion() => viewModel.InputNextQuestion();

    public void InputPreviousQuestion() => viewModel.InputPreviousQuestion();

    void OutputPlayerName(int value)
    {
        playerName.text = $"Игрок {value + 1}";
    }

    void OutputQuestion(string value)
    {
        question.text = value;
    }

    public void InputAnswer(string value) => viewModel.InputAnswer(value);

    void OutputAnswer(StringBuilder value)
    {
        answer.text = value.ToString();
    }
    
    public void InputCreateStories()
    {
        viewModel.InputMixStories();
    }


}