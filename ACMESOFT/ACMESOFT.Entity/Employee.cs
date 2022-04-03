using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ACMESOFT.Entity
{
    public class Employee
    {
        [Key]
        public int? EmployeeId { get; set; }
        public int? PersonId { get; set; }

        [ForeignKey("PersonId")]
        [JsonIgnore]
        public virtual Person? Person { get; set; }
        [MaxLength(16)]
        public string EmployeeNumber { get; set; }
        public DateTime EmployeeDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool? IsDeleted { get; set; }
        public Employee()
        {

        }
    }
}
