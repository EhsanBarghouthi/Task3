using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace userSide.Models
{
    public class product
    {
        [Key]
        public int productId { get; set; }
        [Required]
        public string productName { get; set; }
        //[ValidateNever]
        public string productDescription { get; set; }
        [ValidateNever]
        public string imagePhoto {  get; set; }
        //[ValidateNever]

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]

        public double productPrice { get; set; }
        //[ValidateNever]

        [Required(ErrorMessage = "Please select a category........")]
        public int? categoryId { get; set; }
        [ValidateNever]
        public category category { get; set; }
    }
}
