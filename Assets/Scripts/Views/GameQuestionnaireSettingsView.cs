public abstract class GameQuestionnaireSettingsView : InitView<GameQuestionnaireViewModel>
{
    protected GameQuestionnaireViewModel viewModel;


    public override void Init(GameQuestionnaireViewModel viewModel)
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
        viewModel.playersNumber.onValueChanged += OutputPlayerNumbers;

    }

    void ViewModelUnsubscribe()
    {
        viewModel.isByPlayer.onValueChanged -= OutputQueue;
        viewModel.playersNumber.onValueChanged -= OutputPlayerNumbers;

    }

    void ViewModelUpdate()
    {
        OutputQueue(viewModel.isByPlayer.Value);
        OutputPlayerNumbers(viewModel.playersNumber.Value);

    }


    protected abstract void OutputQueue(bool byPlayer);
   
    public void InputQueue()
    {
        viewModel.InputQueue();

    }

    public void InputPlayerNumbers()
    {
        viewModel?.InputNextPlayersNumber();
    }

    protected abstract void OutputPlayerNumbers(int value);
    

}