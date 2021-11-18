using Core.Utilities.Helpers.MailHelper;
using Core.Utilities.Results;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessHelpers.MailHelper
{
    public class DailyReportHelper : IDailyReportHelper
    {
        public IResult CreateDailyReport(DeletedHardwareLogModelDto hardware)
        {
            Dailyreport dailyReport = new Dailyreport
            {
                Barcode = hardware.Barcode,
                Date = DateTime.Now.ToString("HH.mm.ss dd/MM/yyyy"),
                Body = $"{hardware.Barcode} Barkodlu donanım {DateTime.Now.ToString("HH.mm.ss dd/MM/yyyy")} tarihinde {hardware.UserName} tarafından silindi.",
                UserName = hardware.UserName,

            };
            SendMail.SendDailyReport(dailyReport.Body);
            return new SuccessResult();
           
        }
        
    }
}
