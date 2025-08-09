using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

internal class OldQuestionnairePresenter : QuestionnairePresenter
{
    [SerializeField] private OldQuestionsSettingsPresenter _settingsPresenter;
    [SerializeField] private OldQuestionsPresenter _questionsPresenter;
    [SerializeField] private OldCreatedStoriesPresenter _createdStoriesPresenter;

    internal override event Action<QuestionsData> onInputQuestionsModel;//
    internal override event Action<int> onInputPlayersCountModel
    {
        add => _settingsPresenter.onInputPlayersCountModel += value;
        remove => _settingsPresenter.onInputPlayersCountModel -= value;
    }
    internal override event Action<StringBuilder[]> onInputRemovePlayerModel;//
    internal override event Action onInputAddNewAnswerModels;//
    internal override event Action<StringBuilder, string> onInputAnswerModel
    {
        add => _questionsPresenter.onInputAnswerModel += value;
        remove => _questionsPresenter.onInputAnswerModel -= value;
    }
    internal override event Action<StringBuilder[]> onInputClearPlayerModel;
    internal override event Action<StringBuilder> onInputAddSavedStoryModel
    {
        add => _createdStoriesPresenter.onInputAddSavedStoryModel += value;
        remove => _createdStoriesPresenter.onInputAddSavedStoryModel -= value;
    }
    internal override event Action<int> onInputQueueModel
    {
        add => _settingsPresenter.onInputQueueModel += value;
        remove => _settingsPresenter.onInputQueueModel -= value;
    }

    internal override void OutputCreatedStoriesModel(List<StringBuilder> storiesModel) =>
        _createdStoriesPresenter.OutputCreatedStoriesModel(storiesModel);

    internal override void OutputSavedStoriesModel(List<StringBuilder> storiesModel) =>
        _createdStoriesPresenter.OutputSavedStoriesModel(storiesModel);

    internal override void OutputFontModel(TMP_FontAsset fontModel)
    {
        _settingsPresenter.OutputFontModel(fontModel);
        _questionsPresenter.OutputFontModel(fontModel);
        _createdStoriesPresenter.OutputFontModel(fontModel);
    }

    internal override void OutputQuestionnaireModel(QuestionnaireModel questionnaireModel)
    {
        _questionsPresenter.OutputQuestionnaireModel(questionnaireModel);
        _settingsPresenter.OutputQuestionnaireModel(questionnaireModel);
    }

    internal override void OutputQueuesModel(List<int> queuesModel) =>
        _settingsPresenter.OutputQueuesModel(queuesModel);
    internal override void OutputQueueModel(int queueModel)
    {
        _settingsPresenter.OutputQueueModel(queueModel);
        _questionsPresenter.OutputQueueModel(queueModel);
    }

    private void Awake()
    {
        _settingsPresenter.onInputQuestions += InputQuestions;
        _questionsPresenter.onInputStories += InputStories;
        _questionsPresenter.onInputSettings += InputSettings;
        _createdStoriesPresenter.onInputSettings += InputSettings;
    }
    private void OnDestroy()
    {
        _settingsPresenter.onInputQuestions -= InputQuestions;
        _questionsPresenter.onInputStories -= InputStories;
        _questionsPresenter.onInputSettings -= InputSettings;
        _createdStoriesPresenter.onInputSettings -= InputSettings;
    }

    private void Start() => InputSettings();

    private void InputQuestions()
    {
        _settingsPresenter.gameObject.SetActive(false);
        _questionsPresenter.gameObject.SetActive(true);
        _createdStoriesPresenter.gameObject.SetActive(false);
    }

    private void InputStories()
    {
        _settingsPresenter.gameObject.SetActive(false);
        _questionsPresenter.gameObject.SetActive(false);
        _createdStoriesPresenter.gameObject.SetActive(true);
    }

    private void InputSettings()
    {
        _settingsPresenter.gameObject.SetActive(true);
        _questionsPresenter.gameObject.SetActive(false);
        _createdStoriesPresenter.gameObject.SetActive(false);
    }
}