public abstract class GameQuestionnaireViewModelAbstract
{
    protected GameModel model;
    

    public GameQuestionnaireViewModelAbstract(GameModel gameModel)
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
        model.savedStores.onValueChanged += OutputSavedStores;
        model.isByPlayer.onValueChanged += OutputByPlayer;
    }

    void ViewModelUnsubscribe()
    {
        model.playersNumber.onValueChanged -= OutputPlayersNumber;
        model.savedStores.onValueChanged -= OutputSavedStores;
        model.isByPlayer.onValueChanged -= OutputByPlayer;
    }

    protected virtual void ViewModelUpdate()
    {
        OutputPlayersNumber(model.playersNumber.Value);
        OutputSavedStores(model.savedStores.Value);
        OutputByPlayer(model.isByPlayer.Value);
    }

    protected abstract void OutputPlayersNumber(int value);
    protected abstract void OutputSavedStores(string[] collection);
    protected abstract void OutputByPlayer(bool value);

    public virtual void InputPlayersNumber(int value)
    {
        model.playersNumber.Value = value;
    }
    public virtual void InputSavedStores(string[] collection)
    {
        model.savedStores.Value = collection;
    }
    public virtual void InputByPlayer(bool value)
    {
        model.isByPlayer.Value = value;
    }


}
