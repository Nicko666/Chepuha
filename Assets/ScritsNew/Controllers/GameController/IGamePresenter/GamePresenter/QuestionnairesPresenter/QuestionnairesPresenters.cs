using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class QuestionnairesPresenters : MonoBehaviour
{
    [SerializeField] private QuestionnairePresenter[] _questionnairePresenters;
    
    internal event Action<StringBuilder> onInputAddSavedStoryModel
    {
        add => Array.ForEach(_questionnairePresenters, i => i.onInputAddSavedStoryModel += value);
        remove => Array.ForEach(_questionnairePresenters, i => i.onInputAddSavedStoryModel -= value);
    }
    internal event Action<int> onInputQueueModel
    {
        add => Array.ForEach(_questionnairePresenters, i => i.onInputQueueModel += value);
        remove => Array.ForEach(_questionnairePresenters, i => i.onInputQueueModel -= value);
    }
    internal Action<QuestionsData> onInputQuestionsModel;
    internal Action<int> onInputPlayersCountModel;
    internal Action<StringBuilder[]> onInputRemovePlayerModel;
    internal Action<StringBuilder[]> onInputClearPlayerModel;
    internal Action onInputAddNewAnswerModels;
    internal Action<StringBuilder, string> onInputAnswerModel;
    
    private void Awake()
    {
        foreach (QuestionnairePresenter questionnairePresenter in _questionnairePresenters)
        {
            questionnairePresenter.onInputQuestionsModel += InputQuestionsModel;
            questionnairePresenter.onInputPlayersCountModel += InputPlayersCountModel;
            questionnairePresenter.onInputRemovePlayerModel += InputRemovePlayerModel;
            questionnairePresenter.onInputAddNewAnswerModels += InputAddNewAnswerModels;
            questionnairePresenter.onInputAnswerModel += InputAnswerModel;
            questionnairePresenter.onInputClearPlayerModel += InputClearPlayerModel;
        }
    }
    private void OnDestroy()
    {
        foreach (QuestionnairePresenter questionnairePresenter in _questionnairePresenters)
        {
            questionnairePresenter.onInputQuestionsModel -= InputQuestionsModel;
            questionnairePresenter.onInputPlayersCountModel -= InputPlayersCountModel;
            questionnairePresenter.onInputRemovePlayerModel -= InputRemovePlayerModel;
            questionnairePresenter.onInputAddNewAnswerModels -= InputAddNewAnswerModels;
            questionnairePresenter.onInputAnswerModel -= InputAnswerModel;
            questionnairePresenter.onInputClearPlayerModel -= InputClearPlayerModel;
        }
    }

    internal void OutputPresenterModel(int value)
    {
        for (int i = 0; i < _questionnairePresenters.Length; i++)
            _questionnairePresenters[i].gameObject.SetActive(i == value);
    }

    internal void OutputCreatedStoriesModel(List<StringBuilder> createdStoriesModel)
    {
        foreach (QuestionnairePresenter questionnairePresenter in _questionnairePresenters)
            questionnairePresenter.OutputCreatedStoriesModel(createdStoriesModel);
    }

    internal void OutputFontModel(TMP_FontAsset fontModel)
    {
        foreach (QuestionnairePresenter questionnairePresenter in _questionnairePresenters)
            questionnairePresenter.OutputFontModel(fontModel);
    }

    internal void OutputQuestionnaireModel(QuestionnaireModel questionnaireModel)
    {
        foreach (QuestionnairePresenter questionnairePresenter in _questionnairePresenters)
            questionnairePresenter.OutputQuestionnaireModel(questionnaireModel);
    }

    internal void OutputSavedStories(List<StringBuilder> savedStoriesModel)
    {
        foreach (QuestionnairePresenter questionnairePresenter in _questionnairePresenters)
            questionnairePresenter.OutputSavedStoriesModel(savedStoriesModel);
    }

    internal void OutputQueuesModel(List<int> queuesModel)
    {
        foreach (QuestionnairePresenter questionnairePresenter in _questionnairePresenters)
            questionnairePresenter.OutputQueuesModel(queuesModel);
    }
    internal void OutputQueueModel(int queueModel)
    {
        foreach (QuestionnairePresenter questionnairePresenter in _questionnairePresenters)
            questionnairePresenter.OutputQueueModel(queueModel);
    }

    private void InputQuestionsModel(QuestionsData questionsData) =>
        onInputQuestionsModel.Invoke(questionsData);

    private void InputPlayersCountModel(int playersCountModel) =>
        onInputPlayersCountModel.Invoke(playersCountModel);

    private void InputRemovePlayerModel(StringBuilder[] playerModel) =>
        onInputRemovePlayerModel.Invoke(playerModel);

    private void InputAddNewAnswerModels() =>
        onInputAddNewAnswerModels.Invoke();

    private void InputAnswerModel(StringBuilder playerModel, string text) =>
        onInputAnswerModel.Invoke(playerModel, text);

    private void InputClearPlayerModel(StringBuilder[] playerModel) =>
        onInputClearPlayerModel.Invoke(playerModel);
}
