using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Siteware.Prototipo.Dominio;
using Siteware.Prototipo.DAL.Entity.Context;
using AutoMapper;
using Siteware.Prototipo.Web.ViewModels.Produtos;
using Siteware.Prototipo.Repositorios;
using Siteware.Prototipo.Repositorio.Entity;
using Siteware.Prototipo.Repositorios.Entity;
using Siteware.Prototipo.Web.ViewModels.Promocao;

namespace Siteware.Prototipo.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private IRepositorioCRUD<Produto, int> db = new ProdutoRepositorio(new PrototipoDbContext());
        private IRepositorioCRUD<Promocao, int> dbPromocao = new PromocaoRepositorio(new PrototipoDbContext());

        // GET: Produtos
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Produto>, List<ProdutoShowViewModel>>(db.Selecionar()));
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.SelecionarPorId(id.Value);

            ProdutoShowViewModel viewModel = Mapper.Map<Produto, ProdutoShowViewModel>(produto);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            PromocaoShowViewModel promo = new PromocaoShowViewModel { Nome = "Selecione uma Promoção" };
            List<PromocaoShowViewModel> lstPromocoes = Mapper.Map<List<Promocao>, List<PromocaoShowViewModel>>(dbPromocao.Selecionar());
            lstPromocoes.Insert(0,promo);
            SelectList ddPromocoes = new SelectList(lstPromocoes, "Id", "Nome");
            ViewBag.ddPromocoes = ddPromocoes;
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Preco,IdPromocao")] ProdutoValidationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Produto produto = Mapper.Map<ProdutoValidationViewModel, Produto>(viewModel);
                produto.IdPromocao = produto.IdPromocao == 0 ? null : produto.IdPromocao;
                db.Inserir(produto);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.SelecionarPorId(id.Value);
            PromocaoShowViewModel promo = new PromocaoShowViewModel { Nome = "Selecione uma Promoção" };
            List<PromocaoShowViewModel> lstPromocoes = Mapper.Map<List<Promocao>, List<PromocaoShowViewModel>>(dbPromocao.Selecionar());
            lstPromocoes.Insert(0, promo);
            SelectList ddPromocoes = new SelectList(lstPromocoes, "Id", "Nome");
            ViewBag.ddPromocoes = ddPromocoes;

            ProdutoValidationViewModel viewModel = Mapper.Map<Produto, ProdutoValidationViewModel>(produto);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preco,IdPromocao")] ProdutoValidationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Produto produto = Mapper.Map<ProdutoValidationViewModel, Produto>(viewModel);
                db.Alterar(produto);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.SelecionarPorId(id.Value);
            ProdutoShowViewModel viewModel = Mapper.Map<Produto, ProdutoShowViewModel>(produto);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.ExcluirPorId(id);
            return RedirectToAction("Index");
        }
    }
}
