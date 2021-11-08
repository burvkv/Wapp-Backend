using Business.Abstract;
using Business.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IFileHelper _fileHelper;
        IImageService _imageService;
        public UserManager(IUserDal userDal,IFileHelper fileHelper, IImageService imageService)
        {
            _userDal = userDal;
            _fileHelper = fileHelper;
            _imageService = imageService;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Insert(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.GetById(u => u.Email == email);
        }

        public IResult UpdateProfile(User user,IFormFile formFile)
        {
            var imageResult = _fileHelper.Upload(formFile);
            if (!imageResult.Success)
            {
                return new ErrorResult(Messages.ImageFailed);
            }


            _imageService.Add(new Entity.Concrete.Image
            {
                ImagePath = imageResult.Message
            });


            user.ImageId = _imageService.Get(imageResult.Message).Data.Id;
           _userDal.Update(user);
            return new SuccessResult(Messages.Updated);

        }
    }
}
