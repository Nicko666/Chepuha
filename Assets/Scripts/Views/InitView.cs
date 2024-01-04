using UnityEngine;

public abstract class InitView<T> : MonoBehaviour
{
    public abstract void Init(T viewModel);

}
