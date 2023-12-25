using TMPro;
using UnityEngine;

public class GameQuestionnaireSettingsView : GameQuestionnaireView
{
    [SerializeField] TMP_Text playersNumberText;
    [SerializeField] TMP_Text byPlayerText;


    protected override void ViewModelSubscribe()
    {
        viewModel.isByPlayer.onValueChanged += OutputQueue;
        viewModel.answersListsCount.onValueChanged += OutputPlayerNumbers;

    }

    protected override void ViewModelUnsubscribe()
    {
        viewModel.isByPlayer.onValueChanged -= OutputQueue;
        viewModel.answersListsCount.onValueChanged -= OutputPlayerNumbers;

    }

    protected override void ViewModelUpdate()
    {
        OutputQueue(viewModel.isByPlayer.Value);
        OutputPlayerNumbers(viewModel.answersListsCount.Value);

    }


    void OutputQueue(bool byPlayer)
    {
        byPlayerText.text = byPlayer? "по игроку" : "по истории";

    }
    public void InputQueue()
    {
        viewModel.InputQueue();

    }

    public void InputPlayerNumbers()
    {
        viewModel?.InputAnswersListsCount();

    }

    void OutputPlayerNumbers(int value)
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