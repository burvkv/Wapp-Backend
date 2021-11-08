using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Model:IEntity
    {
        [Key]
        public int ModelId { get; set; }
        public string ModelName { get; set; }
    }
}
