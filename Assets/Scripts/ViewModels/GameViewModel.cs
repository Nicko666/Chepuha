using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameViewModel
{
    protected GameModel model;
    
    public GameViewModel(GameModel gameModel)
    {
        if (this.model != null)
            ViewModelUnsubscribe();

        this.model = gameModel;

        if (this.model != null)
            ViewModelSubscribe();

        

    }

    protected abstract void ViewModelSubscribe();

    protected abstract void ViewModelUnsubscribe();


}
