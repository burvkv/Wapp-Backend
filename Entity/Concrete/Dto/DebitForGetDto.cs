using Core.Entity.Abstract;
using System;


namespace Entity.Concrete.Dto
{
    public class DebitForGetDto : IDto
    {
        public int DebitId { get; set; }
        public string OwnerName { get; set; }
        public string ProjectName { get; set; }
        public string Explanation { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime LastChange { get; set; }


    }
}
