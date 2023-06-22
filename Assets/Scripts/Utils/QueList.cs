public class QueList<Player, Question>
{
    Player[] _players = new Player[0];

    Question[] _questions = new Question[0];


    public Player[] Players => _players;
    
    public Question[] Questions => _questions; 


    public bool ByPlayer { get; private set; }


    public QueList(Player[] players, Question[] questions, bool byPlayer)
    {
        ByPlayer = byPlayer;

        if (ByPlayer)
        {
            CreateList(players, questions, ref _players, ref _questions);
            return;
        }

        CreateList(questions, players, ref _questions, ref _players);

    }

    void CreateList<A, B>(A[] aItems, B[] bItems, ref A[] aItemsQue, ref B[] bItemsQue)
    {
        int lenght = aItems.Length * bItems.Length;

        aItemsQue = new A[lenght];
        bItemsQue = new B[lenght];

        int index = 0;

        foreach (A a in aItems)
        {
            foreach (B b in bItems)
            {
                aItemsQue[index] = a;
                bItemsQue[index] = b;

                index++;
            }
        }
    }


}
