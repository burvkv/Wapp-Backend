using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
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
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(Image image)
        {
            _imageDal.Insert(image);
            return new SuccessResult();
        }

        public IResult delete(Image image)
        {
            _imageDal.Delete(image);
            return new SuccessResult();
        }

        public IResult Update(Image image)
        {
            _imageDal.Update(image);
            return new SuccessResult();
        }

        public IDataResult<Image> Get(string path)
        {
           return new SuccessDataResult<Image> (_imageDal.Get(path));
        }
    }
}
