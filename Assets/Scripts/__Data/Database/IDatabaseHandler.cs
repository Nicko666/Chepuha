using UnityEngine;

namespace Data.Database
{
    public abstract class IDatabaseHandler<T> : ScriptableObject
    {
        public abstract T Load();
    }
}