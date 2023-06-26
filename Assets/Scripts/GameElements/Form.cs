public class Form
{
    public string[] Questions => _questions;
    public string[] Texts => _texts;
    public StoriesConverter.Type[] RandomTypes => _randomTypes;


    string[] _questions = new string[7]
    {
        "Кто Ваш первый персонаж?",
        "Кто второй персонаж?",
        "Что они делают?",
        "Где они находятся?",
        "Кто третий персонаж?",
        "Что он делает?",
        "Что в итоге?"
    };

    string[] _texts = new string[7]
    {
        " и ",
        " ",
        " ",
        ". ",
        " ",
        " и ",
        ". "
    };

    StoriesConverter.Type[] _randomTypes = new StoriesConverter.Type[7]
    {
        StoriesConverter.Type.Character,
        StoriesConverter.Type.Character,
        StoriesConverter.Type.NumberAction,
        StoriesConverter.Type.Place,
        StoriesConverter.Type.Character,
        StoriesConverter.Type.OneAction,
        StoriesConverter.Type.Event
    };

    //public FormLine[] _uestions = new FormLine[7]
    //{
    //    new FormLine("Кто Ваш первый персонаж?", " и ", RandomWord.Type.Character),
    //    new FormLine("Кто второй персонаж?", " ", RandomWord.Type.Character),
    //    new FormLine("Что они делают?", " ", RandomWord.Type.NumberAction),
    //    new FormLine("Где они находятся?", ". ", RandomWord.Type.Place),
    //    new FormLine("Кто третий персонаж?", " ", RandomWord.Type.Character),
    //    new FormLine("Что он делает?", " и ", RandomWord.Type.OneAction),
    //    new FormLine("Что происходит в итоге?", ". ", RandomWord.Type.Event)
    //};


    //public class FormLine
    //{
    //    public string Qwestion;

    //    public string Text;

    //    public RandomWord.Type Type;

    //    public FormLine(string qwestion, string text, RandomWord.Type type)
    //    {
    //        Qwestion = qwestion; Text = text; Type = type;
    //    }
    
    //}

}
