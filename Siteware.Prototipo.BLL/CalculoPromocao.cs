using Siteware.Prototipo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Prototipo.BLL
{
    public class CalculoPromocao
    {
        public Compra CalcularCompra(Compra _compra)
        {
            Compra compra = new Compra();
            compra = _compra;

            if (string.IsNullOrEmpty(compra.Produto.Promocao.Parametros))
            {
                List<string> lstPartes = compra.Produto.Promocao.Parametros.Split('|').ToList();
                List<string> lstComparacao = lstPartes[0].Split(' ').ToList();
                List<string> lstResultado = lstPartes[1].Split(' ').ToList();

                if (lstComparacao[0].ToLower().Equals("quantidade"))
                {
                    int pCompara = Convert.ToInt32(lstComparacao[2]);
                    if (lstComparacao[1].Equals("="))
                    {
                        if (lstResultado[0].ToLower().Equals("quantidade"))
                        {
                            int qtdAjuste = Convert.ToInt32(lstResultado[2]);
                            if (lstResultado[1].ToLower().Equals("+"))
                            {
                                compra.QuantidadeFinal = compra.QuantidadeInicial + ((compra.QuantidadeInicial / pCompara) * qtdAjuste) + (compra.QuantidadeInicial % pCompara);
                                compra.ValorFinal = compra.ValorInicial;
                            }
                        }
                        else if (lstResultado[0].ToLower().Equals("valor"))
                        {
                            decimal pAjuste = Convert.ToDecimal(lstResultado[2]);
                            if (lstResultado[1].ToLower().Equals("="))
                            {
                                compra.QuantidadeFinal = compra.QuantidadeInicial;
                                compra.ValorFinal = pAjuste;
                            }
                        }
                        else if (lstResultado[0].ToLower().Equals("desconto"))
                        {
                            decimal pAjuste = Convert.ToDecimal(lstResultado[2]);
                            if (lstResultado[1].ToLower().Equals("r$"))
                            {
                                compra.QuantidadeFinal = compra.QuantidadeInicial;
                                compra.ValorFinal = compra.ValorInicial - (compra.QuantidadeFinal / pCompara) * pAjuste;
                            }
                            else if (lstResultado[1].ToLower().Equals("%"))
                            {
                                compra.QuantidadeFinal = compra.QuantidadeInicial;
                                compra.ValorFinal = compra.ValorInicial - (compra.QuantidadeFinal / pCompara) * (pAjuste);
                            }
                        }
                    }
                    else if (lstComparacao[1].Equals(">"))
                    {
                        if (lstResultado[0].ToLower().Equals("quantidade"))
                        {
                            int qtdAjuste = Convert.ToInt32(lstResultado[1]);
                            if (lstResultado[1].ToLower().Equals("+"))
                            {
                                compra.QuantidadeFinal = compra.QuantidadeInicial + qtdAjuste;
                                compra.ValorFinal = compra.ValorInicial;
                            }
                        }
                        else if (lstResultado[0].ToLower().Equals("valor"))
                        {
                            decimal pAjuste = Convert.ToDecimal(lstResultado[1]);
                        }
                    }
                }
                else if (lstComparacao[0].ToLower().Equals("valor"))
                {

                }
                else
                {

                }
            }
            else
            {
                compra.QuantidadeFinal = compra.QuantidadeInicial;
                compra.ValorFinal = compra.ValorInicial;
            }
            return compra;
        }
    }
}
