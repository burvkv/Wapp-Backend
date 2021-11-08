using Core.Utilities.Results;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDebitStatusService
    {
        IDataResult<List<DebitStatus>> GetAll();
        IResult Add(DebitStatus debitStatus);
        IResult Delete(DebitStatus debitStatus);
    }


}
