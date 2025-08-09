using System.Collections.Generic;

public class DataModel
{
    public float Volume;
    public int Color;
    public int Font;
    public float Vignette;
    public int Presenter;

    //game data

    public int questionsList;
    public int players;
    public int queueType;
    public List<string> stories;

    public DataModel()
    {
        Volume = 1;

        stories = new ();
    }
}