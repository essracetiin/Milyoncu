using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public UserController( IUserRep userRep, IUow uow)
        {
            _userRep = userRep;
            _uow = uow;
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
        [HttpPost]
        public IActionResult CreateUser(User u)
        {
            var c = _userRep.CreateUser(u);
            _uow.Commit();
            return this.Ok(c);
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
