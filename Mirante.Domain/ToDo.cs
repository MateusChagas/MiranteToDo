using System.ComponentModel.DataAnnotations;

namespace Mirante.Model
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }              
        public DateTime DueDate { get; set; }
        public Tasks Status { get; set; } = Tasks.Pending;
        public ToDo()
        {
            Title = string.Empty;
            Description = string.Empty;            
        }
        public ToDo(int id, string title, string description, string isCompleted,DateTime dueDate)
        {
            Id = id;
            Title = title;
            Description = description;            
            DueDate = dueDate;
        }
       
    }
}
