using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monitor.Models
{
    [Table("user")]
    public class User
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("email"), StringLength(100)]
        public string Email { get; set; }

        [Required, Column("password"), StringLength(255)]
        public string Password { get; set; }
    }
}
