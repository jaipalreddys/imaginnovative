using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace imaginnovative
{    
    public class Employee
    {
        [Key]
        [StringLength(50)]
        public string EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime DOJ { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

        public virtual List<PhoneNumber> PhoneNumbers { get; set; }
    }

}
