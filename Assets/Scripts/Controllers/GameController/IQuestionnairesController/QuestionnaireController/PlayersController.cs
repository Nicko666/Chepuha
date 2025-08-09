using System.Collections.Generic;
using System.Text;

internal class PlayersController
{
    internal void ClearPlayerModel(StringBuilder[] playerModel)
    {
        for (int i = 0; i < playerModel.Length; i++)
            playerModel[i].Clear();
    }

    internal void SetAnswerModel(StringBuilder answerModel, string text) =>
        answerModel.Clear().Append(text);

    internal void RemovePlayerModel(List<StringBuilder[]> playersModel, StringBuilder[] playerModel) =>
        playersModel.Remove(playerModel);

    internal void AddPlayerModel(List<StringBuilder[]> playersModel, int questionsCount)
    {
        StringBuilder[] playerModel = new StringBuilder[questionsCount];
        for (int j = 0; j < playerModel.Length; j++)
            playerModel[j] = new StringBuilder();

        playersModel.Add(playerModel);
    }

    internal void SetPlayersModelCount(List<StringBuilder[]> playersModel, int playersCount, int questionsCount)
    {
        playersModel.Clear();

        for (int i = 0; i < playersCount; i++)
        {
            StringBuilder[] playerModel = new StringBuilder[questionsCount];
            for (int j = 0; j < playerModel.Length; j++)
                playerModel[j] = new StringBuilder();
            
            playersModel.Add(playerModel);
        }
    }

    internal int GetPlayersModelCount(List<StringBuilder[]> playersModel) =>
        playersModel.Count;
}
