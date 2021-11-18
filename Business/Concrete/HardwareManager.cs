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
using Core.Utilities.Helpers.MailHelper;
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
    public class HardwareManager : IHardwareService
    {
        IHardwareDal _hardwareDal;
        IDailyReportHelper _dailyReportHelper;
        public HardwareManager(IHardwareDal hardwareDal, IDailyReportHelper dailyReportHelper)
        {
            _dailyReportHelper = dailyReportHelper;
            _hardwareDal = hardwareDal;
        }
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IHardwareService.Get")]
        [ValidationAspect(typeof(HardwareValidator))]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(Hardware hardware)
        {

            _hardwareDal.Insert(hardware);
            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IHardwareService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(DeletedHardwareLogModelDto hardware)
        {
           _hardwareDal.Delete(new Hardware {
                Barcode = hardware.Barcode,
                Explanation = hardware.Explanation,
                Id = hardware.Id,
                IsDebitted = hardware.IsDebitted,
                IsDefective = hardware.IsDefective,
                LabelId = hardware.LabelId,
                ModelId = hardware.ModelId,
                Type = hardware.Type
            });
            _dailyReportHelper.CreateDailyReport(hardware);
            return new SuccessResult(Messages.Deleted);
        }


        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheAspect]
        public IDataResult<Hardware> GetById(int id)
        {
            var result =  new SuccessDataResult<Hardware>(_hardwareDal.GetById(p=>p.Id == id));
            return result;
        }


        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheAspect]
        public IDataResult<List<HardwareDto>> GetList(string key = null)
        {
            if (key == null)
            {
                return new SuccessDataResult<List<HardwareDto>>(_hardwareDal.GetList());
            }
            else
            {
                return new SuccessDataResult<List<HardwareDto>>(_hardwareDal.GetList(key));
            }
        }

 
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IHardwareService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Update(Hardware hardware)
        {
            _hardwareDal.Update(hardware);
            return new SuccessResult(Messages.Updated);
        }
    }
}
