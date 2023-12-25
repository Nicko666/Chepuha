using DG.Tweening;
using UnityEngine;

public class DOSlideRects : DOSlide
{
    [SerializeField] RectTransform startPosition;
    [SerializeField] RectTransform currentPosition;
    [SerializeField] RectTransform endPosition;

    [SerializeField] RectTransform currentRectTransform;
    [SerializeField] RectTransform nextRectTransform;

    public override void Next()
    {
        currentRectTransform.DOKill(true);
        nextRectTransform.DOKill(true);

        if (!invert)
        {
            nextRectTransform.position = startPosition.position;

            nextRectTransform.DOMove(currentPosition.position, duration);
            currentRectTransform.DOMove(endPosition.position, duration);

        }
        else
        {
            nextRectTransform.position = endPosition.position;

            nextRectTransform.DOMove(currentPosition.position, duration);
            currentRectTransform.DOMove(startPosition.position, duration);
        }

        var tempRectTransform = currentRectTransform;
        currentRectTransform = nextRectTransform;
        nextRectTransform = tempRectTransform;

    }


}