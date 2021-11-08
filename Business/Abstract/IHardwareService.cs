using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IHardwareService
    {
        
        IDataResult<List<HardwareDto>> GetList(string key = null);       
        IDataResult<Hardware> GetById(int id);
        IResult Add(Hardware hardware);
        IResult Delete(Hardware hardware);
        IResult Update(Hardware hardware);
    }


}
