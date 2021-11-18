using Core.Utilities.Results;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.MailHelper
{
   public interface IDailyReportHelper
    {
        public IResult CreateDailyReport(DeletedHardwareLogModelDto hardware);
    }
}
