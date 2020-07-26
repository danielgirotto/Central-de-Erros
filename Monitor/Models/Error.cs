using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monitor.Models
{
    [Table("error")]
    public class Error
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("origin"), StringLength(200)]
        public string Origin { get; set; }

        [Required, Column("title"), StringLength(200)]
        public string Title { get; set; }

        [Required, Column("description"), MaxLength]
        public string Description { get; set; }

        [Column("environment_id")]
        public int EnvironmentId { get; set; }

        [ForeignKey("EnvironmentId")]
        public virtual Environment Environment { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Column("level_id")]
        public int LevelId { get; set; }

        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }

        [Required, Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
