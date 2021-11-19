using Core.DataAccess;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IToDoDal : IEntityRepository<ToDo>
    {
        public List<ToDoDto> GetList(string key = null);
    }
}
