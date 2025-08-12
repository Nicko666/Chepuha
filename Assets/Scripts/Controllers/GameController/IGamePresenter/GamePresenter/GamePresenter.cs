using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class GamePresenter : IGamePresenter
{
    [SerializeField] private BackgroundPresenter _backgroundPresenter;
    [SerializeField] private UIPanelsPresenter _panelsPresenter;
    [SerializeField] private UIButtonsPresenter _buttonsPresenter;
    [SerializeField] private SettingsPresenter _settingsPresenter;
    [SerializeField] private QuestionnairesPresenters _questionnairePresenters;
    [SerializeField] private SavedStoriesPresenters _savedStoriesPresenters;
    [SerializeField] private SoundPresenter _soundPresenter;

    public override event Action<TMP_FontAsset> onInputFont;
    public override event Action<Color> onInputBackground;
    public override event Action<float> onInputVolume;
    public override event Action<int> onInputPresenter;
    public override event Action<StringBuilder> onInputSavedStoryModelRemove;
    public override event Action<float> onInputVignette;
    public override event Action<QuestionsData> onInputQuestionsModel;
    public override event Action<int> onInputPlayersCountModel;
    public override event Action<StringBuilder> onInputAddSavedStoryModel;
    public override event Action<StringBuilder[]> onInputRemovePlayerModel;
    public override event Action<StringBuilder[]> onInputClearPlayerModel;
    public override event Action onInputAddNewAnswerModels;
    public override event Action<StringBuilder, string> onInputAnswerModel;
    public override event Action<int> onInputQueueModel;

    public override void OutputBackgroundsModel(List<Color> colors) =>
        _settingsPresenter.OutputBackgroundsModel(colors);
    public override void OutputBackgroundModel(Color backgroundModel)
    {
        _settingsPresenter.OutputBackgroundModel(backgroundModel);
        _backgroundPresenter.OutputBackgroundModel(backgroundModel);
    }

    public override void OutputVignetteBoundsModel(Vector2 vignetteBoundsModel) =>
        _settingsPresenter.OutputVignetteBoundsModel(vignetteBoundsModel);
    public override void OutputVignetteModel(float vignetteModel)
    {
        _settingsPresenter.OutputVignetteModel(vignetteModel);
        _backgroundPresenter.OutputVignetteModel(vignetteModel);
    }

    public override void OutputVolumeBoundsModel(Vector2 bounds) =>
        _settingsPresenter.OutputVolumeBoundsModel(bounds);
    public override void OutputVolumeModel(float value)
    {
        _soundPresenter.OutputVolume(value);
        _settingsPresenter.OutputVolumeModel(value);
    }

    public override void OutputPresentersModel(List<int> values) => 
        _settingsPresenter.OutputPresentersModel(values);
    public override void OutputPresenterModel(int value)
    {
        _settingsPresenter.OutputPresenterModel(value);
        _savedStoriesPresenters.OutputPresenterModel(value);
        _questionnairePresenters.OutputPresenterModel(value);
    }

    public override void OutputFontsModel(List<TMP_FontAsset> fontsModel) =>
        _settingsPresenter.OutputFontsModel(fontsModel);
    public override void OutputFontModel(TMP_FontAsset fontModel)
    {
        _settingsPresenter.OutputFontModel(fontModel);
        _questionnairePresenters.OutputFontModel(fontModel);
        _savedStoriesPresenters.OutputFontModel(fontModel);
    }

    public override void OutputQueuesModel(List<int> queuesModel) =>
        _questionnairePresenters.OutputQueuesModel(queuesModel);
    public override void OutputQueueModel(int queueModel) =>
        _questionnairePresenters.OutputQueueModel(queueModel);

    public override void OutputCreatedStoriesModel(List<StringBuilder> createdStoriesModel) =>
        _questionnairePresenters.OutputCreatedStoriesModel(createdStoriesModel);
    public override void OutputQuestionnaireModel(QuestionnaireModel questionnaireModel) =>
        _questionnairePresenters.OutputQuestionnaireModel(questionnaireModel);
    public override void OutputSavedStoryModels(List<StringBuilder> savedStoriesModel)
    {
        _savedStoriesPresenters.OutputSavedStories(savedStoriesModel);
        _questionnairePresenters.OutputSavedStories(savedStoriesModel);
    }

    private void Awake()
    {
        _buttonsPresenter.onInput += OutputPanelModel;
        _panelsPresenter.onPanelChanged += _buttonsPresenter.Output;
        _savedStoriesPresenters.onInputSavedStoryModelRemove += InputSavedStoryModelRemove;
        
        _settingsPresenter.onInputBackground += InputBackground;
        _settingsPresenter.onInputVignette += InputVignette;
        _settingsPresenter.onInputVolume += InputVolume;
        _settingsPresenter.onInputFont += InputFont;
        _settingsPresenter.onInputPresenter += InputPresenter;
        
        _questionnairePresenters.onInputQuestionsModel += InputQuestionsModel;
        _questionnairePresenters.onInputPlayersCountModel += InputPlayersCountModel;
        _questionnairePresenters.onInputRemovePlayerModel += InputRemovePlayerModel;
        _questionnairePresenters.onInputClearPlayerModel += InputClearPlayerModel;
        _questionnairePresenters.onInputAddNewAnswerModels += InputAddNewAnswerModels;
        _questionnairePresenters.onInputAnswerModel += InputAnswerModel;
        _questionnairePresenters.onInputAddSavedStoryModel += InputAddSavedStoryModel;
        _questionnairePresenters.onInputQueueModel += InputQueueModel;
    }
    private void OnDestroy()
    {
        _buttonsPresenter.onInput -= OutputPanelModel;
        _panelsPresenter.onPanelChanged -= _buttonsPresenter.Output;
        _savedStoriesPresenters.onInputSavedStoryModelRemove -= InputSavedStoryModelRemove;
        
        _settingsPresenter.onInputBackground -= InputBackground;
        _settingsPresenter.onInputVignette -= InputVignette;
        _settingsPresenter.onInputVolume -= InputVolume;
        _settingsPresenter.onInputFont -= InputFont;
        _settingsPresenter.onInputPresenter -= InputPresenter;
        
        _questionnairePresenters.onInputQuestionsModel -= InputQuestionsModel;
        _questionnairePresenters.onInputPlayersCountModel -= InputPlayersCountModel;
        _questionnairePresenters.onInputRemovePlayerModel -= InputRemovePlayerModel;
        _questionnairePresenters.onInputClearPlayerModel -= InputClearPlayerModel;
        _questionnairePresenters.onInputAddNewAnswerModels -= InputAddNewAnswerModels;
        _questionnairePresenters.onInputAnswerModel -= InputAnswerModel;
        _questionnairePresenters.onInputAddSavedStoryModel -= InputAddSavedStoryModel;
        _questionnairePresenters.onInputQueueModel -= InputQueueModel;
    }

    private void OutputPanelModel(int index)
    {
        _panelsPresenter.Output(index);
        _soundPresenter.OutputInputSound();
    }
    private void InputVolume(float volume)
    {
        onInputVolume.Invoke(volume);
        _soundPresenter.OutputInputSound();
    }
    private void InputBackground(Color color)
    {
        onInputBackground.Invoke(color);
        _soundPresenter.OutputInputSound();
    } 
    private void InputVignette(float value)
    {
        onInputVignette.Invoke(value);
        _soundPresenter.OutputInputSound();
    }
    private void InputFont(TMP_FontAsset font)
    {
        onInputFont.Invoke(font);
        _soundPresenter.OutputInputSound();
    }
    private void InputPresenter(int value)
    {
        onInputPresenter.Invoke(value);
        _soundPresenter.OutputInputSound();
    }
    private void InputSavedStoryModelRemove(StringBuilder savedStoryModel)
    {
        onInputSavedStoryModelRemove.Invoke(savedStoryModel);
        _soundPresenter.OutputInputSound();
    }
    private void InputQuestionsModel(QuestionsData questionsData)
    {
        onInputQuestionsModel.Invoke(questionsData);
        _soundPresenter.OutputInputSound();
    }
    private void InputPlayersCountModel(int playersCountModel)
    {
        onInputPlayersCountModel.Invoke(playersCountModel);
        _soundPresenter.OutputInputSound();
    }
    private void InputRemovePlayerModel(StringBuilder[] playerModel)
    {
        onInputRemovePlayerModel.Invoke(playerModel);
        _soundPresenter.OutputInputSound();
    }
    private void InputClearPlayerModel(StringBuilder[] playerModel)
    {
        onInputClearPlayerModel(playerModel);
        _soundPresenter.OutputInputSound();
    }
    private void InputAddNewAnswerModels()
    {
        onInputAddNewAnswerModels.Invoke();
        _soundPresenter.OutputInputSound();
    }
    private void InputAnswerModel(StringBuilder answer, string text) =>
        onInputAnswerModel.Invoke(answer, text);
    private void InputAddSavedStoryModel(StringBuilder storyModel)
    {
        onInputAddSavedStoryModel.Invoke(storyModel);
        _soundPresenter.OutputInputSound();
    }


    private void InputQueueModel(int queueModel)
    {
        onInputQueueModel.Invoke(queueModel);
        _soundPresenter.OutputInputSound();
    }
}
