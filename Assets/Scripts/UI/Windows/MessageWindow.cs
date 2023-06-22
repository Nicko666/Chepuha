using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : Window
{
    [SerializeField] TMP_Text _tmpText;

    [SerializeField] Button _yes;
    [SerializeField] Button _not;

    public Action OnNot;
    public Action OnYes;

    protected override void Awake()
    {
        base.Awake();

        _yes.onClick.AddListener(OnYesNotify);
        _not.onClick.AddListener(OnNotNotify);

    }

    public override void OnEscape() => OnNotNotify();
    public override void OnEscapeHold() => OnNotNotify();

    public void OnNotNotify() => OnNot?.Invoke();
    public void OnYesNotify() => OnYes?.Invoke();

    public void CreateMessage(System.Action onYes, System.Action onNot, string message)
    {
        _tmpText.text = message;

        OnYes = onYes;
        OnYes += Close;
        OnNot = onNot;
        OnNot += Close;

        Open();

    }


}
