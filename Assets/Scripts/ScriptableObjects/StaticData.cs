using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class StaticData : ScriptableObject
{
    public Color[] colors;

    public TMP_FontAsset[] fontAssets;

    public int maxPlayersNumber;

    public Questionnaire blank;

}
