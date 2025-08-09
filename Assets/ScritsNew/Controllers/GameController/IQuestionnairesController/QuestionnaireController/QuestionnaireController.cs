using System;
using System.Text;
using UnityEngine;

[SerializeField]
public class QuestionnaireController : IQuestionnaireController
{
    private QuestionnaireModel _questionnaireModel = new ();
    private PlayersController _playersController = new ();
    
    public event Action<QuestionnaireModel> onQuestionnaireModel;

    public void SetBoundsModel(Vector2Int playersBounds)
    {
        _questionnaireModel.playersBoundsModel = playersBounds;

        int playersCount = Math.Clamp(_questionnaireModel.playersModel.Count, _questionnaireModel.playersBoundsModel.x, _questionnaireModel.playersBoundsModel.y);

        _playersController.SetPlayersModelCount(_questionnaireModel.playersModel, playersCount, _questionnaireModel.questionsModel.Length);

        onQuestionnaireModel.Invoke(_questionnaireModel);
    }

    public void SetDataModel(DataModel dataModel)
    {
        int playersCount = Math.Clamp(dataModel.players, _questionnaireModel.playersBoundsModel.x, _questionnaireModel.playersBoundsModel.y);

        _playersController.SetPlayersModelCount(_questionnaireModel.playersModel, playersCount, _questionnaireModel.questionsModel.Length);

        onQuestionnaireModel.Invoke(_questionnaireModel);
    }

    public void GetDataModel(ref DataModel dataModel) =>
        dataModel.players = _playersController.GetPlayersModelCount(_questionnaireModel.playersModel);

    public void SetQuestionsModel(QuestionsData questionsData)
    {
        _questionnaireModel.questionsModel = questionsData.QuestionModels.ConvertAll(i => new QuestionModel(i.Question, i.RandomAnswer, i.TextAfter)).ToArray();

        _playersController.SetPlayersModelCount(_questionnaireModel.playersModel, _questionnaireModel.playersModel.Count, _questionnaireModel.questionsModel.Length);

        onQuestionnaireModel.Invoke(_questionnaireModel);
    }

    public void SetPlayersCountModel(int playersCount)
    {
        playersCount = Math.Clamp(playersCount, _questionnaireModel.playersBoundsModel.x, _questionnaireModel.playersBoundsModel.y);

        _playersController.SetPlayersModelCount(_questionnaireModel.playersModel, playersCount, _questionnaireModel.questionsModel.Length);

        onQuestionnaireModel.Invoke(_questionnaireModel);
    }

    public void AddPlayerModel()
    {
        if (_questionnaireModel.playersModel.Count >= _questionnaireModel.playersBoundsModel.y) return;

        _playersController.AddPlayerModel(_questionnaireModel.playersModel, _questionnaireModel.questionsModel.Length);

        onQuestionnaireModel.Invoke(_questionnaireModel);
    }

    public void RemovePlayerModel(StringBuilder[] playerModel)
    {
        if (_questionnaireModel.playersModel.Count <= _questionnaireModel.playersBoundsModel.x) return;

        _playersController.RemovePlayerModel(_questionnaireModel.playersModel, playerModel);

        onQuestionnaireModel.Invoke(_questionnaireModel);
    }

    public void ClearPlayerModel(StringBuilder[] playerModel)
    {
        _playersController.ClearPlayerModel(playerModel);

        onQuestionnaireModel.Invoke(_questionnaireModel);
    }

    public void SetAnswerModel(StringBuilder answerModel, string text)
    {
        _playersController.SetAnswerModel(answerModel, text);

        onQuestionnaireModel.Invoke(_questionnaireModel);
    }

    public void Dispose() { }
}

