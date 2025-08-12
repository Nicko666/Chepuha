public class QuestionModel
{
    public readonly string questionText;
    public readonly string[] randomAnswers;
    public readonly string textAfter;
    public readonly bool isUppercase;

    public QuestionModel(string questionText, string[] randomAnswers, string textAfter, bool isUppercase)
    {
        this.questionText = questionText;
        this.randomAnswers = randomAnswers;
        this.textAfter = textAfter;
        this.isUppercase = isUppercase;
    }
}
