using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Security.Claims;
using ToDoList.Entities;
using ToDoList.Services;
using ToDoListAPIs.Entities;

namespace ToDoList.Controllers
{
    public class TasksController : Controller
    {
        private readonly IDoListService service;

        public TasksController(IDoListService Service)
        {
            service = Service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var alltasks = service.GetAll();
            return View("Views/Home/Index.cshtml", alltasks);
        }
        [HttpPost]
        public IActionResult AddTask(TasksDTO tasks)
        {
            if (ModelState.IsValid)
            {
                var addtask = service.Add(tasks);
                return RedirectToAction(nameof(GetAll));
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult DeleteTask(string text)
        {
            var deletetask = service.Remove(text);
            return RedirectToAction(nameof(GetAll));
        }
        [HttpPost]
        public IActionResult Toggle(string text)
        {
            service.Toggle(text);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
