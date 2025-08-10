using System;
using System.Text;
using UnityEngine;

public interface IQuestionnaireController : IDisposable
{
    event Action<QuestionnaireModel> onQuestionnaireModel;
    event Action<StringBuilder> onAnswerModelChanged; // unused
    void SetDataModel(DataModel dataModel);
    void GetDataModel(ref DataModel dataModel);
    void SetBoundsModel(Vector2Int playersBounds);
    void SetPlayersCountModel(int playersCount);
    void SetQuestionsModel(QuestionsData questionsModel);
    void AddPlayerModel();
    void RemovePlayerModel(StringBuilder[] playerModel);
    void SetAnswerModel(StringBuilder answerModel, string text);
    void ClearPlayerModel(StringBuilder[] playerModel);
}
