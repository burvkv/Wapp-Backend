using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;



using Entity.Concrete.Dto;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfHardwareDal : EfEntityRepositoryBase<Hardware, TwAppContext>, IHardwareDal
    {
        public List<HardwareDto> GetList(string key = null)
        {
            using (TwAppContext context = new TwAppContext())
            {
                var data = from hware in context.Hardwares
                           join model in context.Models on hware.ModelId equals model.ModelId
                           join lbl in context.Labels on hware.LabelId equals lbl.LabelId
                           select new HardwareDto
                           {
                               Id = hware.Id,
                               Label = lbl.LabelName,
                               Barcode = hware.Barcode,
                               Explanation = hware.Explanation,
                               IsDefective = hware.IsDefective,
                               ModelName = model.ModelName,
                               Type = hware.Type,
                               IsDebitted = hware.IsDebitted
                           };

                if (key == null)
                {
                    return data.ToList();
                }
                return data.Where(d => d.Barcode.Contains(key)).ToList();
            }
        }
    }

}
