using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>, IDataPersistence
{
    GameEventManager _gameEventManager;

    private int _maxPlayers = 4;

    private Form _form = new();

    [SerializeField] StoriesConverter _storiesConverter;


    public Player[] Players { get; private set; }

    public QueList<Player, string> Que { get; private set; }

    public int Position { get; private set; }


    public List<string> Stories { get; private set; }


    public List<string> SavedStories { get; private set; } = new List<string>();


    private void Awake()
    {
        _gameEventManager = GameEventManager.Instance;

    }

    public void LoadData(Data data)
    {
        SavedStories = data.stories;

        ChangePlayersAndQue(data.players, data.queByPlayer);

        List<string> oldStories = LoadOldStories();

        if (oldStories.Count > 0)
        {
            SavedStories.AddRange(oldStories);
        }

    }

    public List<string> LoadOldStories()
    {
        List<string> oldStories = new();

        int count = PlayerPrefs.GetInt("StoriesNumber", 0);

        for (int i = 0; i < count; i++)
        {
            oldStories.Add(PlayerPrefs.GetString("Story" + i, "Невозможно загрузить"));
        }

        return oldStories;

    }

    public void SaveData(ref Data data)
    {
        data.stories = SavedStories;
        
        data.queByPlayer = Que.ByPlayer;

        data.players = Players.Length;        

    }

    public void ChangePlayersAndQue(int number, bool byPlayer)
    {
        if (!Enumerable.Range(1, _maxPlayers).Contains(number))
        {
            number = 1;
        }

        Players = new Player[number];

        for (int i = 0; i < Players.Length; i++)
            Players[i] = new Player((i + 1).ToString(), _form.Questions.Length);

        _gameEventManager.OnPlayersChangeNotify(number);

        ChangeQue(byPlayer);

    }

    public void ChangeQue(bool byPlayer)
    {
        Que = new(Players, _form.Questions, byPlayer);

        _gameEventManager.OnQueTypeChangeNotify(byPlayer);

        ChangePosition(0);

    }

    public void ChangePosition(int position)
    {
        if (position < 0)
        {
            Return();
            
            return;
        }
        if (position >= Que.Questions.Length)
        {
            Finish();

            return;
        }

        Position = position;

        _gameEventManager.OnPositionChangeNotify(Que.Players[position], Que.Questions[position]);

    }
    
    public void SaveStory(int index)
    {
        SavedStories.Add(Stories[index]);

    }

    public void DeleteStory(int index)
    {
        if (SavedStories.Count > index)
        {
            SavedStories.Remove(SavedStories[index]);
        }

        _gameEventManager.OnSavedTextsChangeNotify(SavedStories);

    }

    void Finish()
    {
        Stories = _storiesConverter.GetStories(Players, _form);
        
        ChangePlayersAndQue(Players.Length, Que.ByPlayer);

        ChangeQue(Que.ByPlayer);

        WindowsManager.Instance.OpenWindow(3);

    }

    void Return()
    {
        WindowsManager.Instance.OpenWindow(0);
    
    }


}
