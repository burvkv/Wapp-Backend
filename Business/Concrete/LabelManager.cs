using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class LabelManager : ILabelService
    {
        ILabelDal _labelDal;
        public LabelManager(ILabelDal labelDal)
        {
            _labelDal = labelDal;
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("ILabelService.Get")]
        public IResult Add(Label label)
        {
            _labelDal.Insert(label);
            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("ILabelService.Get")]
        public IResult Delete(Label label)
        {
            _labelDal.Delete(label);
            return new SuccessResult(Messages.Deleted);
        }


        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheAspect]
        public IDataResult<List<Label>> GetAll()
        {
            return new SuccessDataResult<List<Label>>(_labelDal.GetAll());
        }


        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheAspect]
        public IDataResult<Label> GetById(int id)
        {
            return new SuccessDataResult<Label>(_labelDal.GetById(l=>l.LabelId == id));
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("ILabelService.Get")]
        public IResult Update(Label label)
        {
            _labelDal.Update(label);
            return new SuccessResult(Messages.Updated);
        }
    }
}
