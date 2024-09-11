using System;
using UnityEngine;

namespace Models.Questionnaires
{
    public abstract class IQuestionnairePresenter : MonoBehaviour
    {
        public abstract event Action<int> onPlayersNumberRequest;
        public abstract event Action<string[]> onSavedStoriesRequest;

        public abstract void OnMinPlayersNumberChanged(int value);
        public abstract void OnMaxPlayersNumberChanged(int value);
        public abstract void OnPlayersNumberChanged(int playersNumber);
        public abstract void OnQuestionnaireChanged(QuestionModel[] questionModels);
        public abstract void OnSavedStoriesChanged(string[] savedStories);
    }
}
