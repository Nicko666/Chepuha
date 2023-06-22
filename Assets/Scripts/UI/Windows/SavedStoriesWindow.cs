using UnityEngine;
using UnityEngine.UI;

public class SavedStoriesWindow : Window
{
    [SerializeField] StoriesScroll _storiesScroll;

    [SerializeField] Button _delete;
    [SerializeField] Button _menu;

    protected override void Awake()
    {
        base.Awake();

        _delete.onClick.AddListener(OnDeleteStory);
        _menu.onClick.AddListener(OnMenu);

    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _storiesScroll.SetStories(_gameManager.SavedStories);

    }

    protected override void OnDisable()
    {
        base.OnDisable();

    }


    public override void OnEscape() => _windowsManager.OpenWindow(0);

    public override void OnEscapeHold() => _windowsManager.OpenWindow(0);

    void OnDeleteStory() => _gameManager.DeleteStory(_storiesScroll.CurrentContent);

    void OnMenu() => _windowsManager.OpenWindow(0);


}
