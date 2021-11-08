using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Model model)
        {
            _modelDal.Insert(model);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }

        public IDataResult<Model> GetById(int id)
        {
            return new SuccessDataResult<Model>(_modelDal.GetById(m => m.ModelId == id));
        }

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult(Messages.Updated);
        }
    }
}
