using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        IFileHelper _fileHelper;
        public ImageManager(IImageDal imageDal, IFileHelper fileHelper)
        {
            _imageDal = imageDal;
            _fileHelper = fileHelper;
        }
        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheRemoveAspect("IImageService.Get")]
        public IResult Add(IFormFile file, int userId)
        {
            var imageResult = _fileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(Messages.ImageFailed);
            }

            Image image = new Image
            {
                ImagePath = imageResult.Message,
                UserId = userId
            };
            var result = _imageDal.GetById(p => p.UserId == userId);
            if (result!=null)
            {
               _imageDal.Delete(new Image
                {
                   Id = result.Id,
                    UserId = userId,
                    ImagePath = result.ImagePath
                });
                _fileHelper.Remove(result.ImagePath);
            }

            _imageDal.Insert(image);

            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheRemoveAspect("IImageService.Get")]
        public IResult delete(Image image)
        {
            _imageDal.Delete(image);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheRemoveAspect("IImageService.Get")]
        public IResult Update(Image image)
        {
            _imageDal.Update(image);
            return new SuccessResult();
        }


        [PerformanceAspect(5)]
        [SecuredOperation("Admin,IT,Guest")]
        [CacheAspect)]
        public IDataResult<Image> Get(int userId)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(userId));
        }
    }
}
