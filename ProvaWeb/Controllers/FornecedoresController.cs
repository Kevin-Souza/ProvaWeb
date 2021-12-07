using ProvaWeb.Context;
using ProvaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProvaWeb.Controllers
{
    public class FornecedoresController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Fornecedores
        public ActionResult Index()
        {
            return View(context.fornecedores.OrderBy(p => p.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fornecedor fornecedor)
        {
            context.fornecedores.Add(fornecedor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = context.fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fornecedor).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = context.fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = context.fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fornecedor fornecedor = context.fornecedores.Find(id);
            context.fornecedores.Remove(fornecedor);
            context.SaveChanges();
            TempData["Message"] = "Fornecedor" + fornecedor.Nome.ToUpper() + "foi removido";
            return RedirectToAction("index");
        }
    }
}