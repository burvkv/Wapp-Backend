using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.Dto
{
    public class UserForLoginDto:IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
