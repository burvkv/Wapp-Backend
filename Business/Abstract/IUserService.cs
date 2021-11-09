using Core.Entity.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user, int[] userOperationClaimIds);
        User GetByMail(string username);
        IResult UpdateProfile(User user,IFormFile file);
    }
}
