using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Project:IEntity
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
  
        public int LeaderId { get; set; }

    }
}
