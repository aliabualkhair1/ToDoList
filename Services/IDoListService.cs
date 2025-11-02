using ToDoList.Controllers;
using ToDoList.Entities;
using ToDoListAPIs.Entities;

namespace ToDoList.Services
{
    public interface IDoListService
    {
        IEnumerable<TaskEntity> GetAll();
        TaskEntity Add(TasksDTO task);
        bool Remove(string text);
        void Toggle(string text);
    }
}
