using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public IResult Add(Employee employee)
        {
            _employeeDal.Insert(employee);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<EmployeeDto>> GetList(string key = null)

        {
            if (key == null)
            {
                return new SuccessDataResult<List<EmployeeDto>>(_employeeDal.GetList());
            }
            return new SuccessDataResult<List<EmployeeDto>>(_employeeDal.GetList(key));
            
        }

        

        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.Updated);
        }
    }
}
