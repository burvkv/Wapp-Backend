using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers.FileLogger;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IModelService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(Model model)
        {
            _modelDal.Insert(model);
            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IModelService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult(Messages.Deleted);
        }


        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheAspect]
        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }


        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheAspect]
        public IDataResult<Model> GetById(int id)
        {
            return new SuccessDataResult<Model>(_modelDal.GetById(m => m.ModelId == id));
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IModelService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult(Messages.Updated);
        }
    }
}
