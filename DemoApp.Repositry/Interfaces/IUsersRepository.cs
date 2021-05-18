using DemoApp.DAL;
using DemoApp.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Repository.Interfaces
{
    public interface IUsersRepository : IRepository<Users>
    {
        IEnumerable<UserModel> GetAllUser();

        IEnumerable<Countries> GetCountries();

        IEnumerable<Cities> GetCities(object CountryId);

    }
}
