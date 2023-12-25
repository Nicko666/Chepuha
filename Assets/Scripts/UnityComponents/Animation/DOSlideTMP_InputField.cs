using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DOSlideTMP_InputField : DOSlideRects
{
    [SerializeField] TMP_InputField currentInputField;
    [SerializeField] TMP_InputField nextInputField;


    public UnityEvent<string> onValueChange;
    public UnityEvent<string> onEndEdit;
    

    public virtual string text
    {
        get { return currentInputField.text; }
        set
        {
            nextInputField.text = value;
            Next();
        }
    }


    private void OnEnable()
    {
        SubscribeCurrent();
    }

    private void OnDisable()
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

        ActivateInputField();

    }

    public void ActivateInputField()
    {
        currentInputField.ActivateInputField();
    }

    public void SubscribeCurrent()
    {
        currentInputField.onValueChanged.AddListener(TextInput);
        currentInputField.onEndEdit.AddListener(EndEdit);
    }
    public void UnsubscribeCurrent()
    {
        currentInputField.onValueChanged.RemoveListener(TextInput);
        currentInputField.onEndEdit.RemoveListener(EndEdit);
    }


    public void TextInput(string value) => onValueChange?.Invoke(value);
    public void EndEdit(string value) => onEndEdit?.Invoke(value);


}
