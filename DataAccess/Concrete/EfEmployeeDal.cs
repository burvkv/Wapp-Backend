using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, TwAppContext>, IEmployeeDal
    {
        public List<EmployeeDto> GetList(string key = null)
        {
            using (TwAppContext context = new TwAppContext())
            {
                var data = from emplo in context.Employees
                           join projct in context.Projects on emplo.ProjectId equals projct.ProjectId
                           join lead in context.Employees on emplo.EmployeeId equals lead.EmployeeId
                           select new EmployeeDto 
                           {
                               EmployeeId = emplo.EmployeeId,
                               ProjectId = emplo.ProjectId,
                               Address = emplo.Address,
                               Email = emplo.Email,
                               EmployeeStatus = emplo.EmployeeStatus,
                               EnterDate = emplo.EnterDate,
                               FirstName = emplo.FirstName,
                               LastName = emplo.LastName,
                               LeftDate = emplo.LeftDate,
                               PhoneNumber = emplo.PhoneNumber,
                               ProjectName = projct.ProjectName,
                               LeaderName = $"{lead.FirstName} {lead.LastName}"
                           };

                if (key == null)
                {
                    return data.ToList();
                }
                return data.Where(f => f.FirstName.Contains(key)).ToList();

            }
        }
    }

}
