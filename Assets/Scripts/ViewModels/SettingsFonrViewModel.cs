using TMPro;
using Unity.Mathematics;

public class SettingsFonrViewModel : SettingsViewModel
{
    TMP_FontAsset[] fontAssets;

    public ReactiveProperty<int> maxIndex = new();
    public ReactiveProperty<int> selectedFontIndex = new();
    public ReactiveProperty<TMP_FontAsset> selectedFont = new();


    public SettingsFonrViewModel(SettingsModel model, StaticData staticData) : base(model)
    {
        fontAssets = staticData.fontAssets;

        ViewModelUpdate();
    }

    protected override void ViewModelSubscribe()
    {
        model.fontIndex.onValueChanged += OutputSelectedFontIndex;
    }

    protected override void ViewModelUnsubscribe()
    {
        model.fontIndex.onValueChanged -= OutputSelectedFontIndex;
    }

    void ViewModelUpdate()
    {
        OutputMaxIndex(fontAssets.Length - 1);
        OutputSelectedFontIndex(model.fontIndex.Value);
    }


    void OutputMaxIndex(int value)
    {
        maxIndex.Value = value;
    }

    public void InputSelectedFontIndex(int value)
    {
        value = math.clamp(value, 0, fontAssets.Length - 1);

        model.fontIndex.Value = value;
    }
    void OutputSelectedFontIndex(int value)
    {
        value = math.clamp(value, 0, fontAssets.Length - 1);
        selectedFontIndex.Value = value;

        OutputSelectedFont(value);
    }
    void OutputSelectedFont(int value)
    {
        selectedFont.Value = fontAssets[value];
    }


}
