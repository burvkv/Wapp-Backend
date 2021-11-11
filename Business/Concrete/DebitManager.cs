using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Validation.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
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
        IHardwareService _hardwareService;
        public DebitManager(IDebitDal debitDal,IHardwareService hardwareService)
        {
            _debitDal = debitDal;
            _hardwareService = hardwareService;
        }

        [ValidationAspect(typeof(DebitValidator))]
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [CacheRemoveAspect("IDebitService.Get")]
        [SecuredOperation("admin,IT")]
        public IResult Add(DebitForAddDto debit)
        {
            IResult result = BusinessRules.Run(CheckIfHardwaresAlreadyDebitted(debit.HardwareIds));
            if (result!=null)
            {
                return new ErrorResult(result.Message);
            }
            debit.IsCurrent = true;
            debit.LastChange = DateTime.Now;
            int i = 0;
            foreach (var debitId in debit.HardwareIds)
            {
                
               Debit debitForAdd =  new Debit
                {
                    DebitFormPath = debit.DebitFormPath,
                    DebitId = debit.DebitId,
                    DebitStatusId = debit.DebitStatusId,
                    Explanation = debit.Explanation,
                    HardwareId = debit.HardwareIds[i],
                    IsCurrent = debit.IsCurrent,
                    LastChange = debit.LastChange,
                    OlderOwnerId = debit.OlderOwnerId,
                    OwnerId = debit.OwnerId,
                    PersonalId = debit.PersonalId,
                    ProjectId = debit.ProjectId
                };
                _debitDal.Insert(debitForAdd);
                i++;
            }
            // add form
            
            return new SuccessResult(Messages.Debitted);
        }


        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IDebitService.Get")]
        [SecuredOperation("admin,IT")]
        public IResult Delete(DebitForAddDto debit)
        {
            int i = 0;
            foreach (var debitId in debit.HardwareIds)
            {

                Debit debitForAdd = new Debit
                {
                    DebitFormPath = debit.DebitFormPath,
                    DebitId = debit.DebitId,
                    DebitStatusId = debit.DebitStatusId,
                    Explanation = debit.Explanation,
                    HardwareId = debit.HardwareIds[i],
                    IsCurrent = debit.IsCurrent,
                    LastChange = debit.LastChange,
                    OlderOwnerId = debit.OlderOwnerId,
                    OwnerId = debit.OwnerId,
                    PersonalId = debit.PersonalId,
                    ProjectId = debit.ProjectId
                };
                _debitDal.Delete(debitForAdd);
                i++;
            }
        
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
        [ValidationAspect(typeof(DebitValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IDebitService.Get")]
        [SecuredOperation("admin,IT")]
        public IResult Update(DebitForAddDto debit)
        {
            debit.IsCurrent = true;
            debit.LastChange = DateTime.Now;

            int i = 0;
            foreach (var debitId in debit.HardwareIds)
            {

                Debit debitForAdd = new Debit
                {
                    DebitFormPath = debit.DebitFormPath,
                    DebitId = debit.DebitId,
                    DebitStatusId = debit.DebitStatusId,
                    Explanation = debit.Explanation,
                    HardwareId = debit.HardwareIds[i],
                    IsCurrent = debit.IsCurrent,
                    LastChange = debit.LastChange,
                    OlderOwnerId = debit.OlderOwnerId,
                    OwnerId = debit.OwnerId,
                    PersonalId = debit.PersonalId,
                    ProjectId = debit.ProjectId
                };
                _debitDal.Update(debitForAdd);
                i++;
            }
            
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfHardwaresAlreadyDebitted(int[] ids)
        {
            foreach (var id in ids)
            {
                bool result = _hardwareService.GetById(id).Data.IsDebitted;
                if (result)
                {
                    return new ErrorResult($"{_hardwareService.GetById(id).Data.Barcode} Barkod numaralı ürün zaten zimmetli.");
                }
            }
            return new SuccessResult();
        }
    }
}
