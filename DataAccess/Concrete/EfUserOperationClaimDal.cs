using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
   public class EfUserOperationClaimDal:EfEntityRepositoryBase<UserOperationClaim, TwAppContext>, IUserOperationClaimDal
    {
    }
}
