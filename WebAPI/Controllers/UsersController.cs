using Business.Abstract;
using Core.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("updateprofile")]
        public IActionResult UpdateProfile(User user,IFormFile file)
        {
           var data =  _userService.UpdateProfile(user,file);
            if (data.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("getcurrentuser")]
        public IActionResult GetCurrent(User user)
        {
            var data = _userService.GetByMail(user.Email);

            return Ok(data);
        }
    }
}
