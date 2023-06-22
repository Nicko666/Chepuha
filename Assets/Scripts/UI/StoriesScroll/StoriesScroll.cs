using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class StoriesScroll : MonoBehaviour
{
    [SerializeField] RectTransform _content;

    [SerializeField] StoryCard _preefab;

    [SerializeField] ScrollRect _scrollRect;

    GameEventManager _gameEventManager;


    public List<StoryCard> Content { get; private set; } = new List<StoryCard>();

    [field: SerializeField] public int CurrentContent { get; private set; }


    private void Awake()
    {
        _gameEventManager = GameEventManager.Instance;
    }

    private void OnEnable()
    {
        _gameEventManager.OnSavedTextsChange += OnChangeStories;

    }

    private void OnDisable()
    {
        _gameEventManager.OnSavedTextsChange -= OnChangeStories;

    }

    public void SetStories(List<string> stories)
    {
        _content.localPosition = Vector3.zero;

        OnChangeStories(stories);

    }

    public void OnChangeStories(List<string> stories)
    {
        ClearList();

        _content.sizeDelta = Vector2.right * (stories.Count * _preefab.rectTransform.sizeDelta.x);

        for (int i = 0; i < stories.Count; i++)
        {
            var newObj = Instantiate(_preefab, _content);
            
            newObj.tmpText.text = stories[i];
            newObj.rectTransform.localPosition += Vector3.right * (i * newObj.rectTransform.sizeDelta.x);

            Content.Add(newObj);
        }

        SetPosition(SelectClosest());

    }

    public void OnPointerUp()
    {
        SelectClosest();

        SetPosition(CurrentContent);

    }

    public int SelectClosest()
    {
        int index = Mathf.RoundToInt(-_content.localPosition.x / _preefab.rectTransform.sizeDelta.x);
        index = math.clamp(index, 0, Content.Count - 1);
        CurrentContent = index;
        return index;

    }

    void ClearList()
    {
        foreach (Transform child in _content.transform)
        {
            Destroy(child.gameObject);
        }

        Content = new List<StoryCard>();

    }

    void SetPosition(int index)
    {
        _content.localPosition = new Vector3(-index * _preefab.rectTransform.sizeDelta.x, 0, 0);

    }


}
