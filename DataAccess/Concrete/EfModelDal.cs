using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;


namespace DataAccess.Concrete
{
    public class EfModelDal : EfEntityRepositoryBase<Model, TwAppContext>, IModelDal
    {

    }

}
