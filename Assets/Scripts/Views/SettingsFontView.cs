using System.Linq;
using TMPro;
using UnityEngine;

public abstract class SettingsFontView : MonoBehaviour, IInit<SettingsFonrViewModel>
{
    SettingsFonrViewModel viewModel;

    public void Init(SettingsFonrViewModel viewModel)
    {
        if (this.viewModel != null)
            ViewUnsubscribe();

        this.viewModel = viewModel;
        
        if (this.viewModel != null)
            ViewSubscribe();

        ViewUpdate();

    }

    void ViewSubscribe()
    {
        viewModel.maxIndex.onValueChanged += OutputMaxIndex;
        viewModel.selectedFontIndex.onValueChanged += OutputSelectedFontIndex;
        viewModel.selectedFont.onValueChanged += OutputSelectedFont;
    }

    void ViewUnsubscribe()
    {
        viewModel.maxIndex.onValueChanged -= OutputMaxIndex;
        viewModel.selectedFontIndex.onValueChanged -= OutputSelectedFontIndex;
        viewModel.selectedFont.onValueChanged -= OutputSelectedFont;
    }

    void ViewUpdate()
    {
        OutputMaxIndex(viewModel.maxIndex.Value);
        OutputSelectedFontIndex(viewModel.selectedFontIndex.Value);
        OutputSelectedFont(viewModel.selectedFont.Value);
    }

    public void InputIndex(float value)
    {
        viewModel.InputSelectedFontIndex((int)value);
    }

    public abstract void OutputMaxIndex(int value);

    public abstract void OutputSelectedFontIndex(int value);

    public abstract void OutputSelectedFont(TMP_FontAsset value);


}
