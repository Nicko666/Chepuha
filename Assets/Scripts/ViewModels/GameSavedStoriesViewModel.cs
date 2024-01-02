public abstract class GameSavedStoriesViewModel
{
    protected GameModel model;


    public GameSavedStoriesViewModel(GameModel gameModel)
    {
        if (this.model != null)
            ViewModelUnsubscribe();

        this.model = gameModel;

        if (this.model != null)
            ViewModelSubscribe();

        if (this.model != null)
            ViewModelUpdate();

    }

    void ViewModelSubscribe()
    {
        model.savedStores.onValueChanged += OutputSavedStores;
    }

    void ViewModelUnsubscribe()
    {
        model.savedStores.onValueChanged -= OutputSavedStores;
    }

    protected virtual void ViewModelUpdate()
    {
        OutputSavedStores(model.savedStores.Value);
    }

    protected abstract void OutputSavedStores(string[] collection);

    public virtual void InputSavedStores(string[] collection)
    {
        model.savedStores.Value = collection;
    }


}