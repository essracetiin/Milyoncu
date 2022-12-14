using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milyoncu.Dto;
using Milyoncu.Dto.Models;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using Milyoncu.Uow;
using System.Net.Mime;

namespace Milyoncu.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRep _userRep;
        private readonly IUow _uow;
        Response _response;
        public UserController(IUserRep userRep, IUow uow, Response response)
        {
            _userRep = userRep;
            _uow = uow;
            _response = response;
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
        public Response Register(UserDTO user)
        {
            user = _uow._userRep.CreateUser(user);
            try
            {
                if (user.Error)
                {
                    _response.Error = true;
                    user.Message = _response.Message;


                }
                else
                {
                    _uow._userRep.Add(user.Map());
                    var x = user.Map();
                    _uow.Commit();
                    _response.Error = false;
                    _response.Message = "Hesabınız başarı ile oluşturuldu.";
                    return _response;
                }

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.Error = true;

            }
            return _response;

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
