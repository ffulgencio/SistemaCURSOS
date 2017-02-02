using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaInscripcionCursos.Models;
using SistemaInscripcionCursos.Models.ModeloCursos;

namespace SistemaInscripcionCursos.Controllers
{
    public class UniversidadsController : Controller
    {
        private ContextoDB db = new ContextoDB();

        // GET: Universidads
        public ActionResult Index()
        {
            return View(db.Universidades.ToList());
        }

        // GET: Universidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidad universidad = db.Universidades.Find(id);
            if (universidad == null)
            {
                return HttpNotFound();
            }
            return View(universidad);
        }

        // GET: Universidads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universidads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Universidad universidad)
        {
            if (ModelState.IsValid)
            {
                db.Universidades.Add(universidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universidad);
        }

        // GET: Universidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidad universidad = db.Universidades.Find(id);
            if (universidad == null)
            {
                return HttpNotFound();
            }
            return View(universidad);
        }

        // POST: Universidads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Universidad universidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universidad);
        }

        // GET: Universidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidad universidad = db.Universidades.Find(id);
            if (universidad == null)
            {
                return HttpNotFound();
            }
            return View(universidad);
        }

        // POST: Universidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Universidad universidad = db.Universidades.Find(id);
            db.Universidades.Remove(universidad);
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
