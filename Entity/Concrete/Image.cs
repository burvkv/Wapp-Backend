using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Image:IEntity
    {
        public string ImagePath { get; set; }
        public int UserId { get; set; }
        public int Id { get; set; }

    }
}
