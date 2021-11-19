using System;

namespace Core.Utilities.Helpers.MailHelper
{
    public class Dailyreport
    {
        private string _title = "Donanım Silme İşlemi";
        public string UserName { get; set; }
        public string Barcode { get; set; }
        public string HardwareType { get; set; }
        public string Date { get; set; }
        public string Title { get { return _title; } }
        public string Body { get; set; }
    }
}
