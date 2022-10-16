namespace TestLil.Abstraction
{
    public interface ICrud<T>
    {
        T save(T entity);
        T Update(T entity);
        IList<T> GetAll();
        T GetById(int id);
        T GetBySearchKey(string searchKey);
        void DeleteById(int id);

    }
}