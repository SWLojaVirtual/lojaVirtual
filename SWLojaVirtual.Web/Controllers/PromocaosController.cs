using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SWLojaVirtual.Dominio.Entidades;
using SWLojaVirtual.Dominio.Repositório;

namespace SWLojaVirtual.Web.Controllers
{
    public class PromocaosController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Promocaos
        public ActionResult Index()
        {
            return View(db.Promocoes.ToList());
        }

        // GET: Promocaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.Promocoes.Find(id);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(promocao);
        }

        // GET: Promocaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promocaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPromocao,Descricao,Leve, Pague")] Promocao promocao)
        {
            if (ModelState.IsValid)
            {
                db.Promocoes.Add(promocao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promocao);
        }

        // GET: Promocaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.Promocoes.Find(id);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(promocao);
        }

        // POST: Promocaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPromocao,Descricao,Leve, Pague")] Promocao promocao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promocao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promocao);
        }

        // GET: Promocaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocao promocao = db.Promocoes.Find(id);
            if (promocao == null)
            {
                return HttpNotFound();
            }
            return View(promocao);
        }

        // POST: Promocaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promocao promocao = db.Promocoes.Find(id);
            db.Promocoes.Remove(promocao);
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
