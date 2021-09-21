using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.BusinessLogicLayer.IServices;
namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService _userService)
        {
            this._userService = _userService;
        }

        [Route("data")]
        [HttpGet]
        public List<User> Get()
        {
            return _userService.GetUsers();
        }
        [Route("count")]
        [HttpGet]
        public int[] GetCount()
        {
            return _userService.GetCount();
          
        }

        [HttpPut]
        public IActionResult Check(User user)
        {

            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
                
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

    }
}
