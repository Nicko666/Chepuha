using System.Text;
using UnityEngine.UI;

public class GameQuestionnaireQuestionsDoSlideTMPView : GameQuestionnaireQuestionsView
{
    public DOSlideTMP_Text playerName;
    public DOSlideTMP_Text question;
    public DOSlideTMP_InputField answer;

    public Selectable buttonPrevious, buttonMenu;
    public Selectable buttonNext, buttonCreateStories;


    protected override void OutputFirstQuestionButtons(bool value)
    {
        buttonPrevious.interactable = !value;
        buttonMenu.interactable = value;
    }

    protected override void OutputLastQuestionButtons(bool value)
    {
        buttonNext.interactable = !value;
        buttonCreateStories.interactable = value;
    }

    public override void InputNextQuestion()
    {
        playerName.invert = false;
        question.invert = false;
        answer.invert = false;
        
        base.InputNextQuestion();

    }

    public override void InputPreviousQuestion()
    {
        playerName.invert = true;
        question.invert = true;
        answer.invert = true;

        base.InputPreviousQuestion();

    }

    protected override void OutputPlayerName(int value)
    {
        playerName.text = $"Игрок {value + 1}";
    }

    protected override void OutputQuestion(string value)
    {
        question.text = value;
    }

    protected override void OutputAnswer(StringBuilder value)
    {
        answer.text = value.ToString();
    }


}