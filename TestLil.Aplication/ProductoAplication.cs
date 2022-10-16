using TestLil.Abstraction;
using TestLil.Entities;
using TestLil.Repository;

namespace TestLil.Aplication
{
    public interface IProductoAplication<T>: ICrud<T>
    {
        
    }
    public class ProductoAplication<T> : IProductoAplication<T> where T : class ,IEntity
    {
        private readonly IRepositoryProductos<T> _repository;

        public ProductoAplication(IRepositoryProductos<T> repository)
        {
            _repository = repository;
        }

        public T save(T entity)
        {
            return _repository.save(entity);
        }

        public T Update(T entity)
        {
            return _repository.Update(entity);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public T GetBySearchKey(string searchKey)
        {
            return _repository.GetBySearchKey(searchKey);
        }

        public void DeleteById(int id)
        {
           _repository.DeleteById(id);
        }
    }
}