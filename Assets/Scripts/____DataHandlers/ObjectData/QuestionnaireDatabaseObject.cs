using UnityEngine;
using System.Text.RegularExpressions;
using System;
using Data.Database;
using System.Collections.Generic;

namespace DataHandlers.ObjectData
{
    [CreateAssetMenu]
    public class QuestionnaireDatabaseObject : IDatabaseHandler<QuestionnaireDatabase>
    {
        [SerializeField] public int maxPlayersNumber;
        [SerializeField] public int minPlayersNumber;

        [SerializeField] Line[] lines;

        public override QuestionnaireDatabase Load()
        {
            List<Data.Database.QuestionDatabase> storyQuestions = new List<Data.Database.QuestionDatabase>();

            foreach (var line in lines)
            {
                storyQuestions.Add(new(
                    line.question,
                    line.RandomAnswer,
                    line.textAfter));
            }

            return new QuestionnaireDatabase(storyQuestions.ToArray(), maxPlayersNumber, minPlayersNumber);
        }
    }

    [Serializable]
    public class Line
    {
        public string question;
        public TextAsset randomAnswers;
        public string[] RandomAnswer => 
            Regex.Split(randomAnswers.text, "\n|\r\n");
        public string textAfter;
    }
}