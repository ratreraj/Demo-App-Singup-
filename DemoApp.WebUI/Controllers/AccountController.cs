using ASPDotNetDemoFun.Data;
using DemoApp.DAL;
using DemoApp.WebUI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoApp.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly AppDbContext _db;

        public AccountController(AppDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {

            IEnumerable<Users> data = (from us in _db.Users.ToList()
                                       join
         cty in GetCountriesToJson().countries on
         us.Country equals cty.CountryId.ToString()
                                       join ct in GetCityJson().cities
                                       on us.City equals ct.CityId
                                       select new Users()
                                       {
                                           UserId = us.UserId,
                                           Name = us.Name,
                                           UserName = us.UserName,
                                           Contcat = us.Contcat,
                                           City = ct.CityName,
                                           Country = cty.CountryName,
                                           Gender = us.Gender
                                       }).ToList();


            return View(data);
        }

        public IActionResult Delete(int UserId)
        {
            Users user = _db.Users.Find(UserId);
            if (user != null)
            {
                _db.Remove(user);
                _db.SaveChanges();
                Notify("Data Delete successfully");
            }

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int UserId)
        {
            Onload();
            UserModel UserModelData = new UserModel();
            Users data = _db.Users.Find(UserId);
            if (data != null)
            {
                UserModelData = new()
                {
                    UserId = data.UserId,
                    Name = data.Name,
                    UserName = data.UserName,
                    Password = data.Password,
                    ConfirmPassword = data.Password,
                    Contcat = data.Contcat,
                    Country = data.Country,
                    City = data.City,
                    Gender = data.Gender,
                    Terms = data.Terms
                };
                ViewBag.City = data.City;
            }


            return View("SingUp", UserModelData);
        }
        [HttpPost]
        public IActionResult Edit(UserModel model)
        {
            try
            {
                Users data = new()
                {
                    UserId = model.UserId,
                    Name = model.Name,
                    UserName = model.UserName,
                    Password = model.Password,
                    Contcat = model.Contcat,
                    Country = model.Country,
                    City = model.City,
                    Gender = model.Gender,
                    Terms = model.Terms
                };

                if (ModelState.IsValid)
                {
                    _db.Users.Update(data);
                    _db.SaveChanges();


                    Notify("Data updated successfully");


                }

            }
            catch
            {

            }

            return RedirectToAction("SingUp", "Account");

        }

        public IActionResult SingUp()
        {
            Onload();
            //Notify("Data saved successfully");
            return View();
        }
        [HttpPost]
        public IActionResult SingUp(UserModel model)
        {
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                Users Users = new()
                {
                    Name = model.Name,
                    UserName = model.UserName,
                    Password = model.Password,
                    Contcat = model.Contcat,
                    Gender = model.Gender,
                    Terms = model.Terms,
                    Country = model.Country,
                    City = model.City

                };

                _db.Users.Add(Users);
                _db.SaveChanges();

                Notify("Data saved successfully");

            }
            //Onload();
            //return View();
            return RedirectToAction("SingUp", "Account");
        }



        private Countries GetCountry(string id)
        {
            Countries Countries = (from cy in GetCountriesToJson().countries.Where(x => x.CountryId.Equals(Convert.ToInt32(id)))
                                   select cy).Select(p => new Countries()
                                   {
                                       CountryId = p.CountryId.ToString(),
                                       CountryName = p.CountryName
                                   }).SingleOrDefault();

            return Countries;
        }

        private Cities GetCity(string id)
        {
            Cities Cities = (from cy in GetCityJson().cities.Where(x => x.CityId.Equals(id))
                             select cy).Select(p => new Cities()
                             {
                                 CityId = p.CityId,
                                 CityName = p.CityName
                             }).SingleOrDefault();
            return Cities;
        }
        #region Get Country, State , City master from json 
        private RootCountries GetCountriesToJson()
        {

            var options = new JsonSerializerOptions
            {
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string CountriesJson = System.IO.File.ReadAllText(contentRootPath + "/data/countries.json");
            RootCountries Countriesdata = JsonSerializer.Deserialize<RootCountries>(CountriesJson, options);
            return Countriesdata;

        }

        private RootStates GetStateJson()
        {
            var options = new JsonSerializerOptions
            {
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string StatesJson = System.IO.File.ReadAllText(contentRootPath + "/data/states.json");
            RootStates Statesdata = JsonSerializer.Deserialize<RootStates>(StatesJson, options);

            return Statesdata;

        }


        private RootCity GetCityJson()
        {
            var options = new JsonSerializerOptions
            {
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string CitiesJson = System.IO.File.ReadAllText(contentRootPath + "/data/cities.json");

            RootCity Citiesdata = JsonSerializer.Deserialize<RootCity>(CitiesJson, options);


            return Citiesdata;

        }
        #endregion
        private void Onload()
        {
            ViewBag.Country = new SelectList(GetCountriesToJson().countries, "CountryId", "CountryName");
            ViewBag.Genders = new List<string>() { "Male", "Female" };
            ViewBag.City = null;



        }
        [HttpPost]
        public ActionResult GetCityList(string CountryId)
        {

            if (!string.IsNullOrEmpty(CountryId))
            {
                var Citieydata = (from st in GetStateJson().states
                                  join cty in GetCityJson().cities
                                  on st.StateId equals cty.StateId
                                  select new
                                  {
                                      st.CountryId,
                                      cty.CityId,
                                      cty.CityName
                                  }).ToList().Where(x => x.CountryId.Equals(CountryId));
                return Json(new SelectList(Citieydata, "CityId", "CityName"));
            }
            else
            {
                return Json(new SelectList(string.Empty, "CityId", "CityName"));
            }

        }

    }
}
