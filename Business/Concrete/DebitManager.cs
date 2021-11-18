using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Validation.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers.FileLogger;
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
        public DebitManager(IDebitDal debitDal, IHardwareService hardwareService)
        {
            _debitDal = debitDal;
            _hardwareService = hardwareService;
        }

        [ValidationAspect(typeof(DebitValidator))]
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [CacheRemoveAspect("IDebitService.Get")]
        [SecuredOperation("admin,IT")]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(DebitForAddDto debit)
        {
            IResult result = BusinessRules.Run(CheckIfHardwaresAlreadyDebitted(debit.HardwareIds));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            _debitDal.Insert(SetDebitForCrud(debit));
            HardwareUpdate(debit.HardwareIds,true);
            // add form
            return new SuccessResult(Messages.Debitted);
        }

        private void HardwareUpdate(int[] ids,bool isDebitted)
        {
            foreach (var id in ids)
            {
                var hware = _hardwareService.GetById(id);
                _hardwareService.Update(new Hardware
                {
                    Id = id,
                    IsDebitted = isDebitted,
                    Barcode = hware.Data.Barcode,
                    Explanation = hware.Data.Explanation,
                    IsDefective = hware.Data.IsDefective,
                    LabelId = hware.Data.LabelId,
                    ModelId = hware.Data.ModelId,
                    Type = hware.Data.Type

                });
            }
        }
        private Debit SetDebitForCrud(DebitForAddDto debit)
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

            return debitForAdd;
        }


        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IDebitService.Get")]
        [SecuredOperation("admin,IT")]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(DebitForAddDto debit)
        {
            Debit debitForDelete = _debitDal.GetById(d => d.DebitId == debit.DebitId);
            _debitDal.Delete(debitForDelete);           
            HardwareUpdate(debit.HardwareIds, false);
            return new SuccessResult(Messages.Deleted);
        }



        [PerformanceAspect(5)]
        [CacheAspect]
        [SecuredOperation("admin,IT,Guest")]
        public IDataResult<Debit> GetById(int id)
        {
            return new SuccessDataResult<Debit>(_debitDal.GetById(p => p.DebitId.Equals(id)));
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
                return new SuccessDataResult<List<DebitForGetDto>>(_debitDal.GetList());
            }
            return new SuccessDataResult<List<DebitForGetDto>>(_debitDal.GetList(key));
        }


        [PerformanceAspect(5)]
        [ValidationAspect(typeof(DebitValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IDebitService.Get")]
        [SecuredOperation("admin,IT")]
        [LogAspect(typeof(FileLogger))]
        public IResult Update(DebitForAddDto debit)
        {
            IResult result = BusinessRules.Run(CheckIfHardwaresAlreadyDebitted(debit.HardwareIds));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

           
            _debitDal.Update(SetDebitForCrud(debit));
            HardwareUpdate(debit.HardwareIds,true);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfHardwaresAlreadyDebitted(int[] ids)
        {

            foreach (var id in ids)
            {
                bool isAlreadyDebitted = _hardwareService.GetById(id).Data.IsDebitted;
                if (isAlreadyDebitted)
                {
                    return new ErrorResult($"{_hardwareService.GetById(id).Data.Barcode} Barkod numaralı ürün zaten zimmetli.");
                }
            }
            return new SuccessResult();
        }
    }
}
