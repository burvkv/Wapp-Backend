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
    public class Hardware:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Barcode { get; set; }
      
        public int LabelId { get; set; }
       
        public int ModelId { get; set; }
        public string Type { get; set; }
        public bool IsDefective { get; set; }
#nullable enable
        public string? Explanation { get; set; }
        public bool IsDebitted { get; set; }
        
           

    }
}
