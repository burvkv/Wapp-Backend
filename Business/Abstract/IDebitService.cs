﻿using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDebitService
    {
        
        IDataResult<List<DebitDto>> GetList(string key = null);

        IDataResult<Debit> GetById(int id);
        IResult Add(Debit debit);
        IResult Delete(Debit debit);
        IResult Update(Debit debit);
    }


}