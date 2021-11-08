using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProjectService
    {
        IDataResult<List<ProjectDto>> GetList(string key = null);
        IDataResult<Project> GetById(int id);
        IResult Add(Project project);
        IResult Delete(Project project);
        IResult Update(Project project);
    }


}
