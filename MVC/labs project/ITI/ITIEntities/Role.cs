using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITIEntities
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<User> Users { get; set; } = new List<User>();
    }
}