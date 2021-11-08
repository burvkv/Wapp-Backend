using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity.Concrete
{
    public class Employee:IEntity
    {
        private DateTime _leftDate;
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber  { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int ProjectId { get; set; }
        public bool EmployeeStatus { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime? LeftDate
        {
            get
            {
                if (!EmployeeStatus)
                {
                    return _leftDate;
                }
                else
                {
                    return null;
                };} 
            set { _leftDate = DateTime.Now; } }


    }
}
