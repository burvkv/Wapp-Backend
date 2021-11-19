using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IToDoService
    {
        IDataResult<List<ToDoDto>> GetList(string key = null);
        IResult Update(ToDo toDo);
        IResult Add(ToDo toDo);
        IResult Delete(ToDo toDo);
    }


}
