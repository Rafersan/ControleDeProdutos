using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LoginAppAuth.Models
{
    public class ProductInfo
    {
        [Required(ErrorMessage ="Por favor digite o nome"), MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor digite a descrição"), MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor digite o título"), MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Por favor digite o preço")]
        public decimal Price { get; set; } = 0;

        // eu posso ter o ? que representa a propriedade pode ser nula
    }
}
