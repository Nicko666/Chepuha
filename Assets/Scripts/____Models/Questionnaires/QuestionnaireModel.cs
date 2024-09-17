using Data.Database;
using Data.Player;

namespace Models.Questionnaires
{
    public class QuestionnaireModel : IUseData<PlayerData>, IUseDatabase<QuestionnaireDatabase>
    {
        private int _playersNumber;
        private string[] _savedStores;

        private IQuestionnairePresenter _questionnaireUser;
        private IStoriesPresenter _storiesPresenter;
        private ISavedStoriesPresenters _savedStoriesUser;

        public QuestionnaireModel(IQuestionnairePresenter questionnairePresenterUser, IStoriesPresenter storiesPresenters, ISavedStoriesPresenters savedStoriesUser)
        {
            _questionnaireUser = questionnairePresenterUser;
            _questionnaireUser.onPlayersNumberChanged += SavePlayersNumber;
            _questionnaireUser.onAnswersChanged += InputAnswers;

            _storiesPresenter = storiesPresenters;
            _storiesPresenter.onSaveStoryRequest += InputSaveStory;

            _savedStoriesUser = savedStoriesUser;
            _savedStoriesUser.onSavedStoriesChanged += SaveSavedStores;
        }

        public void LoadData(QuestionnaireDatabase data)
        {
            QuestionModel[] questionModels = new QuestionModel[data.Questionnaire.Length];
            for (int i = 0; i < data.Questionnaire.Length; i++)
                questionModels[i] = new(data.Questionnaire[i]);

            _questionnaireUser.SetMinPlayersNumber(data.MinPlayersNumber);
            _questionnaireUser.SetMaxPlayersNumber(data.MaxPlayersNumber);
            _questionnaireUser.SetQuestionnaire(questionModels);
            
            _storiesPresenter.SetQuestionnaire(questionModels);
        }

        public void LoadData(PlayerData data)
        {
            _playersNumber = data.players;
            _questionnaireUser.SetPlayersNumber(_playersNumber);
            _savedStores = data.stories;
            _savedStoriesUser.SetSaveStories(_savedStores);
        }
        public void SaveData(ref PlayerData data)
        {
            data.players = _playersNumber;
            data.stories = _savedStores;
        }

        private void SavePlayersNumber(int playersNumber) =>
            _playersNumber = playersNumber;
        
        private void InputAnswers(string[,] answers) =>
            _storiesPresenter?.SetAnswers(answers);

        private bool InputSaveStory(string story) =>
            _savedStoriesUser.SaveStory(story);

        private void SaveSavedStores(string[] stories) =>
            _savedStores = stories;

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