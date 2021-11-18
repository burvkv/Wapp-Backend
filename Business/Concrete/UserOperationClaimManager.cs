using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers.FileLogger;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _operationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        
       
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [LogAspect(typeof(FileLogger))]
        public IResult AddClaimsToUser(User user, int[] operationClaimIds)
        {
            
            foreach (var claimId in operationClaimIds)
            {
                _operationClaimDal.Insert(new UserOperationClaim
                {
                    OperationClaimId = claimId,
                    UserId = user.Id
                });
            }

            return new SuccessResult();
           
        }
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [LogAspect(typeof(FileLogger))]
        public IResult DeleteClaimsToUser(User user, int[] operationClaimIds)
        {

            foreach (var claimId in operationClaimIds)
            {
                _operationClaimDal.Delete(new UserOperationClaim
                {
                    OperationClaimId = claimId,
                    UserId = user.Id
                });
            }

            return new SuccessResult();
        }
    }
}
