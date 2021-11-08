using Core.Utilities.Results;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ILabelService
    {
        IDataResult<List<Label>> GetAll();
        IDataResult<Label> GetById(int id);
        IResult Add(Label label);
        IResult Delete(Label label);
        IResult Update(Label label);
    }


}
