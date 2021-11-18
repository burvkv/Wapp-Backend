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
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IEmployeeService.Get")]
        [ValidationAspect(typeof(EmployeeValidator))]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(Employee employee)
        {
            employee.EnterDate = DateTime.Now;
            employee.LeftDate = null;
            _employeeDal.Insert(employee);          
            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IEmployeeService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.Deleted);
        }


        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheAspect]
        public IDataResult<List<EmployeeDto>> GetList(string key = null)

        {
            if (key == null)
            {
                return new SuccessDataResult<List<EmployeeDto>>(_employeeDal.GetList());
            }
            return new SuccessDataResult<List<EmployeeDto>>(_employeeDal.GetList(key));
            
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IEmployeeService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.Updated);
        }
    }
}
