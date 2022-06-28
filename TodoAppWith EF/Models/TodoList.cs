using System.ComponentModel.DataAnnotations;

namespace TodoAppWith_EF.Models
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string DateCreated { get; set; }

    }
}
