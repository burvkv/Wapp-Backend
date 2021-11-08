using Core.Entity.Abstract;

namespace Entity.Concrete.Dto
{
    public class UserForRegisterDto:IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
