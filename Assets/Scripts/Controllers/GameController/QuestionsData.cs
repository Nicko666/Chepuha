using System.Text.RegularExpressions;
using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "QuestionsData", menuName = "ScriptableObjects/QuestionsData")]
public class QuestionsData : ScriptableObject
{
    [field: SerializeField] public List<QuestionData> QuestionModels { get; private set; }
}

[Serializable]
public class QuestionData
{
    [field: SerializeField] public string Question { get; private set; }
    [SerializeField] public TextAsset _randomAnswers;
    public string[] RandomAnswer => Regex.Split(_randomAnswers.text, "\n|\r\n");
    [field: SerializeField] public string TextAfter { get; private set; }
}