using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.Dto
{
    public class ProjectDto : IDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string LeaderName { get; set; }

    }
}
