using Siteware.Prototipo.DAL.Entity.Context;
using Siteware.Prototipo.Dominio;
using Siteware.Prototipo.Repositorio.Entity;
using Siteware.Prototipo.Repositorios;
using System;

namespace Siteware.Prototipo.BLL
{
    public class CalculoPromocao
    {
        private IRepositorioCRUD<Produto, int> dbProduto = new ProdutoRepositorio(new PrototipoDbContext());
        Carrinho carrinho;
        Promocao promocao;
        public Carrinho CalcularCompra(Carrinho _carrinho)
        {
            carrinho = _carrinho;
            carrinho.ValorCompra = carrinho.ValorUnitario * carrinho.QuantidadeCompra;
            if (dbProduto.SelecionarPorId(carrinho.IdProduto).Promocao == null)
            {
                carrinho.QuantidadeFinal = carrinho.QuantidadeCompra;
                carrinho.Promocao = "";
            }
            else
            {
                promocao = dbProduto.SelecionarPorId(carrinho.IdProduto).Promocao;
                carrinho.Promocao = promocao.Nome;
                if (promocao.Tipo.ToLower().Equals("brinde"))
                {
                    carrinho.QuantidadeFinal = CalcularQuantidade() + carrinho.QuantidadeCompra;
                }
                else if (promocao.Tipo.ToLower().Equals("preço fixo"))
                {
                    carrinho.ValorCompra = CalculaPrecoFixo();
                    carrinho.QuantidadeFinal = carrinho.QuantidadeCompra;
                }
                else if (promocao.Tipo.ToLower().Equals("desconto"))
                {
                    carrinho.ValorCompra = CalcularDesconto();
                    carrinho.QuantidadeFinal = carrinho.QuantidadeCompra;
                }
                else
                {
                    carrinho.QuantidadeFinal = carrinho.QuantidadeCompra;
                    carrinho.ValorCompra = carrinho.ValorUnitario * carrinho.QuantidadeCompra;
                }
            }
            return carrinho;
        }

        private int CalcularQuantidade()
        {
            int retorno = 0;
            if (promocao.BasePropriedade.ToLower().Equals("itens"))
            {
                int itens = carrinho.QuantidadeCompra;
                if (promocao.BaseTipo.ToLower().Equals("a cada"))
                {
                    retorno = (itens - (itens % (int)(promocao.BaseValor))) / (int)(promocao.BaseValor);
                }
                if (promocao.BaseTipo.ToLower().Equals("acima de"))
                {
                    retorno = itens > (int)(promocao.BaseValor) ? (int)(promocao.ResultadoValor) : 0;
                }
            }
            if (promocao.BasePropriedade.ToLower().Equals("valor"))
            {
                decimal valor = carrinho.ValorCompra;
                if (promocao.BaseTipo.ToLower().Equals("a cada"))
                {
                    retorno = (int)(valor / promocao.BaseValor);
                }
                if (promocao.BaseTipo.ToLower().Equals("acima de"))
                {
                    retorno = valor > (int)(promocao.BaseValor) ? (int)(promocao.ResultadoValor) : 0;
                }
            }
            if (promocao.BasePropriedade.ToLower().Equals("valor"))
            {
            }
            return retorno;
        }

        private decimal CalculaPrecoFixo()
        {
            decimal retorno = 0;
            if (promocao.BasePropriedade.ToLower().Equals("itens"))
            {
                int itens = carrinho.QuantidadeCompra;
                if (promocao.BaseTipo.ToLower().Equals("a cada"))
                {
                    int qtd = (itens - (itens % (int)(promocao.BaseValor))) / (int)(promocao.BaseValor);
                    retorno = qtd * promocao.ResultadoValor + (itens % (int)(promocao.BaseValor)) * carrinho.ValorUnitario;
                }
                //if (promocao.BaseTipo.ToLower().Equals("acima de"))
                //{
                //    retorno = itens > (int)(promocao.BaseValor) ? (int)(promocao.ResultadoValor) : 0;
                //}
            }
            if (promocao.BasePropriedade.ToLower().Equals("valor"))
            {
                decimal valor = carrinho.ValorCompra;
                if (promocao.BaseTipo.ToLower().Equals("a cada"))
                {
                    int qtd = (int)(valor / promocao.BaseValor);
                    decimal resto = valor % promocao.BaseValor;
                    retorno = qtd * promocao.ResultadoValor + resto;
                }
                //if (promocao.BaseTipo.ToLower().Equals("acima de"))
                //{
                //    retorno = valor > (int)(promocao.BaseValor) ? (int)(promocao.ResultadoValor) : 0;
                //}
            }
            return retorno;
        }

        private decimal CalcularDesconto()
        {
            decimal retorno = 0;
            if (promocao.BasePropriedade.ToLower().Equals("itens"))
            {
                int itens = carrinho.QuantidadeCompra;
                if (promocao.BaseTipo.ToLower().Equals("a cada"))
                {
                    if (promocao.ResultadoTipo.ToLower().Equals("r$"))
                    {
                        int qtd = (itens - (itens % (int)(promocao.BaseValor))) / (int)(promocao.BaseValor);
                        retorno = carrinho.ValorCompra - (qtd * promocao.ResultadoValor);
                    }
                    if (promocao.ResultadoTipo.ToLower().Equals("%"))
                    {
                        int qtd = (itens - (itens % (int)(promocao.BaseValor))) / (int)(promocao.BaseValor);
                        retorno = carrinho.ValorCompra - ((qtd * carrinho.ValorUnitario * promocao.BaseValor) * (promocao.ResultadoValor / 100));
                    }
                }
                if (promocao.BaseTipo.ToLower().Equals("acima de"))
                {
                    if (promocao.ResultadoTipo.ToLower().Equals("r$"))
                    {
                        retorno = carrinho.QuantidadeCompra > promocao.BaseValor ? carrinho.ValorCompra - promocao.ResultadoValor : carrinho.ValorCompra;
                    }
                    if (promocao.ResultadoTipo.ToLower().Equals("%"))
                    {
                        retorno = carrinho.QuantidadeCompra > promocao.BaseValor ? carrinho.ValorCompra - (carrinho.ValorCompra * (promocao.ResultadoValor / 100)) : carrinho.ValorCompra;
                    }
                }
            }
            if (promocao.BasePropriedade.ToLower().Equals("valor"))
            {
                decimal valor = carrinho.ValorCompra;
                if (promocao.BaseTipo.ToLower().Equals("a cada"))
                {
                    if (promocao.ResultadoTipo.ToLower().Equals("r$"))
                    {
                        int qtd = (int)(valor / promocao.BaseValor);
                        retorno = carrinho.ValorCompra - qtd * promocao.ResultadoValor;
                    }
                    if (promocao.ResultadoTipo.ToLower().Equals("%"))
                    {
                        int qtd = (int)(valor / promocao.BaseValor);
                        retorno = carrinho.ValorCompra - ((qtd * promocao.BaseValor) * (promocao.ResultadoValor / 100));
                    }
                }
                if (promocao.BaseTipo.ToLower().Equals("acima de"))
                {
                    if (promocao.ResultadoTipo.ToLower().Equals("r$"))
                    {
                        retorno = carrinho.ValorCompra > promocao.BaseValor ? carrinho.ValorCompra - promocao.ResultadoValor : carrinho.ValorCompra;
                    }
                    if (promocao.ResultadoTipo.ToLower().Equals("%"))
                    {
                        retorno = carrinho.ValorCompra > promocao.BaseValor ? carrinho.ValorCompra - (carrinho.ValorCompra * (promocao.ResultadoValor / 100)) : carrinho.ValorCompra;
                    }
                }
            }
            return retorno;
        }
    }
}
