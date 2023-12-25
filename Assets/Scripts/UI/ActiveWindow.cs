using UnityEngine;

public class ActiveWindow : Window
{
    protected override void OpenAnimation(bool value)
    {
        gameObject.SetActive(value);
    }

}
