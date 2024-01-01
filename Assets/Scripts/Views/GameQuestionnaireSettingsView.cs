using UnityEngine;

public abstract class GameQuestionnaireSettingsView : MonoBehaviour, IInit<GameQuestionnaireSelectViewModel>
{
    protected GameQuestionnaireSelectViewModel viewModel;


    public void Init(GameQuestionnaireSelectViewModel viewModel)
    {
        if (this.viewModel != null)
            ViewModelUnsubscribe();

        this.viewModel = viewModel;

        if (this.viewModel != null)
            ViewModelSubscribe();

        ViewModelUpdate();

    }

    void ViewModelSubscribe()
    {
        viewModel.isByPlayer.onValueChanged += OutputQueue;
        viewModel.answersListsCount.onValueChanged += OutputPlayerNumbers;

    }

    void ViewModelUnsubscribe()
    {
        viewModel.isByPlayer.onValueChanged -= OutputQueue;
        viewModel.answersListsCount.onValueChanged -= OutputPlayerNumbers;

    }

    void ViewModelUpdate()
    {
        OutputQueue(viewModel.isByPlayer.Value);
        OutputPlayerNumbers(viewModel.answersListsCount.Value);

    }


    protected abstract void OutputQueue(bool byPlayer);
   
    public void InputQueue()
    {
        viewModel.InputQueue();

    }

    public void InputPlayerNumbers()
    {
        viewModel?.InputAnswersListsCount();
    }

    protected abstract void OutputPlayerNumbers(int value);
    

}