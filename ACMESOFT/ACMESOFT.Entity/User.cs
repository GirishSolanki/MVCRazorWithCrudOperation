using System.ComponentModel.DataAnnotations;

namespace ACMESOFT.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(128)]
        public string? UserName { get; set; }
        [MaxLength(128)]
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
