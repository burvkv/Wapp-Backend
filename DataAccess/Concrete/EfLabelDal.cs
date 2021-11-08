using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;


namespace DataAccess.Concrete
{
    public class EfLabelDal : EfEntityRepositoryBase<Label, TwAppContext>, ILabelDal
    {

    }
}
