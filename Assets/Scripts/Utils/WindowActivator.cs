using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WindowActivator : MonoBehaviour
{
    Selectable[] _selectables;

    IEnumerable<Selectable> GetSelectables()
    {
        foreach (Transform child in transform)
        {
            Selectable selectable;

            if (child.TryGetComponent<Selectable>(out selectable))
            {
                yield return selectable;
            }
        }

    }

    private void Awake()
    {
        _selectables = GetSelectables().ToArray();

    }

    public void EnableWindow() => Interracteble(true);

    public void DisableWindow() => Interracteble(false);

    public void DeactiveGameObject() => gameObject.SetActive(false);

    //public void ActiveGameObject() => gameObject.SetActive(true);

    void Interracteble(bool value)
    {
        foreach (var selectable in _selectables)
        {
            selectable.interactable = value;
        }

    }


}
