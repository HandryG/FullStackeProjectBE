using Microsoft.EntityFrameworkCore;
using TestLil.Abstraction;
using TestLil.Entities;

namespace TestLil.DataAccess
{

    
    public class DbContext<T> : IDbContext<T> where T : class, IEntity
    {
        DbSet<T> _items; 
        ApiDbContext _ctx;

        public DbContext(ApiDbContext ctx)
        {
            _items = ctx.Set<T>();
            _ctx = ctx;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            return _items.ToList(); //Retorna los activos
        }

        public T GetById(int id)
        {
            return _items.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }

        public T GetBySearchKey(string searchKey)
        {
            return _items.Where(i => i.Code.Equals(searchKey)).FirstOrDefault();
        }

        public T save(T entity)
        {
            _items.Add(entity);
            _ctx.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _items.Update(entity);
            _ctx.SaveChanges();
            return entity;
        }
    }
}