using Data.Database;
using Data.Player;
using System;

namespace Models.Questionnaires
{
    public class QuestionnaireModel : IUseData<PlayerData>, IUseDatabase<QuestionnaireDatabase>
    {
        private int _playersNumber;
        private string[] _savedStores;

        private IQuestionnairePresenter _questionnaireUser;
        private ISavedStoriesPresenters _savedStoriesUser;

        private QuestionDatabase[] _questionData;

        private readonly Random _random = new Random();

        public QuestionnaireModel(IQuestionnairePresenter questionnairePresenterUser, ISavedStoriesPresenters savedStoriesUser)
        {
            if (_questionnaireUser != null) _questionnaireUser.onPlayersNumberRequest -= PlayersNumber;
            if (_questionnaireUser != null) _questionnaireUser.onSavedStoriesRequest -= SavedStores;
            _questionnaireUser = questionnairePresenterUser;
            if (_questionnaireUser != null) _questionnaireUser.onPlayersNumberRequest += PlayersNumber;
            if (_questionnaireUser != null) _questionnaireUser.onSavedStoriesRequest += SavedStores;

            if (_savedStoriesUser != null) _savedStoriesUser.onSavedStoriesRequest -= SavedStores;
            _savedStoriesUser = savedStoriesUser;
            if (_savedStoriesUser != null) _savedStoriesUser.onSavedStoriesRequest += SavedStores;
        }

        public void LoadData(QuestionnaireDatabase data)
        {
            _questionnaireUser.OnMaxPlayersNumberChanged(data.MinPlayersNumber);
            _questionnaireUser.OnMinPlayersNumberChanged(data.MaxPlayersNumber);

            QuestionModel[] questionModels = new QuestionModel[data.Questionnaire.Length];
            for (int i = 0; i < data.Questionnaire.Length; i++)
                questionModels[i] = new(data.Questionnaire[i]);

            _questionnaireUser.OnQuestionnaireChanged(questionModels);
        }

        public void LoadData(PlayerData data)
        {
            PlayersNumber(data.players);
            SavedStores(data.stories);
        }
        public void SaveData(ref PlayerData data)
        {
            data.players = _playersNumber;
            data.stories = _savedStores;
        }

        private void PlayersNumber(int playersNumber)
        {
            _playersNumber = playersNumber;

            _questionnaireUser?.OnPlayersNumberChanged(playersNumber);
        }

        private void SavedStores(string[] stories)
        {
            _savedStores = stories;

            _questionnaireUser.OnSavedStoriesChanged(stories);
            _savedStoriesUser.OnSavedStoriesChanged(stories);
        }
    }

    public class QuestionModel
    {
        public readonly string Question;
        public readonly string[] Answers;
        public readonly string TextAfter;

        public QuestionModel(QuestionDatabase questionData)
        {
            Question = questionData.Question;
            Answers = questionData.Answers;
            TextAfter = questionData.TextAfter;
        }
    }
}