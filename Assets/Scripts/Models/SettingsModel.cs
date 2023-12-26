public class SettingsModel : ILocaldataModel
{
    public ReactiveProperty<float> volume = new();

    public ReactiveProperty<int> fontIndex = new();

    public ReactiveProperty<int> colorIndex = new();


    public SettingsModel(LocalData localData)
    {
        volume.Value = localData.Volume;
        fontIndex.Value = localData.Font;
        colorIndex.Value = localData.Color;

    }

    public void Save(ref LocalData localData)
    {
        localData.Volume = volume.Value;
        localData.Font = fontIndex.Value;
        localData.Color = colorIndex.Value;

    }


}