﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Concrete
{
    public class EfDebitDal : EfEntityRepositoryBase<Debit, TwAppContext>, IDebitDal
    {
        public List<DebitDto> GetList(string key = null)
        {
            using (TwAppContext context = new TwAppContext())
            {
                var data = from debit in context.Debits
                           join dStatus in context.DebitStatuses on debit.DebitStatusId equals dStatus.Id
                           join oOwner in context.Employees on debit.OlderOwnerId equals oOwner.EmployeeId
                           join owner in context.Employees on debit.OwnerId equals owner.EmployeeId
                           join hardware in context.Hardwares on debit.HardwareId equals hardware.Id
                           join project in context.Projects on debit.ProjectId equals project.ProjectId

                           join model in context.Models on hardware.ModelId equals model.ModelId
                           join label in context.Labels on hardware.LabelId equals label.LabelId

                           select new DebitDto
                           {
                               DebitId = debit.DebitId,
                               DebitStatus = dStatus.Status,
                               Explanation = debit.Explanation,
                               OlderOwnerName = $"{oOwner.FirstName} {oOwner.LastName}",
                               OwnerName = $"{owner.FirstName} {owner.LastName}",
                               HardwareBarcode = hardware.Barcode,
                               HardwareLabel = label.LabelName,
                               HardwareModel = model.ModelName,
                               HardwareType = hardware.Type,
                               IsActive = debit.IsActive,

                               ProjectName = project.ProjectName



                           };
                if (key == null)
                {
                    return data.ToList();
                }
                else
                {
                    return data.Where(p => p.HardwareBarcode.Contains(key)).ToList();
                }


            }
        }




    }
}