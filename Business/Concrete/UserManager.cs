using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Entity.Concrete;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IImageService _imageService;
        IUserOperationClaimService _operationClaimService;

        public UserManager(IUserDal userDal, IImageService imageService, IUserOperationClaimService operationClaimService)
        {
            _userDal = userDal;
            _imageService = imageService;
            _operationClaimService = operationClaimService;

        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [CacheRemoveAspect("IUserServise.Get")]
        [SecuredOperation("Admin,IT")]
        public IResult Add(User user, int[] userOperationClaimIds)
        {

            _userDal.Insert(user);
            _operationClaimService.AddClaimsToUser(_userDal.GetById(u => u.Username == user.Username), userOperationClaimIds);
            return new SuccessResult();
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public User GetByMail(string username)
        {
            return _userDal.GetById(u => u.Username == username);
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [CacheRemoveAspect("IUserServise.Get")]
        [SecuredOperation("Admin,IT")]
        public IResult UpdateProfile(User user, IFormFile file)
        {

            _imageService.Add(file, user.Id);

            return new SuccessResult(Messages.Updated);

        }
    }
}
