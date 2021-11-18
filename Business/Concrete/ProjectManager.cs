using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers.FileLogger;
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

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IProjectService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(Project project)
        {
            _projectDal.Insert(project);
            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IProjectService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Project project)
        {
            _projectDal.Delete(project);
            return new SuccessResult(Messages.Deleted);
        }

 
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheAspect]
        public IDataResult<Project> GetById(int id)
        {
            return new SuccessDataResult<Project>(_projectDal.GetById(p => p.ProjectId == id));
        }


        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheAspect]
        public IDataResult<List<ProjectDto>> GetList(string key = null)
        {
            if (key == null)
            {
                return new SuccessDataResult<List<ProjectDto>>(_projectDal.GetList());
            }
            return new SuccessDataResult<List<ProjectDto>>(_projectDal.GetList(key));
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT")]
        [CacheRemoveAspect("IProjectService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Update(Project project)
        {
            _projectDal.Update(project);
            return new SuccessResult(Messages.Updated);
        }
    }
}
