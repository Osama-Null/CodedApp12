using System.ComponentModel.DataAnnotations;

namespace CodedApp12.Models
{
    public class Product
    {
        [Display(Name = "Item No.")]
        public int ProductId { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "*Enter product name")]
        [MinLength(4, ErrorMessage ="*Min 3 char")]
        public string ProductName { get; set; }
        [Display(Name = "Price")]
        public decimal? Price { get; set; }
        [Display(Name = "Qty.")]
        public int Qty { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "*Enter product description")] // Client side
        public string? Description { get; set; }
    }
}
