﻿using UnityEngine;

public abstract class GameSavedStoriesView : MonoBehaviour
{
    protected GameSavedStoriesViewModel viewModel;


    public virtual void Init(GameSavedStoriesViewModel viewModel)
    {
        if (this.viewModel != null)
            ViewModelUnsubscribe();

        this.viewModel = viewModel;

        if (this.viewModel != null)
            ViewModelSubscribe();

    }

    protected abstract void ViewModelSubscribe();
    
    protected abstract void ViewModelUnsubscribe();


}