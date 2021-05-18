using DemoApp.DAL;
using DemoApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Repository
{
    public interface IUnitOfWork
    {
        IUsersRepository UsersRespo { get; }

        IRepository<Countries> CountriesRepo { get; }

        IRepository<Cities> CitiesRepo { get; }

        void SaveChanges();


    }
}
