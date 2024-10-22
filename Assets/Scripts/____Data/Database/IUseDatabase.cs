namespace Data.Database
{
    public interface IUseDatabase<T>
    {
        void LoadData(T data);
    }
}
