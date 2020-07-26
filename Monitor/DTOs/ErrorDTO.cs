using System;
using System.ComponentModel.DataAnnotations;

namespace Monitor.DTOs
{
    public class ErrorDTO
    {
        public int Id { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int EnvironmentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int LevelId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
