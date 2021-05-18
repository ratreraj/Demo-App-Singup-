using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        void Add(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity FindById(object Id);
        void DeleteById(object Id);


    }
}
