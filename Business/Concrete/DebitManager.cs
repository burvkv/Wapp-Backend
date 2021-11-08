using Business.Abstract;
using Business.Constants;
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
        public DebitManager(IDebitDal debitDal)
        {
            _debitDal = debitDal;
        }
        public IResult Add(Debit debit)
        {
            _debitDal.Insert(debit);
            return new SuccessResult(Messages.Debitted);
        }

        public IResult Delete(Debit debit)
        {
            _debitDal.Delete(debit);
            return new SuccessResult(Messages.Deleted);
        }

       

        public IDataResult<Debit> GetById(int id)
        {
            return new SuccessDataResult<Debit>(_debitDal.GetById(p=>p.DebitId.Equals(id)));
        }

        public IDataResult<List<DebitDto>> GetList(string key = null)
        {
            if (key == null)
            {
                return new SuccessDataResult<List<DebitDto>>(_debitDal.GetList());
            }
            return new SuccessDataResult<List<DebitDto>>(_debitDal.GetList(key));
        }

        public IResult Update(Debit debit)
        {
            _debitDal.Update(debit);
            return new SuccessResult(Messages.Updated);
        }
    }
}
