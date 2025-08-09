using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

internal class NewQuestionnairePresenter : QuestionnairePresenter
{
    [SerializeField] private PlayersPresenter _playersPresenter;
    [SerializeField] private StoriesPresenter _storiesPresenter;

    internal override event Action onInputAddNewAnswerModels;
    internal override event Action<int> onInputPlayersCountModel;
    internal override event Action<QuestionsData> onInputQuestionsModel;
    internal override event Action<StringBuilder> onInputAddSavedStoryModel;
    internal override event Action<StringBuilder[]> onInputRemovePlayerModel;
    internal override event Action<StringBuilder[]> onInputClearPlayerModel;
    internal override event Action<StringBuilder, string> onInputAnswerModel;
    internal override event Action<int> onInputQueueModel;

    internal override void OutputCreatedStoriesModel(List<StringBuilder> createdStoriesModel) =>
        _storiesPresenter.OutputCreatedStoriesModel(createdStoriesModel);

    internal override void OutputSavedStoriesModel(List<StringBuilder> savedStoriesMode) =>
        _storiesPresenter.OutputSavedStories(savedStoriesMode);

    internal override void OutputQuestionnaireModel(QuestionnaireModel questionnaireModel) =>
        _playersPresenter.OutputQuestionnaireModel(questionnaireModel);

    internal override void OutputFontModel(TMP_FontAsset fontModel)
    {
        _playersPresenter.OutputFontModel(fontModel);
        _storiesPresenter.OutputFontModel(fontModel);
    }

    private void Awake()
    {
        _playersPresenter.onInputAnswerModel += InputAnswerModel;
        _playersPresenter.onInputQuestionsModel += InputQuestionsModel;
        _playersPresenter.onInputPlayersCountModel += InputPlayersCountModel;
        _playersPresenter.onInputRemovePlayerModel += InputRemovePlayerModel;
        _playersPresenter.onInputAddPlayerModels += InputAddNewAnswerModels;
        _playersPresenter.onInputClearPlayerModel += InputClearPlayerModel;
        _storiesPresenter.onInputSaveStoryModel += InputSaveStoryModel;
    }
    private void OnDestroy()
    {
        _playersPresenter.onInputAnswerModel -= InputAnswerModel;
        _playersPresenter.onInputQuestionsModel -= InputQuestionsModel;
        _playersPresenter.onInputPlayersCountModel -= InputPlayersCountModel;
        _playersPresenter.onInputRemovePlayerModel -= InputRemovePlayerModel;
        _playersPresenter.onInputAddPlayerModels -= InputAddNewAnswerModels;
        _playersPresenter.onInputClearPlayerModel -= InputClearPlayerModel;
        _storiesPresenter.onInputSaveStoryModel -= InputSaveStoryModel;
    }

    private void InputQuestionsModel(QuestionsData questionsModel) =>
        onInputQuestionsModel.Invoke(questionsModel);
    
    private void InputPlayersCountModel(int playersCountModel) =>
        onInputPlayersCountModel.Invoke(playersCountModel);
    
    private void InputRemovePlayerModel(StringBuilder[] playerModel) =>
        onInputRemovePlayerModel.Invoke(playerModel);
    
    private void InputAddNewAnswerModels() =>
        onInputAddNewAnswerModels.Invoke();
    
    private void InputAnswerModel(StringBuilder answerModel, string text) =>
        onInputAnswerModel.Invoke(answerModel, text);

    private void InputClearPlayerModel(StringBuilder[] playerModel) =>
        onInputClearPlayerModel.Invoke(playerModel);

    private void InputSaveStoryModel(StringBuilder storyModel) =>
        onInputAddSavedStoryModel.Invoke(storyModel);

    internal override void OutputQueueModel(int queueModel) { }
    internal override void OutputQueuesModel(List<int> queuesModel) { }
}