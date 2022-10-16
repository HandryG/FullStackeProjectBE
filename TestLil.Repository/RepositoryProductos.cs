using TestLil.Entities;
using TestLil.DataAccess;
using TestLil.Abstraction;

namespace TestLil.Repository
{
    public interface IRepositoryProductos<T> : ICrud<T>
    {
        
    }

    public class RepositoryProductos<T> : IRepositoryProductos<T> where T : class, IEntity
    {
        IDbContext<T> _db;

        public RepositoryProductos(IDbContext<T> db)
        {
            _db = db;
        }

        public void DeleteById(int id)
        {
            _db.DeleteById(id);
        }

        public IList<T> GetAll()
        {
            return _db.GetAll();
        }

        public T GetById(int id)
        {
            return _db.GetById(id);
        }

        public T GetBySearchKey(string searchKey)
        {
            return _db.GetBySearchKey(searchKey);
        }

        public T save(T entity)
        {
            return _db.save(entity);
        }

        public T Update(T entity)
        {
            return _db.Update(entity);
        }
    }
}