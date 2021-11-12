using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfProjectDal : EfEntityRepositoryBase<Project, TwAppContext>, IProjectDal
    {
        public List<ProjectDto> GetList(string key = null)
        {
            using (TwAppContext context = new TwAppContext())
            {
                var data = from proj in context.Projects
                           join empl in context.Employees on proj.LeaderId equals empl.EmployeeId
                           select new ProjectDto
                           {
                               LeaderName = $"{empl.FirstName} {empl.LastName}",
                               ProjectId = proj.ProjectId,
                              
                               ProjectName = proj.ProjectName
                           };

               

                if (key != null)
                {
                    return data.Where(p => p.ProjectName.Contains(key)).ToList();
                }
                return data.ToList();
            }
        }
    }

}
