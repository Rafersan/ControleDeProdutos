using LoginAppAuth.Data;
using LoginAppAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LoginAppAuth.Pages.Logged.Products
{
    //s� clientes autorizados podem ver essa p�gina
    [Authorize]
    public class EditModel : PageModel
    {
        //parte do Entity Framework para dados no banco de dados escolhido (no meu caso Sql Server)
        private readonly ApplicationDbContext context;
        //centralizar aonde as p�ginas ficam
        private readonly IConfiguration configuration;

        //bind das propriedades no form
        [BindProperty]
        public ProductInfo ProductInfo { get; set; } = new ProductInfo();
        public Product Product { get; set; } = new Product();

        //mensagens de erro e successo
        public string errorMessage = string.Empty;
        public string successMessage = string.Empty;

        //construtor para inicializa��o da base de dados e centraliza��o de p�ginas
        public EditModel(ApplicationDbContext context, IConfiguration config)
        {
            this.context = context;
            this.configuration = config;
        }


        //get para verificar se o produto (id) existe no sistema e mostrar
        //para o cliente
        //se n�o existir, � redirecionado para a p�gina de lista de produtos
        //da tabela Products
        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect(configuration["AppPages:ProductsList"]!);
                return;
            }

            var product = context.Products.Find(id);
            if (product == null)
            {
                Response.Redirect(configuration["AppPages:ProductsList"]!);
                return;
            }

            ProductInfo.Title = product.Title;
            ProductInfo.Description = product.Description;
            ProductInfo.Name = product.Name;
            ProductInfo.Price = product.Price;

            Product = product;
        }

        //verifica se � v�lido o form (informa��es colocados pelo usu�rio)
        //e modifica produto encontrado na base de dados
        //da tabela Products
        public void OnPost(int? id)
        {
            if (id == null)
            {
                Response.Redirect(configuration["AppPages:ProductsList"]!);
                return;
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Por favor, digite em todos os campos obrigat�rios";
                return;
            }

            var product = context.Products.Find(id);
            if (product == null)
            {
                Response.Redirect(configuration["AppPages:ProductsList"]!);
                return;
            }

            product.Title = ProductInfo.Title;
            product.Description = ProductInfo.Description;
            product.Name = ProductInfo.Name;
            product.Price = ProductInfo.Price;

            context.SaveChanges();

            Product = product;

            Response.Redirect(configuration["AppPages:ProductsList"]!);
        }
    }
}
