using AutoMapper;
using Siteware.Prototipo.BLL;
using Siteware.Prototipo.DAL.Entity.Context;
using Siteware.Prototipo.Dominio;
using Siteware.Prototipo.Repositorio.Entity;
using Siteware.Prototipo.Repositorios;
using Siteware.Prototipo.Web.ViewModels.Carrinho;
using Siteware.Prototipo.Web.ViewModels.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Siteware.Prototipo.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private IRepositorioCRUD<Produto, int> dbProduto = new ProdutoRepositorio(new PrototipoDbContext());
        // GET: Carrinho
        public ActionResult Index()
        {
            ProdutoShowViewModel produtoInicial = new ProdutoShowViewModel { Id = 0, Nome = "Selecione o Produto" };
            List<ProdutoShowViewModel> lstProdutos = Mapper.Map<List<Produto>, List<ProdutoShowViewModel>>(dbProduto.Selecionar());
            lstProdutos.Insert(0, produtoInicial);
            SelectList ddProdutos = new SelectList(lstProdutos, "Id", "Nome");
            ViewBag.ddProdutos = ddProdutos;

            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "IdProduto,NomeProduto,ValorUnitario,QuantidadeCompra")] CarrinhoValidationViewModel viewModel)
        {
            Produto produto = dbProduto.SelecionarPorId(viewModel.IdProduto);
            List<CarrinhoShowViewModel> lstlstCarrinhoShowViewModel = new List<CarrinhoShowViewModel>();

            CalculoPromocao calculo = new CalculoPromocao();

            lstlstCarrinhoShowViewModel = (List<CarrinhoShowViewModel>)TempData["lstCarrinhoShowViewModel"];
            if (lstlstCarrinhoShowViewModel == null)
                lstlstCarrinhoShowViewModel = new List<CarrinhoShowViewModel>();
            else if(lstlstCarrinhoShowViewModel.FirstOrDefault(x=>x.IdProduto==viewModel.IdProduto)!=null)
            {
                CarrinhoShowViewModel car = lstlstCarrinhoShowViewModel.FirstOrDefault(x => x.IdProduto == viewModel.IdProduto);
                viewModel.QuantidadeCompra += car.QuantidadeCompra;
                lstlstCarrinhoShowViewModel.Remove(car);
            }

            lstlstCarrinhoShowViewModel.Add( Mapper.Map<Carrinho, CarrinhoShowViewModel>(calculo.CalcularCompra(Mapper.Map<CarrinhoValidationViewModel, Carrinho>(viewModel))));

            TempData["lstCarrinhoShowViewModel"] = lstlstCarrinhoShowViewModel;
            ViewBag.lstCarrinhoShowViewModel = lstlstCarrinhoShowViewModel;

            ProdutoShowViewModel produtoInicial = new ProdutoShowViewModel { Id = 0, Nome = "Selecione o Produto" };
            List<ProdutoShowViewModel> lstProdutos = Mapper.Map<List<Produto>, List<ProdutoShowViewModel>>(dbProduto.Selecionar());
            lstProdutos.Insert(0, produtoInicial);
            SelectList ddProdutos = new SelectList(lstProdutos, "Id", "Nome");
            ViewBag.ddProdutos = ddProdutos;
            viewModel = new CarrinhoValidationViewModel();
            return View(viewModel);
        }

        public ActionResult SelecionarProduto(string strId)
        {
            int id = Convert.ToInt32(strId);
            CarrinhoValidationViewModel viewModel = new CarrinhoValidationViewModel();
            Produto produto = dbProduto.SelecionarPorId(id);
            viewModel.IdProduto = produto.Id;
            viewModel.NomeProduto = produto.Nome;
            viewModel.ValorUnitario = produto.Preco;

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}