using Microsoft.AspNetCore.Http.HttpResults;
using ToDoList.Controllers;
using ToDoList.Entities;
using ToDoListAPIs.Entities;

namespace ToDoList.Services
{
    public class DoListConfiguration : IDoListService
    {
        private readonly List<TaskEntity> service=new List<TaskEntity>();
        public IEnumerable<TaskEntity> GetAll()
        {
            return service.ToList();
        }
        public TaskEntity Add(TasksDTO task)
        {
            var _task = new TaskEntity {Text=task.Text};
            service.Add(_task);
            return _task;
        }
        public bool Remove(string text)
        {
            var deletetask = service.FirstOrDefault(dt=>dt.Text==text);
            if (deletetask == null) return false;
            service.Remove(deletetask);
            return true;   
        }

        public void Toggle(string text)
        {
            var Iscompleted=service.FirstOrDefault(dt=>dt.Text==text);
            if(Iscompleted != null)
            {
                Iscompleted.IsCompleted = !Iscompleted.IsCompleted;
            }
        }
    }
}
