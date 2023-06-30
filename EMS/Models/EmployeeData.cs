using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class EmployeeData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(12)")]
        public string Name { get; set; } = "";

        [ForeignKey("Designation")]
        public string Designation { get; set; } = "";

        [ForeignKey("WorkHour")]
        [DisplayName("Working Hours")]
        [Range(0,12, ErrorMessage = "Working Hours must be between 0 and 12")]
        public int WorkHourId { get; set; }

        [ForeignKey("PaymentRule")]
        [DisplayName("Payment Type")]
        [Range(1,2,ErrorMessage ="Payment Type must be either 1 or 2!")]
        public int PaymentRuleId { get; set; }
    }
}
