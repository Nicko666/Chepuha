using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class QuestionnaireModel
{
    public QuestionModel[] questionsModel = new QuestionModel[0];
    public List<StringBuilder[]> playersModel = new ();
    public Vector2Int playersBoundsModel = Vector2Int.up;
}