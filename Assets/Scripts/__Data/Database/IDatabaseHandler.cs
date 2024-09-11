namespace Data.Database
{
    public interface IDatabaseHandler<T>
    {
        public T Load();
    }
}