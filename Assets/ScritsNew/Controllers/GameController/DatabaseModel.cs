using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "DatabaseModel", menuName = "ScriptableObjects/DatabaseModel")]
public class DatabaseModel : ScriptableObject
{
    [Header("Settings Controllers")]
    [field: SerializeField] public List<Color> Colors { get; private set; }
    [field: SerializeField] public Vector2 VignetteBounds { get; private set; }
    [field: SerializeField] public List<TMP_FontAsset> FontAssets { get; private set; }
    [field: SerializeField] public Vector2 _volumeBounds{ get; private set; }
    [field: SerializeField] public AudioClip ClickAudioClip { get; private set; }
    [field: SerializeField] public List<int> Presenters { get; private set; }
    [field: SerializeField] public List<int> Queues { get; private set; }
    [Header("Game Controllers")]
    [field: SerializeField] public Vector2Int PlayersBounds{ get; private set; }
    [field: SerializeField] public List<QuestionsData> QuestionsDatas { get; private set; }
}
