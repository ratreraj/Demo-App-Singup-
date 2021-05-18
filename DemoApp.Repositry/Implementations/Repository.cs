
using DemoApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Repository.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _Db;
        public Repository(DbContext db)
        {
            _Db = db;
        }

        public void Add(TEntity entity)
        {
            _Db.Set<TEntity>().Add(entity);
        }

        public void DeleteById(object Id)
        {
            TEntity entity = _Db.Set<TEntity>().Find(Id);
            if (entity != null)
                _Db.Set<TEntity>().Remove(entity);
        }

        public TEntity FindById(object Id)
        {
            return _Db.Set<TEntity>().Find(Id);

        }

        public IEnumerable<TEntity> GetAll()
        {
            return _Db.Set<TEntity>().ToList();

        }

        public void Update(TEntity entity)
        {
            _Db.Set<TEntity>().Update(entity);

        }
    }
}
