using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public string ImageUrl { get; set; }

        // Foreign key for the Category
        public int CategoryId { get; set; }

    }
}
