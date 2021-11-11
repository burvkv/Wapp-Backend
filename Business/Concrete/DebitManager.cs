using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DebitManager : IDebitService
    {
        IDebitDal _debitDal;
        public DebitManager(IDebitDal debitDal)
        {
            _debitDal = debitDal;
        }

        //[ValidationAspect(typeof(OurServiceImageValidator))]
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [CacheRemoveAspect("IDebitService.Get")]
        [SecuredOperation("admin,IT")]
        public IResult Add(Debit debit)
        {
            debit.IsCurrent = true;
            debit.LastChange = DateTime.Now;
            // add form
            _debitDal.Insert(debit);
            return new SuccessResult(Messages.Debitted);
        }


        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IDebitService.Get")]
        [SecuredOperation("admin,IT")]
        public IResult Delete(Debit debit)
        {
            _debitDal.Delete(debit);
            return new SuccessResult(Messages.Deleted);
        }



        [PerformanceAspect(5)]
        [CacheAspect]
        [SecuredOperation("admin,IT,Guest")]
        public IDataResult<Debit> GetById(int id)
        {
            return new SuccessDataResult<Debit>(_debitDal.GetById(p=>p.DebitId.Equals(id)));
        }



        [PerformanceAspect(5)]
        [CacheAspect]
        [SecuredOperation("admin,IT,Guest")]
        public IDataResult<List<DebitDto>> GetList(string key = null)
        {
            if (key == null)
            {
                return new SuccessDataResult<List<DebitDto>>(_debitDal.GetList());
            }
            return new SuccessDataResult<List<DebitDto>>(_debitDal.GetList(key));
        }


        [PerformanceAspect(5)]
        //[ValidationAspect(typeof(OurServiceImageValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IDebitService.Get")]
        [SecuredOperation("admin,IT")]
        public IResult Update(Debit debit)
        {
            debit.IsCurrent = true;
            debit.LastChange = DateTime.Now;
            _debitDal.Update(debit);
            return new SuccessResult(Messages.Updated);
        }
    }
}
