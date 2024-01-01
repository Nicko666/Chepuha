using TMPro;
using UnityEngine;

public class GameQuestionnaireSettingsTMPView : GameQuestionnaireSettingsView
{
    [SerializeField] TMP_Text playersNumberText;
    [SerializeField] TMP_Text byPlayerText;


    protected override void OutputQueue(bool byPlayer)
    {
        byPlayerText.text = byPlayer? "по игроку" : "по истории";

    }

    protected override void OutputPlayerNumbers(int value)
    {
        switch (value)
        {
            case 1:
                playersNumberText.text = "1 игрок";
                break;
            case > 4:
                playersNumberText.text = $"{value} игроков";
                break;
            case > 1:
                playersNumberText.text = $"{value} игрока";
                break;
        }

    }


}