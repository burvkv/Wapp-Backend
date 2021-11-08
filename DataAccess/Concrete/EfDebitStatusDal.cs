﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;


namespace DataAccess.Concrete
{
    public class EfDebitStatusDal : EfEntityRepositoryBase<DebitStatus, TwAppContext>, IDebitStatusDal
    {
    }
}
