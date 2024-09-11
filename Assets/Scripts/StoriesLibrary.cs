public static class StoriesLibrary
{
    //static public string[] GetMixedStories(Questionnaire questionnaire, StringBuilder[][] answersLists)
    //{
    //    if (answersLists.Length < 2)
    //        answersLists = AddRandomList(questionnaire, answersLists);

    //    string[] stories = new string[answersLists.Length];

    //    string[][] mixedAnswers = MixAnswers(answersLists);

    //    for (int i = 0; i < answersLists.Length; i++)
    //    {
    //        stories[i] = GetStory(questionnaire, mixedAnswers[i]);
    //    }

    //    return stories;
    //}

    //static StringBuilder[][] AddRandomList(Questionnaire questionnaire, StringBuilder[][] answersLists)
    //{
    //    StringBuilder[][] result = new StringBuilder[answersLists.Length + 1][];

    //    for (int i = 0; i < answersLists.Length; i++)
    //    {
    //        result[i] = answersLists[i];
    //    }

    //    result[result.Length - 1] = questionnaire.randomAnswers;

    //    return result;
    //}

    //static string[][] MixAnswers(StringBuilder[][] answersLists)
    //{
    //    string[][] result = new string[answersLists.Length][];

    //    int listNumber = 0;
    //    int answerNumber = 0;
    //    int temp = 0;

    //    for (listNumber = 0; listNumber < answersLists.Length; listNumber++)
    //    {
    //        result[listNumber] = new string[answersLists[listNumber].Length];

    //        temp = listNumber;

    //        for (answerNumber = 0; answerNumber < answersLists[listNumber].Length; answerNumber++)
    //        {
    //            if (temp >= answersLists.Length)
    //                temp = 0;

    //            result[listNumber][answerNumber] = answersLists[temp][answerNumber].ToString();

    //            temp++;
    //        }

    //    }

    //    return result;

    //}

    //static string GetStory(Questionnaire questionnaire, string[] answers)
    //{
    //    var result = new StringBuilder();

    //    if (questionnaire.Lines.Length != answers.Length)
    //    {
    //        Debug.LogError("Questionnaire dos not match answers! Story is not created");
    //        return null;
    //    }

    //    result.Append(questionnaire.TextBefore);

    //    for (int i = 0; i < questionnaire.Lines.Length; i++)
    //    {
    //        result.Append(answers[i]);
    //        result.Append(questionnaire.Lines[i].textAfter);
    //    }

    //    return result.ToString();

    //}


}