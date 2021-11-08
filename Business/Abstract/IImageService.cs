using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageService
    {
        IResult Add(Image image);
        IResult delete(Image image);
        IResult Update(Image image);
         IDataResult<Image> Get(string path);
    }
}
