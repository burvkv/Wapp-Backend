using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfToDoDal : EfEntityRepositoryBase<ToDo, TwAppContext>, IToDoDal
    {
        public List<ToDoDto> GetList(string key = null)
        {
            using (TwAppContext context = new TwAppContext())
            {
                var result = from todo in context.ToDos
                             join empl in context.Employees on todo.EmployeeId equals empl.EmployeeId
                             join usr in context.Users on todo.UserId equals usr.Id
                             select new ToDoDto
                             {
                                 Date = todo.Date,
                                 EmployeeName = $"{empl.FirstName} {empl.LastName}",
                                 Explanation = todo.Explanation,
                                 Note = todo.Note,
                                 ProcessName = todo.ProcessName,
                                 Status = todo.Status,
                                 TodoId = todo.TodoId,
                                 UserName = $"{usr.FirstName} {usr.LastName}"
                             };

                
              var data =  key == null ? result.ToList(): result.Where(p => p.EmployeeName.Contains(key) || p.UserName.Contains(key) || p.ProcessName.Contains(key)).ToList();
                return data;
            }


        }
    }
}
