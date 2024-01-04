using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SettingsColorSliderView : SettingsColorView
{
    //[SerializeField] Graphic[] colorObjects;
    [SerializeField] Light2D[] lightObjects;
    [SerializeField] Slider slider;


    public override void Init(SettingsColorViewModel viewModel)
    {
        base.Init(viewModel);

        ViewModelUpdate();

    }

    protected override void ViewModelSubscribe()
    {
        viewModel.colors.onValueChanged += OutputColors;
        viewModel.selectedColorIndex.onValueChanged += OutputSelectedColorIndex;
        viewModel.selectedColor.onValueChanged += OutputSelectedColor;
    }

    protected override void ViewModelUnsubscribe()
    {
        viewModel.colors.onValueChanged -= OutputColors;
        viewModel.selectedColorIndex.onValueChanged -= OutputSelectedColorIndex;
        viewModel.selectedColor.onValueChanged -= OutputSelectedColor;
    }

    void ViewModelUpdate()
    {
        OutputColors(viewModel.colors.Value);
        OutputSelectedColorIndex(viewModel.selectedColorIndex.Value);
        OutputSelectedColor(viewModel.selectedColor.Value);
    }

    void OutputColors(Color[] collection)
    {
        if (collection.Length > 1)
            slider.maxValue = collection.Length - 1;
    }

    void OutputSelectedColor(Color color)
    {
        foreach (var item in lightObjects)
        {
            item.color = color;
        }
    }

    void OutputSelectedColorIndex(int value)
    {
        slider.value = value;
    }
    public void InputSelectedColorIndex(float value)
    {
        int convertedValue = (int)value;
        viewModel.InputColorIndex(convertedValue);
    }


}