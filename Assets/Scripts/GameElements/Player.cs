public class Player
{
    public string name;
    public string[] answers;

    public Player(string name, int answersNumber)
    {
        this.name = name;
        this.answers = new string[answersNumber];
    } 
    
}
