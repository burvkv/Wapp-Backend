using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Label label)
        {
            _labelDal.Insert(label);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Label label)
        {
            _labelDal.Delete(label);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Label>> GetAll()
        {
            return new SuccessDataResult<List<Label>>(_labelDal.GetAll());
        }

        public IDataResult<Label> GetById(int id)
        {
            return new SuccessDataResult<Label>(_labelDal.GetById(l=>l.LabelId == id));
        }

        public IResult Update(Label label)
        {
            _labelDal.Update(label);
            return new SuccessResult(Messages.Updated);
        }
    }
}
