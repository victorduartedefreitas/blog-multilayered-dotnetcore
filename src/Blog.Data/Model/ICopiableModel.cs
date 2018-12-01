namespace Blog.Data.Model
{
    public interface ICopiableModel<T>
        where T : class
    {
        void CopyFrom(T source);
    }
}
