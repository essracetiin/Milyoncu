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
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRep _userRep;
        private readonly IUow _uow;
        APIResponseModel _response;
        public UserController(IUserRep userRep, IUow uow, APIResponseModel response)
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
        public APIResponseModel Register(UserDTO user)
        {
            //user = _userRep.CreateUser(user);
            try
            {
                if (user.Error)
                {
                    _response.Error = true;
                    user.Message = _response.Message;
                }
                else
                {
                    var result = _userRep.CreateUser(user);
                    //_uow._userRep.Add(user.Map());
                    //var x = user.Map();
                    if (!user.Error)
                    {
                        _uow.Commit();
                        _response.Message = "Kayıt başarıyla oluşturuldu.";
                    }
                    _response.Error = result.Error;
                    _response.Message = result.Message;
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
