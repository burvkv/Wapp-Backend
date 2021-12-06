using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ToDoManager : IToDoService
    {
        IToDoDal _toDoListDal;
        public ToDoManager(IToDoDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }



        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [CacheRemoveAspect("IToDoService.Get")]
        [SecuredOperation("admin,IT")]
        public IResult Add(ToDo toDo)
        {
            toDo.Date = DateTime.Now.ToString("HH:mm / dd.MM.yyyy");
            toDo.Status = false; // 1 : New - 2 : Done  
            _toDoListDal.Insert(toDo);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [CacheRemoveAspect("IToDoService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(ToDo toDo)
        {
            _toDoListDal.Delete(toDo);
            return new SuccessResult();
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        [SecuredOperation("admin,IT,Guest")]
        public IDataResult<List<ToDoDto>> GetList(string key = null)
        {
            return new SuccessDataResult<List<ToDoDto>>(_toDoListDal.GetList());
        }


        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [CacheRemoveAspect("IToDoService.Get")]
        [SecuredOperation("admin,IT")]
        public IResult Update(ToDo toDo)
        {
            
            _toDoListDal.Update(toDo);
            return new SuccessResult();
        }
    }
}
