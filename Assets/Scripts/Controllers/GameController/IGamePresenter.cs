using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract class IGamePresenter : MonoBehaviour
{
    public abstract event Action<TMP_FontAsset> onInputFont;
    public abstract event Action<Color> onInputBackground;
    public abstract event Action<float> onInputVignette;
    public abstract event Action<float> onInputVolume;
    public abstract event Action<int> onInputPresenter;
    public abstract event Action<StringBuilder> onInputAddSavedStoryModel;
    public abstract event Action<StringBuilder> onInputSavedStoryModelRemove;
    public abstract event Action<QuestionsData> onInputQuestionsModel;
    public abstract event Action<int> onInputPlayersCountModel;
    public abstract event Action<StringBuilder[]> onInputRemovePlayerModel;
    public abstract event Action<StringBuilder[]> onInputClearPlayerModel;
    public abstract event Action onInputAddNewAnswerModels;
    public abstract event Action<StringBuilder, string> onInputAnswerModel;
    public abstract event Action<int> onInputQueueModel;

    public abstract void OutputBackgroundsModel(List<Color> colors);
    public abstract void OutputBackgroundModel(Color color);
    public abstract void OutputVignetteBoundsModel(Vector2 vignetteBoundsModel);
    public abstract void OutputVignetteModel(float vignetteModel);
    public abstract void OutputFontsModel(List<TMP_FontAsset> fonts);
    public abstract void OutputFontModel(TMP_FontAsset font);
    public abstract void OutputPresentersModel(List<int> values);
    public abstract void OutputPresenterModel(int value);
    public abstract void OutputVolumeBoundsModel(Vector2 bounds);
    public abstract void OutputVolumeModel(float value);
    public abstract void OutputCreatedStoriesModel(List<StringBuilder> storyModels);
    public abstract void OutputQuestionnaireModel(QuestionnaireModel questionnaireModel);
    public abstract void OutputSavedStoryModels(List<StringBuilder> storyModels);
    public abstract void OutputQueuesModel(List<int> list);
    public abstract void OutputQueueModel(int obj);
}
