using System.ComponentModel.DataAnnotations;

namespace userSide.Models
{
    public class category
    {
        [Key]
        public int categoryId { get; set; }
        [Required]
        public string categoryName { get; set; }
        [Required]
        public string categoryType { get; set; }
        public ICollection<product> products { get; set; } = new List<product>();
        
    }
}
