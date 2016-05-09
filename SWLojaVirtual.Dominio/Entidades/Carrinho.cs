using System.Collections.Generic;
using System.Linq;

namespace SWLojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();

        //Adicionar ao carrinho
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.IdProduto == produto.IdProduto);

            if(item == null)
            {
                _itemCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }

        //Remover produto do carrinho
        public void RemoverItem(Produto produto)
        {
            _itemCarrinho.RemoveAll(p => p.Produto.IdProduto == produto.IdProduto);
        }

        //Valor total do carrinho
        public decimal ObterValorTotal()
        {
            return _itemCarrinho.Sum(p => p.Produto.Preco * p.Quantidade);
        }

        //Limpar carrinho
        public void LimparCarrinho()
        {
            _itemCarrinho.Clear();
        }

        //Itens adicionados ao carrinho
        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itemCarrinho; }
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
