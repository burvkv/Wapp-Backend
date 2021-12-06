using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class ToDo : IEntity
    {
        public int TodoId { get; set; }
        public int EmployeeId { get; set; }
        public string Explanation { get; set; }
        public string Date { get; set; }
        public string ProcessName { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
#nullable enable
        public string? Note { get; set; }
#nullable disable
    }
}
