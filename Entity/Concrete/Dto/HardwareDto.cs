using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity.Concrete.Dto
{
    public class HardwareDto:IDto
    {
        public int Id { get; set; }
        public string Barcode  { get; set; }
        public string Label { get; set; }
        public string ModelName { get; set; }
        public string Type { get; set; }
        public string Explanation { get; set; }
        public bool IsDefective { get; set; }
        public bool IsDebitted { get; set; }
    }
}
