using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.Dto
{
    public class DeletedHardwareLogModelDto : IDto
    {
        public int Id { get; set; }
        public string Barcode { get; set; }

        public int LabelId { get; set; }

        public int ModelId { get; set; }
        public string Type { get; set; }
        public bool IsDefective { get; set; }
#nullable enable
        public string? Explanation { get; set; }
#nullable disable
        public bool IsDebitted { get; set; }
        public string  UserName { get; set; }
    }
}
