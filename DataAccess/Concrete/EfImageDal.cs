using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfImageDal : EfEntityRepositoryBase<Image, TwAppContext>, IImageDal
    {
        public Image Get(int userId)
        {
            using (TwAppContext context = new TwAppContext())
            {
                return context.Set<Image>().Where(p => p.UserId == userId).FirstOrDefault();
            }
        }
    }
}
