using SWLojaVirtual.Dominio.Entidades;
using SWLojaVirtual.Dominio.Repositório;
using SWLojaVirtual.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace SWLojaVirtual.Web.Controllers
{      
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorioProdutos;

        /// <summary>
        /// Adicionar produto ao carrinho
        /// </summary>
        /// <param name="IdProduto"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult Adicionar(int IdProduto, string returnUrl)
        {
            _repositorioProdutos = new ProdutosRepositorio();

            Produto produto = _repositorioProdutos.Produtos.FirstOrDefault(p => p.IdProduto == IdProduto);

            //int bonusPromocao = produto.Promocao.Leve - produto.Promocao.Pague;

            if (produto != null)
                ObterCarrinho().AdicionarItem(produto, 1);//modificar para receber qtde de maneira dinâmica

            return RedirectToAction("Index", new {returnUrl});
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho) Session["Carrinho"];

            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }

            return carrinho;
        }

        /// <summary>
        /// Remover produto do carrinho
        /// </summary>
        /// <param name="IdProduto"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult Remover(int IdProduto, string returnUrl)
        {            
            _repositorioProdutos = new ProdutosRepositorio();

            Produto produto = _repositorioProdutos.Produtos.FirstOrDefault(p => p.IdProduto == IdProduto);

            if (produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }

            return RedirectToAction("Index", new {returnUrl});
        }
        
        /// <summary>
        /// Página onde são listados os produtos adicionados ao carrinho
        /// </summary>
        /// <param name="returnurl"></param>
        /// <returns></returns>
        public ViewResult Index(string returnurl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnurl
            });
        }

        /// <summary>
        /// Resumo do Carrinho
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        /// <summary>
        /// Fechar Pedido
        /// </summary>
        /// <returns></returns>
        public ViewResult FecharPedido()
        {
            return View();
        }
    }
}