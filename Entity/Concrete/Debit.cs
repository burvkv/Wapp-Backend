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
        [ForeignKey("DebitStatusId")]
        public int DebitStatusId { get; set; }
        [ForeignKey("OlderOwnerId")]
        public int OlderOwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public int OwnerId { get; set; }
        public bool IsActive { get; set; }
        public int HardwareId { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public string Explanation { get; set; }
        [ForeignKey("PersonalId")]
        public int PersonalId { get; set; }




    }
}
