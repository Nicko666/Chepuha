using UnityEngine;
using UnityEngine.UI;

public class BackgroundPresenter : MonoBehaviour
{
    [SerializeField] private Image[] _backgroundImages;
    [SerializeField] private Image _vignetteImage;

    internal void OutputBackgroundModel(Color color)
    {
        foreach (var backgroundImage in _backgroundImages)
            backgroundImage.color = new(color.r, color.g, color.b, backgroundImage.color.a);
    }

    internal void OutputVignetteModel(float vignetteModel) =>
        _vignetteImage.color = new Color(_vignetteImage.color.r, _vignetteImage.color.g, _vignetteImage.color.b, -vignetteModel + 1);
}