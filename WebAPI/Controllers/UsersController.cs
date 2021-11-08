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
        IImageService _imageService;
        public UsersController(IUserService userService , IImageService imageService)
        {
            _userService = userService;
            _imageService = imageService;
        }

        [HttpPost("updateprofile")]
        public IActionResult UpdateProfile(IFormFile file,[FromForm] User user)
        {
           var data =  _userService.UpdateProfile(user,file);
          
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }

        [HttpGet("getcurrentuser")]
        public IActionResult GetCurrent(User user)
        {
            var data = _userService.GetByMail(user.Username);

            return Ok(data);
        }
    }
}
