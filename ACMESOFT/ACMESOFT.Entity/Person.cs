using System.ComponentModel.DataAnnotations;

namespace ACMESOFT.Entity
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [MaxLength(128)]
        public string? LastName { get; set; }
        [MaxLength(128)]
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public virtual Employee? Employee { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
