using System.ComponentModel.DataAnnotations;

namespace Monitor.DTOs
{
    public class LevelDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
