using UnityEngine;

public abstract class DOSlide : MonoBehaviour, IDOAnimationObject
{
    float _duration;
    bool play;

    protected float duration => (play) ? _duration : 0.0f;
    
    public bool invert;

    private void OnEnable()
    {
        play = true;
    }

    public void GetManager(DOAnimationManager animationManager)
    {
        _duration = animationManager.duration;
    }

    public abstract void Next();

    private void OnDisable()
    {
        play = false;
    }


}
