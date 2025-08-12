using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OldQuestionsSettingsPresenter : MonoBehaviour
{
    [SerializeField] private OldPlayersSettingSlider _playersSettingSlider;
    [SerializeField] private OldQueueSettingSlider _queueSettingSlider;
    [SerializeField] private Button _questionsButton;
    [SerializeField] private TMP_Text _questionsText;
    private int _playersCount;

    internal event Action<int> onInputPlayersCountModel;
    internal event Action<int> onInputQueueModel
    {
        add => _queueSettingSlider.onValueChanged += value;
        remove => _queueSettingSlider.onValueChanged -= value;
    }
    internal Action onInputQuestions;

    internal void OutputQuestionnaireModel(QuestionnaireModel questionnaireModel)
    {
        _playersCount = questionnaireModel.playersModel.Count;
        _playersSettingSlider.OutputValuesModel(questionnaireModel.playersBoundsModel);
        _playersSettingSlider.OutputValueModel(_playersCount);
    }

    internal void OutputFontModel(TMP_FontAsset fontModel)
    {
        _playersSettingSlider.OutputFontModel(fontModel);
        _queueSettingSlider.OutputFontModels(fontModel);
        _questionsText.font = fontModel;
    }

    internal void OutputQueuesModel(List<int> queuesModel) =>
        _queueSettingSlider.OutputValues(queuesModel);
    internal void OutputQueueModel(int queueModel) =>
        _queueSettingSlider.OutputValue(queueModel);

    private void Awake()
    {
        _questionsButton.onClick.AddListener(InputQuestions);
        _playersSettingSlider.onValueChanged += InputPlayersCountModel;
    }
    private void OnDestroy()
    {
        _questionsButton.onClick.RemoveListener(InputQuestions);
        _playersSettingSlider.onValueChanged -= InputPlayersCountModel;
    }

    private void InputQuestions()
    {
        onInputPlayersCountModel.Invoke(_playersCount);
        onInputQuestions.Invoke();
    }

    private void InputPlayersCountModel(int count) =>
        onInputPlayersCountModel.Invoke(count);
}