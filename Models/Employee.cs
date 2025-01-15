using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodedApp12.Models
{
    public class Employee
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required(ErrorMessage ="*Enter name")]
        [MinLength(3)]
        public string Name { get; set; }
        [Required(ErrorMessage ="*Enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? Phone { get; set; }
        [Required(ErrorMessage = "*Add salary")]
        [Range(0.1,10000, ErrorMessage = "*Salary range out of range! [0.1-10000]")] // nvarchar(1000) if used max(1000)
        public decimal? Salary { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime HDate { get; set; }
        [ForeignKey("Department")] // FK
        public int DepartmentId{ get; set; }
        public Department? Department { get; set; }
    }
}
