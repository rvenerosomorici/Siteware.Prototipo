﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Siteware.Prototipo.Dominio;
using Siteware.Prototipo.DAL.Entity.Context;
using AutoMapper;
using Siteware.Prototipo.Web.ViewModels.Produtos;

namespace Siteware.Prototipo.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private PrototipoDbContext db = new PrototipoDbContext();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Produto>, List<ProdutoShowViewModel>>(db.Produtos.ToList()));
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);

            ProdutoShowViewModel viewModel = Mapper.Map<Produto, ProdutoShowViewModel>(produto);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
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
                db.Produtos.Add(produto);
                db.SaveChanges();
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
            Produto produto = db.Produtos.Find(id);

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
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
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
            Produto produto = db.Produtos.Find(id);
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
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
