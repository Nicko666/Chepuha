using System.Collections.Generic;

public class LocalData
{
    public float Volume;
    public int Color;
    public int Font;

    //game data

    public int players;
    public bool queByPlayer;
    public string[] stories;

    public LocalData()
    {
        Volume = 1; 
        Color = 0;
        Font = 0;

        players = 0;
        queByPlayer = false;
        stories = new string[0];

    }


}
