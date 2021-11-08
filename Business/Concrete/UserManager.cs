using Business.Abstract;
using Business.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IFileHelper _fileHelper;
        IImageService _imageService;
        ITokenHelper _tokenHelper;
        public UserManager(IUserDal userDal,IFileHelper fileHelper, IImageService imageService, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _fileHelper = fileHelper;
            _imageService = imageService;
            _tokenHelper = tokenHelper;
        
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Insert(user);
        }

        public User GetByMail(string username)
        {
            return _userDal.GetById(u => u.Username == username);
        }

        public IResult UpdateProfile(User user,IFormFile file)
        {

            
           
           
            _imageService.Add(file,user.Id);
            
            return new SuccessResult(Messages.Updated);

        }
    }
}
