using DemoApp.DAL;
using DemoApp.DomainModels;
using DemoApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Repository.Implementations
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public AppDbContext Context
        {
            get
            {
                return _Db as AppDbContext;
            }

        }
        public UsersRepository(DbContext db) : base(db)
        {

        }
        public IEnumerable<UserModel> GetAllUser()
        {
            var data = (from us in Context.Users
                        join
                        cty in Context.Countries on
                        us.Country equals cty.CountryId.ToString()
                        join ct in Context.Cities
                        on us.City equals ct.CityId
                        select new UserModel()
                        {
                            UserId = us.UserId,
                            Name = us.Name,
                            UserName = us.UserName,
                            Contcat = us.Contcat,
                            City = ct.CityName,
                            Country = cty.CountryName,
                            Gender = us.Gender
                        }).ToList();

            return data;
        }

        public IEnumerable<Countries> GetCountries()
        {
            var data = (from cy in Context.Countries
                        select cy).ToList();
            return data;
        }

        public IEnumerable<Cities> GetCities(object CountryId)
        {
            var data = (from ct in Context.Cities
                        select ct
                        ).Where(x => x.CountryId.Equals(CountryId)).ToList();

            return data;
        }
    }
}
