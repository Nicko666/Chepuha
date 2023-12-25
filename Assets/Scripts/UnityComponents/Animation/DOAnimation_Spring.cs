using DG.Tweening;
using UnityEngine;

public class DOAnimation_Spring : MonoBehaviour, IDOAnimationObject
{
    [SerializeField] RectTransform rectTransform;
    
    float duration;
    float scaleFactor;


    public void GetManager(DOAnimationManager animationManager)
    {
        duration = animationManager.duration/2;
        scaleFactor = animationManager.buttonScaleFactor;

    }

    public void DownAnimation()
    {
        rectTransform.DOKill(false);
        rectTransform.DOScale(scaleFactor, duration);

    }

    public void UpAnimation()
    {
        rectTransform.DOKill(false);
        rectTransform.DOScale(1.0f, duration);
    
    }


}
