using Core.DataAccess;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        public List<EmployeeDto> GetList(string key = null);
       
    }
}
