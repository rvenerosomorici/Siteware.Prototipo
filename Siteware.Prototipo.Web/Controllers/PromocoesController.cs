using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Siteware.Prototipo.Dominio;
using AutoMapper;
using Siteware.Prototipo.Web.ViewModels.Promocao;
using Siteware.Prototipo.Repositorios.Entity;
using Siteware.Prototipo.Repositorios;
using Siteware.Prototipo.DAL.Entity.Context;

namespace Siteware.Prototipo.Web.Controllers
{
    public class PromocoesController : Controller
    {
        private IRepositorioCRUD<Promocao, int> db = new PromocaoRepositorio(new PrototipoDbContext());

        // GET: Promocoes
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Promocao>,List<PromocaoShowViewModel>>(db.Selecionar()));
        }

        // GET: Promocoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.SelecionarPorId(id.Value);

            PromocaoShowViewModel viewModel = Mapper.Map<Promocao, PromocaoShowViewModel>(promocao);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Promocoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promocoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Tipo,BasePropriedade,BaseTipo,BaseValor,ResultadoPropriedade,ResultadoTipo,ResultadoValor")] PromocaoValidationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Promocao promocao = Mapper.Map<PromocaoValidationViewModel, Promocao>(viewModel);
                db.Inserir(promocao);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Promocoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.SelecionarPorId(id.Value);

            PromocaoValidationViewModel viewModel = Mapper.Map<Promocao, PromocaoValidationViewModel>(promocao);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Promocoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Tipo,BasePropriedade,BaseTipo,BaseValor,ResultadoPropriedade,ResultadoTipo,ResultadoValor")] PromocaoValidationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Promocao promocao = Mapper.Map<PromocaoValidationViewModel, Promocao>(viewModel);
                db.Alterar(promocao);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Promocoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.SelecionarPorId(id.Value);

            PromocaoShowViewModel viewModel = Mapper.Map<Promocao, PromocaoShowViewModel>(promocao);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Promocoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.ExcluirPorId(id);
            return RedirectToAction("Index");
        }
    }
}
