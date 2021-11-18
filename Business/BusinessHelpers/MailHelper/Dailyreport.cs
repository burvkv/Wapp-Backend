using System;

namespace Core.Utilities.Helpers.MailHelper
{
    public class Dailyreport
    {
        private string _value;
        private string _title = "Donanım Silme İşlemi";
        private string _date;
        public string UserName { get; set; }
        public string Barcode { get; set; }
        public string Date { get; set; }
        public string Title { get { return _title; } }
        public string Body { get; set; }
    }
}
