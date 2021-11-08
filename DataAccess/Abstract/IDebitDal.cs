using Core.DataAccess;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Abstract
{
    public interface IDebitDal:IEntityRepository<Debit>
{
        List<DebitDto> GetList(string key = null);
       
}
}
