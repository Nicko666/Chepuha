namespace Data.Player
{
    public class PlayerData
    {
        public float Volume;
        public int Color;
        public int Font;

        //game data

        public int players;
        public bool queByPlayer; //not using
        public string[] stories;

        public PlayerData()
        {
            Volume = 1;
            Color = 0;
            Font = 0;

            players = 0;
            queByPlayer = false;
            stories = new string[0];
        }
    }
}
