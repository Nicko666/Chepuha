using Unity.Mathematics;
using UnityEngine;

public class SettingsColorViewModel : SettingsViewModel
{
    public ReactiveProperty<Color[]> colors = new();
    public ReactiveProperty<int> selectedColorIndex = new();
    public ReactiveProperty<Color> selectedColor = new();


    public SettingsColorViewModel(SettingsModel model, StaticData staticData) : base(model)
    {
        colors.Value = staticData.colors;

        ViewModelUpdate();
    
    }

    protected override void ViewModelSubscribe()
    {
        model.colorIndex.onValueChanged += OutputColorIndex;
        model.colorIndex.onValueChanged += OutputColor;
    }

    protected override void ViewModelUnsubscribe()
    {
        model.colorIndex.onValueChanged -= OutputColorIndex;
        model.colorIndex.onValueChanged -= OutputColor;
    }

    void ViewModelUpdate()
    {
        OutputColorIndex(model.colorIndex.Value);
        OutputColor(model.colorIndex.Value);
    }

    public void InputColorIndex(int value)
    {
        model.colorIndex.Value = value;
    }
    void OutputColorIndex(int value)
    {
        selectedColorIndex.Value = value;        
    }
    void OutputColor(int value)
    {
        value = math.clamp(value, 0, colors.Value.Length);

        selectedColor.Value = colors.Value[value];
    }


}