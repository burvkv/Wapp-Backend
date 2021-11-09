using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DebitStatusManager : IDebitStatusService
    {
        IDebitStatusDal _debitStatusDal;
        public DebitStatusManager(IDebitStatusDal debitStatusDal)
        {
            _debitStatusDal = debitStatusDal;
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IDebitStatusService.Get")]
        public IResult Add(DebitStatus debitStatus)
        {
            _debitStatusDal.Insert(debitStatus);
            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IDebitStatusService.Get")]
        public IResult Delete(DebitStatus debitStatus)
        {
            _debitStatusDal.Delete(debitStatus);
            return new SuccessResult(Messages.Deleted);
        }

     
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheAspect]
        public IDataResult<List<DebitStatus>> GetAll()
        {
            return new SuccessDataResult<List<DebitStatus>>(_debitStatusDal.GetAll());
        }
    }
}
