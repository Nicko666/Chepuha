using System;
using System.Text;
using TMPro;
using UnityEngine;

internal class OldQuestionsPresenter : MonoBehaviour
{
    internal Action onInputAddNewAnswerModels;
    [SerializeField] private OldQuestionPresenter _oldQuestionPresenter;
    [SerializeField] private OldQueuePresenter _oldQueuePresenter;

    QuestionnaireModel _questionnaireModel;
    int _queueModel;

    internal event Action<StringBuilder, string> onInputAnswerModel
    {
        add => _oldQuestionPresenter.onInputAnswerModel += value;
        remove => _oldQuestionPresenter.onInputAnswerModel -= value;
    }
    internal event Action onInputStories
    {
        add => _oldQueuePresenter.onInputStories += value;
        remove => _oldQueuePresenter.onInputStories -= value;
    }
    internal event Action onInputSettings
    {
        add => _oldQueuePresenter.onInputSettings += value;
        remove => _oldQueuePresenter.onInputSettings -= value;
    }

    internal void OutputFontModel(TMP_FontAsset fontModel) 
    {
        _oldQuestionPresenter.OutputFontModel(fontModel);
        _oldQueuePresenter.OutputFontModel(fontModel);
    }

    internal void OutputQuestionnaireModel(QuestionnaireModel questionnaireModel)
    {
        if (_questionnaireModel != null) 
            if (_questionnaireModel.playersModel.Count != questionnaireModel.playersModel.Count || _questionnaireModel.questionsModel != questionnaireModel.questionsModel)
                _oldQueuePresenter.Reset();

        _questionnaireModel = questionnaireModel;
        _oldQueuePresenter.OutputQueue(_questionnaireModel, _queueModel);
    }

    internal void OutputQueueModel(int queueModel)
    {
        if (_queueModel != queueModel)
            _oldQueuePresenter.Reset();

        _queueModel = queueModel;
        _oldQueuePresenter.OutputQueue(_questionnaireModel, _queueModel);
    }

    private void Awake()
    {
        _oldQueuePresenter.onInputQuestion += _oldQuestionPresenter.OutputQuestion;
        _oldQueuePresenter.onInputSelect += _oldQuestionPresenter.OutputSelect;
        _oldQuestionPresenter.onSubmitAnswerModel += _oldQueuePresenter.OutputSubmit;
    }
    private void OnDestroy()
    {
        _oldQueuePresenter.onInputQuestion -= _oldQuestionPresenter.OutputQuestion;
        _oldQuestionPresenter.onSubmitAnswerModel -= _oldQueuePresenter.OutputSubmit;
    }
}
