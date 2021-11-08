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
        private bool _value;
        [Key]
        public int Id { get; set; }
        public string Barcode { get; set; }
        [ForeignKey("LabelId")]
        public int LabelId { get; set; }
        [ForeignKey("ModelId")]
        public int ModelId { get; set; }
        public string Type { get; set; }
        public bool IsDefective { get; set; }
        public string Explanation { get; set; }
        public bool IsDebitted
        {
            get { return _value; } set
            {
                if (IsDefective)
                {
                    _value = false;
                }
                else
                {
                    _value = true;
                };
            } }

    }
}
