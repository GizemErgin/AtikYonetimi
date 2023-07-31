using AtikYonetim.Core.Repo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AtikYonetim.Models.Data.Repo
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        protected readonly DbContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {

            if (context == null)
                throw new ArgumentNullException("dbContext can not be null.");

            _context = context;
            _dbSet = _context.Set<TEntity>();
        }


        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            var data = _dbSet.Where(predicate).FirstOrDefault();
            return data;
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            var item = _dbSet.Add(entity).Entity;
            _context.SaveChanges();
            return item;
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}