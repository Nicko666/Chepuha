using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AndroidInputFieldFix : MonoBehaviour
{
    TMP_InputField inputField;

    string text;

    TouchScreenKeyboard keyboard;

    public UnityEvent<string> onSubmit;

    void Awake()
    {
        inputField = GetComponent<TMP_InputField>();

        inputField.onValueChanged.AddListener(OnValueChanged);
        inputField.onEndEdit.AddListener(OnEndEdit);

        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        keyboard.active = false;

    }

    public void ChangeText(string newText)
    {
        this.text = newText;
        inputField.text = newText;
        inputField.MoveToEndOfLine(false, false);

    }

    void OnValueChanged(string text)
    {
        if (text == this.text)
        {
            return;
        }

        if (keyboard.status == TouchScreenKeyboard.Status.Visible)
        {
            this.text = text;
        }

        inputField.text = this.text;

        if (keyboard.status != TouchScreenKeyboard.Status.Visible)
        {
            inputField.MoveToEndOfLine(false, false);
        }

    }

    void OnEndEdit(string text)
    {
        if (keyboard.status == TouchScreenKeyboard.Status.Done)
        {
            onSubmit?.Invoke(text);
        }

    }


}
