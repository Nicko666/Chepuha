using System.Linq;
using UnityEngine;

public class DOAnimationManager : MonoBehaviour
{
    public float duration;
    public float buttonScaleFactor;


    private void Awake()
    {
        SetValues();
    }

    void SetValues()
    {
        var objects = GetComponentsInChildren<MonoBehaviour>(true).OfType<IDOAnimationObject>();

        foreach (var obj in objects)
        {
            obj.GetManager(this);
        }

    }


}
