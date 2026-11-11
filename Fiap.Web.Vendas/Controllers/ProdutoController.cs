using Microsoft.AspNetCore.Mvc;
using Fiap.Web.Vendas.Models;

namespace Fiap.Web.Vendas.Controllers
{
    public class ProdutoController : Controller
    {


        private static readonly List<ProdutoModel> Produtos = new()
        {
            new ProdutoModel { ProdutoId = 1, Nome = "Notebook", Preco = 4500m, Quantidade = 5, Categoria = "Informatica" },
            new ProdutoModel { ProdutoId = 2, Nome = "Mouse Gamer", Preco = 250m, Quantidade = 3, Categoria = "Perifericos" },
            new ProdutoModel { ProdutoId = 3, Nome = "Smartphone", Preco = 400m, Quantidade = 8, Categoria = "Telefonia" }
        };


        [HttpGet]
        public IActionResult Index()
        {
            return View(Produtos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(ProdutoModel produto)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensagemFalha"] = $"Erro ao cadastrar produto. {string.Join(" ", ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)))}";
                //return View(produto);
                return RedirectToAction(nameof(Index));
            }

            produto.ProdutoId = Produtos.Count + 1;
            Produtos.Add(produto);

            TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}
