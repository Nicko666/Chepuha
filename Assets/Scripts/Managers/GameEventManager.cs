using System;
using System.Collections.Generic;

public class GameEventManager : Singleton<GameEventManager>
{
    public Action<int> OnPlayersChange;
    
    public Action<bool> OnQueTypeChange;

    public Action<Player, string> OnPositionChange;
    
    public Action OnInput;

    public Action<List<string>> OnSavedTextsChange;


    public void OnPlayersChangeNotify(int players) => OnPlayersChange?.Invoke(players);

    public void OnQueTypeChangeNotify(bool byPlayer) => OnQueTypeChange?.Invoke(byPlayer);

    public void OnPositionChangeNotify(Player player, string question) => OnPositionChange?.Invoke(player, question);

    public void OnInputNotify() => OnInput?.Invoke();

    public void OnSavedTextsChangeNotify(List<string> texts) => OnSavedTextsChange?.Invoke(texts);


}
