using System.Collections.Generic;

public class Data
{
    public int playersMax = 4;
    public int volumeMax = 1;

    //settings

    public float Volume;
    public int Color;
    public int Font;

    //game data

    public int players;
    public bool queByPlayer;
    public List<string> stories;

    public Data()
    {
        Volume = 1; 
        Color = 0;
        Font = 0;

        players = 0;
        queByPlayer = false;
        stories = new List<string>();

    }


}
