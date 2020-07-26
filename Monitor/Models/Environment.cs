using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monitor.Models
{
    [Table("environment")]
    public class Environment
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("name"), StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Error> Errors { get; set; }
    }
}
