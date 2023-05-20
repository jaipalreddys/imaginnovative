using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imaginnovative
{
    public class PhoneNumber
    {
        [Key, Column(Order = 0)]
        [StringLength(50)]
        public string EmployeeId { get; set; }

        [Key, Column(Order = 1)]
        [StringLength(20)]
        public string PhoneNumbe { get; set; }

    }
   
}
