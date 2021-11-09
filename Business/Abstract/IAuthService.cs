using Core.Entity.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password,int[] userOperationClaimIds);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string username);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }

}
