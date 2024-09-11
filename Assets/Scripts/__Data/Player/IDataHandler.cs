namespace Data.Player
{
    public interface IDataHandler<T>
    {
        public T Load();
        public void Save(T data);
    }
}