using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService TaskService;
        public TaskController(TaskService taskService)
        {
            TaskService = taskService;
        }

        // GET /tasks
        [HttpGet("")]
        public List<Task> GetTasks()
        {
            return TaskService.All();
        }

        // GET /tasks/5
        [HttpGet("{id}")]
        public ActionResult<Task> GetTaskById(int id)
        {
            try
            {
                return TaskService.GetById(id);
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        // POST /tasks
        [HttpPost("")]
        public ActionResult CreateTask(Task task)
        {
            return Ok(TaskService.Create(task));
        }

        // PUT /tasks/5/switchReadyState
        [HttpPut("{id}/switchReadyState")]
        public ActionResult SwitchReadyState(int id)
        {
            try
            {
                return Ok(TaskService.SwitchReadyState(id));
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        // PUT /tasks/5/changeName name=newName
        [HttpPut("{id}/changeName")]
        public ActionResult ChangeName(int id, Task task)
        {
            try
            {
                return Ok(TaskService.ChangeName(id, task));
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        // DELETE /tasks
        [HttpDelete("")]
        public ActionResult DeleteAllTasks()
        {
            TaskService.DeleteAll();
            return NoContent();
        }

        // DELETE /tasks/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTaskById(int id)
        {
            try
            {
                TaskService.DeleteById(id);
                return NoContent();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}