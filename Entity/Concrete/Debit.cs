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
    [Table("Debits")]
    public class Debit : IEntity
    {
        [Key]
        public int DebitId { get; set; }
        public int DebitStatusId { get; set; }
        public int OlderOwnerId { get; set; }
        public int OwnerId { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime LastChange { get; set; }
        public string HardwareIds { get; set; }
        public int ProjectId { get; set; }
#nullable enable
        public string? Explanation { get; set; }
#nullable disable
        public int PersonalId { get; set; }
        //Her zimmet oluşturulyrjen yazılımda formu oluşturulup tutulacak.
        public string DebitFormPath { get; set; }


    }
}
