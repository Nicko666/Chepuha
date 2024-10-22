using System;
using UnityEngine;

namespace Models.Questionnaires
{
    public abstract class IQuestionnairePresenter : MonoBehaviour
    {
        public abstract event Action<int> onPlayersNumberChanged;
        public abstract event Action<string[,]> onAnswersChanged;
        public abstract void SetMinPlayersNumber(int value);
        public abstract void SetMaxPlayersNumber(int value);
        public abstract void SetPlayersNumber(int playersNumber);
        public abstract void SetQuestionnaire(QuestionModel[] questionModels);
    }
}
