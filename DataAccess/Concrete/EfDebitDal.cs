using Core.DataAccess.EntityFramework;
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
        IHardwareDal _hardwareDal;
        ILabelDal _labelDal;
        IModelDal _modelDal;
        public EfDebitDal(IHardwareDal hardwareDal,ILabelDal labelDal, IModelDal modelDal)
        {
            _hardwareDal = hardwareDal;
            _labelDal = labelDal;
            _modelDal = modelDal;
        }
        public DebitDetailDto GetDebitDetails(int id)
        {
            
            using (TwAppContext context = new TwAppContext())
            {
                var data = from debit in context.Debits
                           join owner in context.Employees on debit.OwnerId equals owner.EmployeeId
                           join dStat in context.DebitStatuses on debit.DebitStatusId equals dStat.Id
                           join oOwner in context.Employees on debit.OlderOwnerId equals oOwner.EmployeeId
                           join project in context.Projects on debit.ProjectId equals project.ProjectId
                           join usr in context.Users on debit.PersonalId equals usr.Id
                           where debit.DebitId == id
                           select new
                           {
                               OwnerName = $"{owner.FirstName} {owner.LastName}",
                               DebitId = debit.DebitId,
                               DebitStatus = dStat.Status,
                               ProjectName = project.ProjectName,
                               OlderOwner = $"{oOwner.FirstName} {oOwner.LastName}",
                               Explanation = debit.Explanation,
                               IsCurrent = debit.IsCurrent,
                               LastChange = debit.LastChange,
                               PersonalName = $"{usr.FirstName} {usr.LastName}",
                               hwareids = debit.HardwareIds
                           };

                DebitDetailDto dtoForGet = new DebitDetailDto();
                
                int i = 0;
                foreach (var ids in data)
                {
                    
                    dtoForGet.HardwareBarcode = new string[ids.hwareids.Split('-').Count()];
                    dtoForGet.HardwareLabel = new string[ids.hwareids.Split('-').Count()];
                    dtoForGet.HardwareModel = new string[ids.hwareids.Split('-').Count()];
                    dtoForGet.HardwareType = new string[ids.hwareids.Split('-').Count()];
                    dtoForGet.DebitId = ids.DebitId;
                    dtoForGet.DebitStatus = ids.DebitStatus;
                    dtoForGet.Explanation = ids.Explanation;
                    dtoForGet.IsCurrent = ids.IsCurrent;
                    dtoForGet.LastChange = ids.LastChange;
                    dtoForGet.OlderOwnerName = ids.OlderOwner;
                    dtoForGet.OwnerName = ids.OwnerName;
                    dtoForGet.PersonalName = ids.PersonalName;
                    dtoForGet.ProjectName = ids.ProjectName;
                    foreach (var idss in ids.hwareids.Split('-'))
                    {
                        Hardware hardware = _hardwareDal.GetById(h => h.Id == Convert.ToInt32(idss));
                        Label label = _labelDal.GetById(p => p.LabelId == Convert.ToInt32(hardware.LabelId));
                        Model model = _modelDal.GetById(m => m.ModelId == Convert.ToInt32(hardware.ModelId));
                        dtoForGet.HardwareBarcode[i] = hardware.Barcode;
                        dtoForGet.HardwareLabel[i] = label.LabelName;
                        dtoForGet.HardwareModel[i] = model.ModelName;
                        dtoForGet.HardwareType[i] = hardware.Type;
                        i++;
                    }
                   
                }
                return dtoForGet;
            }
        }

        public List<DebitForGetDto> GetList(string key = null)
        {
            using (TwAppContext context = new TwAppContext())
            {
                 
                var data = from debit in context.Debits
                           join empl in context.Employees on debit.OwnerId equals empl.EmployeeId
                           join project in context.Projects on debit.ProjectId equals project.ProjectId
                           select new DebitForGetDto
                           {
                               DebitId = debit.DebitId,
                               Explanation = debit.Explanation,
                               IsCurrent = debit.IsCurrent,
                               LastChange = debit.LastChange,
                               OwnerName = $"{empl.FirstName} {empl.LastName}",
                               ProjectName = project.ProjectName
                           };

                if (key == null)
                {
                    return data.ToList();
                }
                else
                {
                    return data.Where(p => p.OwnerName.Contains(key)).ToList();
                }
            }
        }
    }
}
//var data = from debit in context.Debits
//           join dStatus in context.DebitStatuses on debit.DebitStatusId equals dStatus.Id
//           join oldO in context.Employees on debit.OlderOwnerId equals oldO.EmployeeId
//           join owner in context.Employees on debit.OwnerId equals owner.EmployeeId
//           join hardware in context.Hardwares on debit.HardwareId equals hardware.Id
//           join label in context.Labels on hardware.LabelId equals label.LabelId
//           join model in context.Models on hardware.ModelId equals model.ModelId
//           join user in context.Users on debit.PersonalId equals user.Id
//           join project in context.Projects on debit.ProjectId equals project.ProjectId

//           select new DebitDto
//           {
//               DebitId = debit.DebitId,
//               DebitStatus = dStatus.Status,
//               Explanation = debit.Explanation,
//               OlderOwnerName = $"{oldO.FirstName} {oldO.LastName}",
//               OwnerName = $"{owner.FirstName} {owner.LastName}",                              
//               HardwareBarcode = hardware.Barcode,
//               HardwareLabel = label.LabelName,
//               HardwareModel = model.ModelName,
//               HardwareType = hardware.Type,
//               IsCurrent = debit.IsCurrent,
//               LastChange = debit.LastChange,
//               PersonalName = $"{user.FirstName} {user.LastName}",
//               ProjectName = project.ProjectName                                                             
//           };
//      