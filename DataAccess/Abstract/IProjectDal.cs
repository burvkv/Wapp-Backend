using Core.DataAccess;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IProjectDal : IEntityRepository<Project>
    {
        List<ProjectDto> GetList(string key = null);
        
    }
}
