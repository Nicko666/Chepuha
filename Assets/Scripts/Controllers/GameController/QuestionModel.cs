using System;
using UnityEngine;

[Serializable]
public class QuestionModel
{
    [field: SerializeField] public string questionText { get; private set; }
    [field: SerializeField] public string[] randomAnswers { get; private set; }
    [field: SerializeField] public string textAfter { get; private set; }

    public QuestionModel(string questionText, string[] randomAnswers, string textAfter)
    {
        this.questionText = questionText;
        this.randomAnswers = randomAnswers;
        this.textAfter = textAfter;
    }
}
