using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OldQueuePresenter : MonoBehaviour
{
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _storiesButton;
    [SerializeField] private TMP_Text[] _fontTexts;
    private List<(int playerIndex, QuestionModel questionModel, StringBuilder answerModel)> _queue;
    private int _currentIndex;

    internal Action onInputSettings;
    internal Action onInputStories;
    internal Action<int, QuestionModel, StringBuilder> onInputQuestion;
    internal Action onInputSelect;

    internal void Reset()
    {
        _currentIndex = 0;
        onInputQuestion.Invoke(_queue[_currentIndex].playerIndex, _queue[_currentIndex].questionModel, _queue[_currentIndex].answerModel);
        OutputQueuePosition(_currentIndex, _queue.Count - 1);
    }
    private void OutputQueuePosition(int index, int maxIndex)
    {
        _previousButton.gameObject.SetActive(index > 0);
        _nextButton.gameObject.SetActive(index < maxIndex);
        _storiesButton.gameObject.SetActive(index >= maxIndex);
    }

    internal void OutputQueue(QuestionnaireModel questionnaireModel, int queueModel)
    {
        _queue = new();

        if (queueModel == 0)
            questionnaireModel.playersModel.ForEach(
                player => Array.ForEach(player, answer =>
                _queue.Add(new(
                    questionnaireModel.playersModel.IndexOf(player),
                    questionnaireModel.questionsModel[Array.IndexOf(player, answer)],
                    answer))));
        else
            Array.ForEach(questionnaireModel.questionsModel, question =>
                questionnaireModel.playersModel.ForEach(player => 
                _queue.Add(new (
                    questionnaireModel.playersModel.IndexOf(player),
                    question,
                    player[Array.IndexOf(questionnaireModel.questionsModel, question)]))));

        if (_queue.Count < 1) return;

        onInputQuestion.Invoke(_queue[_currentIndex].playerIndex, _queue[_currentIndex].questionModel, _queue[_currentIndex].answerModel);
        OutputQueuePosition(_currentIndex, _queue.Count - 1);
    }

    internal void OutputFontModel(TMP_FontAsset fontModel) =>
        Array.ForEach(_fontTexts, fontText => fontText.font = fontModel);

    internal void OutputSubmit()
    {
        if (_currentIndex >= _queue.Count - 1) return;

        _currentIndex += 1;
        OutputQueuePosition(_currentIndex, _queue.Count - 1);
        onInputQuestion.Invoke(_queue[_currentIndex].playerIndex, _queue[_currentIndex].questionModel, _queue[_currentIndex].answerModel);
        onInputSelect.Invoke();
    }

    private void Awake()
    {
        _settingsButton.onClick.AddListener(InputSettings);
        _previousButton.onClick.AddListener(InputPrevious);
        _nextButton.onClick.AddListener(InputNext);
        _storiesButton.onClick.AddListener(InputStories);
    }
    private void OnDestroy()
    {
        _settingsButton.onClick.RemoveListener(InputSettings);
        _previousButton.onClick.RemoveListener(InputPrevious);
        _nextButton.onClick.RemoveListener(InputNext);
        _storiesButton.onClick.RemoveListener(InputStories);
    }

    private void InputSettings()
    {
        _currentIndex = 0;
        onInputQuestion.Invoke(_queue[_currentIndex].playerIndex, _queue[_currentIndex].questionModel, _queue[_currentIndex].answerModel);
        OutputQueuePosition(_currentIndex, _queue.Count - 1);

        onInputSettings.Invoke();
    }
    private void InputStories()
    {
        _currentIndex = 0;
        onInputQuestion.Invoke(_queue[_currentIndex].playerIndex, _queue[_currentIndex].questionModel, _queue[_currentIndex].answerModel);
        OutputQueuePosition(_currentIndex, _queue.Count - 1);

        onInputStories.Invoke();
    }
    private void InputPrevious()
    {
        _currentIndex -= 1;
        onInputQuestion.Invoke(_queue[_currentIndex].playerIndex, _queue[_currentIndex].questionModel, _queue[_currentIndex].answerModel);
        OutputQueuePosition(_currentIndex, _queue.Count - 1);
    }

    private void InputNext()
    {
        _currentIndex += 1;
        onInputQuestion.Invoke(_queue[_currentIndex].playerIndex, _queue[_currentIndex].questionModel, _queue[_currentIndex].answerModel);
        OutputQueuePosition(_currentIndex, _queue.Count - 1);
        onInputSelect.Invoke();
    }
}
