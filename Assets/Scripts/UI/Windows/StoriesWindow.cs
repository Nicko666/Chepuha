using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StoriesWindow : Window
{
    [SerializeField] StoriesScroll _storiesScroll;

    [SerializeField] Button _saveStory;
    [SerializeField] Button _menu;

    protected override void Awake()
    {
        base.Awake();

        _saveStory.onClick.AddListener(OnSaveStory);
        _menu.onClick.AddListener(OnMenu);

    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _storiesScroll.SetStories(_gameManager.Stories.ToList());

    }

    public override void OnEscape() => _windowsManager.OpenWindow(0);

    public override void OnEscapeHold() => _windowsManager.OpenWindow(0);

    void OnSaveStory()  => _gameManager.SaveStory(_storiesScroll.CurrentContent);

    void OnMenu() => _windowsManager.OpenWindow(0);


}
