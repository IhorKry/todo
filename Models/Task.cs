using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public bool Done { get; set; }

        public Task(int id, string name, bool done)
        {
            Id = id;
            Name = name;
            Done = done;
        }

        public Task()
        {
        }
    }
}