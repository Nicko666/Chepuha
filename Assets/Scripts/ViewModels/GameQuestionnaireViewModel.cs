public abstract class GameQuestionnaireViewModel
{
    protected GameModel model;
    

    public GameQuestionnaireViewModel(GameModel gameModel)
    {
        if (this.model != null)
            ViewModelUnsubscribe();

        this.model = gameModel;

        if (this.model != null)
            ViewModelSubscribe();

    }

    void ViewModelSubscribe()
    {
        model.playersNumber.onValueChanged += OutputPlayersNumber;
        model.isByPlayer.onValueChanged += OutputByPlayer;
    }

    void ViewModelUnsubscribe()
    {
        model.playersNumber.onValueChanged -= OutputPlayersNumber;
        model.isByPlayer.onValueChanged -= OutputByPlayer;
    }

    protected virtual void ViewModelUpdate()
    {
        OutputPlayersNumber(model.playersNumber.Value);
        OutputByPlayer(model.isByPlayer.Value);
    }

    protected abstract void OutputPlayersNumber(int value);
    protected abstract void OutputByPlayer(bool value);

    public virtual void InputPlayersNumber(int value)
    {
        model.playersNumber.Value = value;
    }
    public virtual void InputByPlayer(bool value)
    {
        model.isByPlayer.Value = value;
    }


}
