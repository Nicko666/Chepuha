using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;


public class StoriesConverter : MonoBehaviour
{
    [SerializeField] TextAsset _characters;
    [SerializeField] TextAsset _places;
    [SerializeField] TextAsset _oneActions;
    [SerializeField] TextAsset _numberActions;
    [SerializeField] TextAsset _events;

    string[] _charactersWords; 
    string[] _placesWords;
    string[] _oneActionsWords;
    string[] _numberActionsWords;
    string[] _eventsWords;

    private void Awake()
    {
        _charactersWords = Words(_characters);
        _placesWords = Words(_places);
        _oneActionsWords = Words(_oneActions);
        _numberActionsWords = Words(_numberActions);
        _eventsWords = Words(_events);

    }

    string[] Words(TextAsset textFile)
    {
        return Regex.Split(textFile.text, "\n|\r\n");

    }

    public List<string> GetStories(Player[] players, Form form)
    {
        if (players.Length > 1)
        {
            return PlayersStories(players, form).ToList();
        }

        return SinglePlayerStories(players[0], form).ToList();

    }

    public IEnumerable<string> SinglePlayerStories(Player player, Form form)
    {
        Player randomiser = new("randomiser", form.Questions.Length);

        for (int i = 0; i < form.Questions.Length; i++)
        {
            randomiser.answers[i] = Get(form.RandomTypes[i]);
        }

        return PlayersStories(new Player[2] { player, randomiser }, form);

    }

    public IEnumerable<string> PlayersStories(Player[] players, Form form)
    {
        int playerNumber;

        StringBuilder story;

        for (int p = 0; p < players.Length; p++)
        {
            story = new StringBuilder();

            playerNumber = p;

            for (int q = 0; q < form.Questions.Length; q++)
            {
                story.Append(players[playerNumber].answers[q]);
                story.Append(form.Texts[q]);

                ++playerNumber;
                playerNumber = (playerNumber < players.Length) ? playerNumber : 0;
            }

            yield return story.ToString();
        }

    }

    public enum Type
    {
        Character,
        Place,
        OneAction,
        NumberAction,
        Event

    }

    public string Get(Type type)
    {
        System.Random random = new System.Random();

        switch (type)
        {
            case Type.Character:
                return _charactersWords[random.Next(0, _charactersWords.Length)];
            case Type.Place:
                return _placesWords[random.Next(0, _placesWords.Length)];
            case Type.OneAction:
                return _oneActionsWords[random.Next(0, _oneActionsWords.Length)];
            case Type.NumberAction:
                return _numberActionsWords[random.Next(0, _numberActionsWords.Length)];
            case Type.Event:
                return _eventsWords[random.Next(0, _eventsWords.Length)];
        }

        return "unknown type";

    }


}