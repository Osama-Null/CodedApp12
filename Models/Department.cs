using System.ComponentModel.DataAnnotations;

namespace CodedApp12.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name = "Department")]
        [Required]
        [MinLength(3, ErrorMessage = "*Minimum 3")]
        public string Name { get; set; }
    }
}
