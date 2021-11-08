using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HardwareManager : IHardwareService
    {
        IHardwareDal _hardwareDal;
        public HardwareManager(IHardwareDal hardwareDal)
        {
            _hardwareDal = hardwareDal;
        }
        public IResult Add(Hardware hardware)
        {
            _hardwareDal.Insert(hardware);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Hardware hardware)
        {
            _hardwareDal.Delete(hardware);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Hardware> GetById(int id)
        {
            return new SuccessDataResult<Hardware>(_hardwareDal.GetById(p=>p.Id == id));
        }

        public IDataResult<List<HardwareDto>> GetList(string key = null)
        {
            if (key == null)
            {
                return new SuccessDataResult<List<HardwareDto>>(_hardwareDal.GetList());
            }
            else
            {
                return new SuccessDataResult<List<HardwareDto>>(_hardwareDal.GetList(key));
            }
        }

        public IResult Update(Hardware hardware)
        {
            _hardwareDal.Update(hardware);
            return new SuccessResult(Messages.Updated);
        }
    }
}
