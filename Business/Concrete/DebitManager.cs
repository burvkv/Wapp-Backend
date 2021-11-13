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
            
               Debit debitForAdd =  new Debit
                {
                    DebitFormPath = debit.DebitFormPath,
                    DebitId = debit.DebitId,
                    DebitStatusId = debit.DebitStatusId,
                    Explanation = debit.Explanation,
                    HardwareIds = string.Join("-",debit.HardwareIds).ToString(),
                    IsCurrent = debit.IsCurrent,
                    LastChange = debit.LastChange,
                    OlderOwnerId = debit.OlderOwnerId,
                    OwnerId = debit.OwnerId,
                    PersonalId = debit.PersonalId,
                    ProjectId = debit.ProjectId
                };
            
                _debitDal.Insert(debitForAdd);
            foreach (var id in debit.HardwareIds)
            {
                var hware = _hardwareService.GetById(id);
                _hardwareService.Update(new Hardware
                {
                    Id = id,
                    IsDebitted = true,
                    Barcode = hware.Data.Barcode,
                    Explanation = hware.Data.Explanation,
                    IsDefective = hware.Data.IsDefective,
                    LabelId = hware.Data.LabelId,
                    ModelId = hware.Data.ModelId,
                    Type = hware.Data.Type
                    
                });
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

                Debit debitForAdd = new Debit
                {
                    DebitFormPath = debit.DebitFormPath,
                    DebitId = debit.DebitId,
                    DebitStatusId = debit.DebitStatusId,
                    Explanation = debit.Explanation,
                    HardwareIds = string.Join("-", debit.HardwareIds).ToString(),
                    IsCurrent = debit.IsCurrent,
                    LastChange = debit.LastChange,
                    OlderOwnerId = debit.OlderOwnerId,
                    OwnerId = debit.OwnerId,
                    PersonalId = debit.PersonalId,
                    ProjectId = debit.ProjectId
                };
                _debitDal.Delete(debitForAdd);

        
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
        public IDataResult<DebitDetailDto> GetDebitDetails(int id)
        {
            return new SuccessDataResult<DebitDetailDto>(_debitDal.GetDebitDetails(id));
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        [SecuredOperation("admin,IT,Guest")]
        public IDataResult<List<DebitForGetDto>> GetList(string key = null)
        {
            if (key == null)
            {
                return  new SuccessDataResult<List<DebitForGetDto>>(_debitDal.GetList());
            }
            return new SuccessDataResult<List<DebitForGetDto>>(_debitDal.GetList(key));
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


                Debit debitForAdd = new Debit
                {
                    DebitFormPath = debit.DebitFormPath,
                    DebitId = debit.DebitId,
                    DebitStatusId = debit.DebitStatusId,
                    Explanation = debit.Explanation,
                    HardwareIds = string.Join("-", debit.HardwareIds).ToString(),
                    IsCurrent = debit.IsCurrent,
                    LastChange = debit.LastChange,
                    OlderOwnerId = debit.OlderOwnerId,
                    OwnerId = debit.OwnerId,
                    PersonalId = debit.PersonalId,
                    ProjectId = debit.ProjectId
                };
                _debitDal.Update(debitForAdd);

            
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfHardwaresAlreadyDebitted(int[] ids)
        {
            
            foreach (var id in ids)
            {
                bool result2 = _hardwareService.GetById(id).Data.IsDebitted;
                if (result2)
                {
                    return new ErrorResult($"{_hardwareService.GetById(id).Data.Barcode} Barkod numaralı ürün zaten zimmetli.");
                }
            }
            return new SuccessResult();
        }
    }
}
