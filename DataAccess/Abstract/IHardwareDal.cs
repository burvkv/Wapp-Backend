using System.Collections.Generic;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Concrete.Dto;

namespace DataAccess.Abstract
{
    public interface IHardwareDal : IEntityRepository<Hardware>
    {
        List<HardwareDto> GetList(string key = null);

    }
}
