using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.Dto
{
    public class EmployeeDto : Employee , IDto
    {
        public string ProjectName { get; set; }
        public string LeaderName { get; set; }

    }
}
