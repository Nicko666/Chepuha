using System.Collections.Generic;

public class GameModel : ILocaldataModel
{
    public ReactiveProperty<int> playersNumber = new();

    public ReactiveProperty<string[]> savedStores = new();

    public ReactiveProperty<bool> isByPlayer = new();


    public GameModel(LocalData localData) 
    {
        playersNumber.Value = localData.players;
        savedStores.Value = localData.stories;
        isByPlayer.Value = localData.queByPlayer; 
    }

    public void Save(ref LocalData localData)
    {
        localData.players = playersNumber.Value;
        localData.stories = savedStores.Value;
        localData.queByPlayer = isByPlayer.Value;
    }


}
