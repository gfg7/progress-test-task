namespace Progress.Interfaces
{
    public interface IEntity<T> where T : notnull
    {
        T GetKey();
        T SetKey();
        bool IdEquals(T key);
    }
}