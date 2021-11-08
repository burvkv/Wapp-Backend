using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DebitStatusManager : IDebitStatusService
    {
        IDebitStatusDal _debitStatusDal;
        public DebitStatusManager(IDebitStatusDal debitStatusDal)
        {
            _debitStatusDal = debitStatusDal;
        }
        public IResult Add(DebitStatus debitStatus)
        {
            _debitStatusDal.Insert(debitStatus);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(DebitStatus debitStatus)
        {
            _debitStatusDal.Delete(debitStatus);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<DebitStatus>> GetAll()
        {
            return new SuccessDataResult<List<DebitStatus>>(_debitStatusDal.GetAll());
        }
    }
}
