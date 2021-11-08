using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<EmployeeDto>> GetList(string key = null);

        IResult Add(Employee employee);
        IResult Delete(Employee employee);
        IResult Update(Employee employee);
    }


}
