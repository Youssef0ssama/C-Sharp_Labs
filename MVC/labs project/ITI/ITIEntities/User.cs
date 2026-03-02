using System.ComponentModel.DataAnnotations;

namespace ITIEntities
{
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(256)]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}