using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DOSlideTMP_InputField : DOSlideRects
{
    [SerializeField] TMP_InputField currentInputField;
    [SerializeField] TMP_InputField nextInputField;


    public UnityEvent<string> onValueChange;
    public UnityEvent<string> onSubmit;


    bool currentSubscribed = false;


    public virtual string text
    {
        get { return currentInputField.text; }
        set
        {
            nextInputField.text = value;
            Next();
        }
    }

    private void Awake()
    {
        SubscribeCurrent();
    }

    private void OnDestroy()
    {
        UnsubscribeCurrent();
    }

    public override void Next()
    {
        base.Next();

        UnsubscribeCurrent();

        var tempInputField = currentInputField;
        currentInputField = nextInputField;
        nextInputField = tempInputField;

        SubscribeCurrent();
        
        if (!invert)
            ActivateInputField();
    }

    public void ActivateInputField()
    {
        currentInputField.ActivateInputField();
    }

    public void SubscribeCurrent()
    {
        if (!currentSubscribed)
        {
            currentInputField.onValueChanged.AddListener(TextInput);
            currentInputField.onSubmit.AddListener(Submit);
            currentSubscribed = true;
        }
    }
    public void UnsubscribeCurrent()
    {
        currentInputField.onValueChanged.RemoveListener(TextInput);
        currentInputField.onSubmit.RemoveListener(Submit);
        currentSubscribed = false;
    }


    public void TextInput(string value) => onValueChange?.Invoke(value);
    public void Submit(string value)
    {
        onSubmit?.Invoke(value);
    }
    

}
