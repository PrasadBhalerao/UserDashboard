using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.IService;
using Dashboard.Persistence.Models;
using Dashboard.Persistence.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Web.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [Route("api/Users")]
        [Route("api/Users/{username?}")]
        public IEnumerable<UserVO> Users(string username)
        {
            return this._userService.GetUsers(username);
        }

        [HttpPut("api/User/[action]")]
        public void Save(User user)
        {
            this._userService.UpsertUser(user);
        }

        [HttpDelete("api/User/[action]/{userId}")]
        public void Delete(int userId)
        {
            this._userService.DeleteUser(userId);
        }
    }
}