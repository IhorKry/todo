using System.Collections.Generic;
using System.Linq;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class TaskService
    {
        private ApplicationDbContext Context;

        public TaskService(ApplicationDbContext context)
        {
            Context = context;
        }

        public Task Create(Task task)
        {
            Context.Tasks.Add(task);
            Context.SaveChanges();
            return task;
        }

        public List<Task> All()
        {
            return Context.Tasks.ToList();
        }

        public Task GetById(int id)
        {
            return Context.Tasks.Where(Task => Task.Id == id).First();
        }

        public void DeleteById(int id)
        {
            var task = Context.Tasks.Where(Task => Task.Id == id).First();
            Context.Tasks.Remove(task);
            Context.SaveChanges();
        }

        public void DeleteAll()
        {
            Context.Tasks.RemoveRange(Context.Tasks);
            Context.SaveChanges();
        }

        public Task SwitchReadyState(int id)
        {
            var task = Context.Tasks.Where(Task => Task.Id == id).First();
            task.Done = !task.Done;
            Context.SaveChanges();
            return task;
        }

        public Task ChangeName(int id, Task update)
        {
            var task = Context.Tasks.Where(Task => Task.Id == id).First();
            task.Name = update.Name;
            Context.SaveChanges();
            return task;
        }
    }
}