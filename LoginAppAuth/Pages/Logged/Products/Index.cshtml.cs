using LoginAppAuth.Data;
using LoginAppAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginAppAuth.Pages.Logged.Products
{
    //s� clientes autorizados podem ver essa p�gina
    [Authorize]
    public class IndexModel : PageModel
    {
        //parte do Entity Framework para dados no banco de dados escolhido (no meu caso Sql Server)
        private readonly ApplicationDbContext context;

        //a lista de produtos que vai ser carregada da base de dados
        public List<Product> Products { get; set; } = new List<Product>();

        //construtor para inicializa��o da base de dados
        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        //quando o usu�rio pedir por esta p�gina, todos os produtos v�o vir
        //da base de dados da tabela Products
        public void OnGet()
        {
            Products = context.Products.OrderByDescending(p => p.Id).ToList();
        }
    }
}
