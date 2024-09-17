using System;
using UnityEngine;

namespace Models.Questionnaires
{
    public abstract class IStoriesPresenter : MonoBehaviour
    {
        public abstract event Predicate<string> onSaveStoryRequest;
        public abstract void SetQuestionnaire(QuestionModel[] questionModels);
        public abstract void SetAnswers(string[,] answers);
    }
}