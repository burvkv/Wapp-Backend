using Core.DataAccess;
using Entity.Concrete;


namespace DataAccess.Abstract
{
    public interface IImageDal : IEntityRepository<Image>
    {
        Image Get(string path);
    }
}
