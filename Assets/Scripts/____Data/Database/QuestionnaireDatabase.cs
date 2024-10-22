namespace Data.Database 
{
    public class QuestionnaireDatabase
    {
        public readonly QuestionDatabase[] Questionnaire;
        public readonly int MaxPlayersNumber;
        public readonly int MinPlayersNumber;

        public QuestionnaireDatabase (QuestionDatabase[] lines, int maxPlayersNumber, int minPlayersNumber)
        {
            Questionnaire = lines;
            MaxPlayersNumber = maxPlayersNumber;
            MinPlayersNumber = minPlayersNumber;
        }
    }

    public class QuestionDatabase
    {
        public readonly string Question;
        public readonly string[] Answers;
        public readonly string TextAfter;

        public QuestionDatabase (string question, string[] randomAnswer, string textAfter)
        {
            Question = question;
            Answers = randomAnswer;
            TextAfter = textAfter;
        }
    } 
}