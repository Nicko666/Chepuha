using UnityEngine;

public abstract class GameQuestionnaireView : MonoBehaviour
{
    protected GameQuestionnaireViewModel viewModel;

    public void Init(GameQuestionnaireViewModel gameViewModel)
    {
        if (this.viewModel != null)
            ViewModelUnsubscribe();

        this.viewModel = gameViewModel;

        if (this.viewModel != null)
            ViewModelSubscribe();

        ViewModelUpdate();

    }

    protected abstract void ViewModelSubscribe();

    protected abstract void ViewModelUnsubscribe();

    protected abstract void ViewModelUpdate();


}