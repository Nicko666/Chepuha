namespace Data.Player
{
    public interface IUseData<T>
    {
        void LoadData(T data);
        void SaveData(ref T data);
    }
}