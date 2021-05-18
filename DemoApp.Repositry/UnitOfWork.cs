using DemoApp.DAL;
using DemoApp.Repository.Interfaces;
using DemoApp.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }

        private IUsersRepository _UsersRepo;
        private IRepository<Countries> _CountriesRepo;
        private IRepository<Cities> _CitiesRepo;
        public IUsersRepository UsersRespo
        {
            get {

                if (_UsersRepo == null)
                    _UsersRepo = new UsersRepository(_db);
                return _UsersRepo;
            }
        }

        public IRepository<Countries> CountriesRepo
        {

            get {
                if (_CountriesRepo == null)
                    _CountriesRepo = new Repository<Countries>(_db);
                return _CountriesRepo;


            }
        }

        public IRepository<Cities> CitiesRepo
        {
            get {

                if (_CitiesRepo == null)
                    _CitiesRepo = new Repository<Cities>(_db);
                return _CitiesRepo;
            }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
