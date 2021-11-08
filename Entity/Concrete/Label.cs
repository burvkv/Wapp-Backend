using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity.Concrete
{
    public class Label:IEntity
    {
        public int LabelId { get; set; }
        public string LabelName { get; set; }
    }
}
