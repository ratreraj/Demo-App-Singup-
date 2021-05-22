using DemoApp.DAL;
using DemoApp.DomainModels;
using DemoApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUnitOfWork _uow;
        public UserController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IEnumerable<UserModel> GetUsers()
        {
            return _uow.UsersRespo.GetAllUser();

        }

        [HttpGet("{id}")]
        public Users GetUser(int id)
        {
            return _uow.UsersRespo.FindById(id);
        }

        [HttpPost]
        public IActionResult AddUser(Users model)
        {
            try
            {
                _uow.UsersRespo.Add(model);
                _uow.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);

            }
            catch (Exception)

            {
                return StatusCode(StatusCodes.Status500InternalServerError);

                throw;
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, Users Model)
        {
            try
            {
                if (id != Model.UserId)
                    return BadRequest();

                _uow.UsersRespo.Update(Model);
                _uow.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                throw;
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _uow.UsersRespo.DeleteById(id);
                _uow.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                throw;
            }

        }
    }
}
