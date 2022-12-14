using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milyoncu.Dto.Models;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using Milyoncu.Uow;
using System.Net.Mime;

namespace Milyoncu.API.Controllers
{
    [Route("[controller]/[action]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRep _userRep;
        private readonly IUow _uow;
        UserModel _model;
        public UserController(IUserRep userRep, IUow uow, UserModel model)
        {
            _userRep = userRep;
            _uow = uow;
            _model = model;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRep.GetUsers();
            return this.Ok(users);
        }
        [HttpGet("{UserId:int}")]
        public IActionResult GetUserbyId(int UserId)
        {
            var users = _userRep.GetUserbyId(UserId);
            return this.Ok(users);
        }
        public IActionResult Register()
        {
            _model.User = new User();

            return this.Ok(_model);
        }

        [HttpPost]
        public IActionResult Register(UserModel m)
        {
            m.User = _uow._userRep.CreateUser(m.User);
            if (m.User.Error == false)
            {
                var user = _uow._userRep.Add(m.User);
                _uow.Commit();
                return this.Ok(user);
                //return RedirectToAction("Index");
            }
            else
            {
                m.Message = $"{m.User.Mail} already exist.";

                return this.Ok(m);
            }

        }
        [HttpPut]
        public IActionResult UpdateUser(User u)
        {
            var user = _userRep.UpdateUser(u);
            _uow.Commit();
            return this.Ok(user);
        }
        [HttpDelete]
        public IActionResult Delete(User u)
        {
            var user = _userRep.DeleteUser(u);
            _uow.Commit();
            return this.Ok(user);
        }
        [HttpDelete("{UserId:int}")]
        public IActionResult DeletebyUserId(int UserId)
        {
            _uow._userRep.DeletebyUserId(UserId);
            _uow.Commit();
            return this.Ok();
        }




    }
}
