using Core.Entity.Abstract;


namespace Entity.Concrete.Dto
{
    public class ToDoDto : IEntity
    {
        public int TodoId { get; set; }
        public string EmployeeName { get; set; }
        public string Explanation { get; set; }
        public string Date { get; set; }
        public string ProcessName { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
#nullable enable
        public string? Note { get; set; }
#nullable disable
    }
}
