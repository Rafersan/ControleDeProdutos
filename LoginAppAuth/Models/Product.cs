using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LoginAppAuth.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Precision(16,2)]
        public decimal Price { get; set; } = 0;
    }
}
