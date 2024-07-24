using LoginAppAuth.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginAppAuth.Pages.Logged.Products
{
    //s� clientes autorizados podem ver essa p�gina
    //tem tamb�m autoriza��o por "Roles" que n�o � feita neste projeto
    [Authorize]
    public class DeleteModel : PageModel
    {
        //parte do Entity Framework para dados no banco de dados escolhido (no meu caso Sql Server)
        private readonly ApplicationDbContext context;
        //centralizar aonde as p�ginas ficam
        private readonly IConfiguration configuration;

        //construtor para inicializa��o da base de dados e centraliza��o de p�ginas
        public DeleteModel(ApplicationDbContext context, IConfiguration config)
        {
            this.context = context;
            this.configuration = config;
        }

        //No get, verificar se o ID do produto pedido existe e deletar o produto
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

            context.Products.Remove(product);
            context.SaveChanges();

            Response.Redirect(configuration["AppPages:ProductsList"]!);

        }
    }
}
