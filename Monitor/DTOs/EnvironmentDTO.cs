using System.ComponentModel.DataAnnotations;

namespace Monitor.DTOs
{
    public class EnvironmentDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
