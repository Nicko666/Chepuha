using UnityEngine;
using System.Text.RegularExpressions;
using System;
using System.Text;

[CreateAssetMenu]
public class Questionnaire : ScriptableObject
{
    [SerializeField] string textBefore;

    [SerializeField] Line[] lines;

    public string TextBefore => textBefore;

    public Line[] Lines => lines;


    public StringBuilder[] randomAnswers
    {
        get
        {
            StringBuilder[] result = new StringBuilder[Lines.Length];

            System.Random random = new System.Random();

            for (int i = 0; i < result.Length; i++)
            {
                string[] words = Regex.Split(Lines[i].randomAnswers.text, "\n|\r\n");
                result[i] = new(words[random.Next(0, words.Length)]);
            }

            return result;
        }
    
    }


}

[Serializable]
public class Line
{
    
    public string question;
    
    public TextAsset randomAnswers;

    public string textAfter;

}
