using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectDal;
        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;

        }

        public IResult Add(Project project)
        {
            _projectDal.Insert(project);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Project project)
        {
            _projectDal.Delete(project);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Project> GetById(int id)
        {
            return new SuccessDataResult<Project>(_projectDal.GetById(p => p.ProjectId == id));
        }

        public IDataResult<List<ProjectDto>> GetList(string key = null)
        {
            if (key == null)
            {
                return new SuccessDataResult<List<ProjectDto>>(_projectDal.GetList());
            }
            return new SuccessDataResult<List<ProjectDto>>(_projectDal.GetList(key));
        }

        public IResult Update(Project project)
        {
            _projectDal.Update(project);
            return new SuccessResult(Messages.Updated);
        }
    }
}
