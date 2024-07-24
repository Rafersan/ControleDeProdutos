using LoginAppAuth.Data;
using LoginAppAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;

namespace LoginAppAuth.Pages.Logged.Products
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public string errorMessage = "";
        public string successMessage = "";

        [BindProperty]
        public ProductInfo NewProduct { get; set; } = new ProductInfo();
        public CreateModel( ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (NewProduct.Price < 0)
            {
                ModelState.AddModelError("NewProduct.Price", "O valor não pode ser menor que 0");
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Por favor, digite em todos os campos obrigatórios";
                return;
            }
            
            Product product = new()
            {
                Name = NewProduct.Name,
                Description = NewProduct.Description,
                Title = NewProduct.Title,
                Price = NewProduct.Price,
            };

            context.Products.Add(product);
            context.SaveChanges();

            NewProduct.Title = "";
            NewProduct.Description = "";
            NewProduct.Name = "";
            NewProduct.Price = 0;

            ModelState.Clear();

            successMessage = "Novo produto registrado";

        }
    }
}
