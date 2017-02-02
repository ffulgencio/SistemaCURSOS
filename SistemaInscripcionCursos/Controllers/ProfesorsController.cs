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
    public class ProfesorsController : Controller
    {
        private ContextoDB db = new ContextoDB();

        // GET: Profesors
        public ActionResult Index()
        {
            var profesores = db.Profesores.Include(p => p.Carrera).Include(p => p.Universidad);
            return View(profesores.ToList());
        }

        // GET: Profesors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesor profesor = db.Profesores.Find(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        // GET: Profesors/Create
        public ActionResult Create()
        {
            ViewBag.CarreraId = new SelectList(db.Carreras, "Id", "Nombre");
            ViewBag.UniversidadID = new SelectList(db.Universidades, "Id", "Nombre");
            return View();
        }

        // POST: Profesors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,UniversidadID,CarreraId,Email,Telefono,Celular")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                db.Profesores.Add(profesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarreraId = new SelectList(db.Carreras, "Id", "Nombre", profesor.CarreraId);
            ViewBag.UniversidadID = new SelectList(db.Universidades, "Id", "Nombre", profesor.UniversidadID);
            return View(profesor);
        }

        // GET: Profesors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesor profesor = db.Profesores.Find(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarreraId = new SelectList(db.Carreras, "Id", "Nombre", profesor.CarreraId);
            ViewBag.UniversidadID = new SelectList(db.Universidades, "Id", "Nombre", profesor.UniversidadID);
            return View(profesor);
        }

        // POST: Profesors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,UniversidadID,CarreraId,Email,Telefono,Celular")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarreraId = new SelectList(db.Carreras, "Id", "Nombre", profesor.CarreraId);
            ViewBag.UniversidadID = new SelectList(db.Universidades, "Id", "Nombre", profesor.UniversidadID);
            return View(profesor);
        }

        // GET: Profesors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesor profesor = db.Profesores.Find(id);
            if (profesor == null)
            {
                return HttpNotFound();
            }
            return View(profesor);
        }

        // POST: Profesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesor profesor = db.Profesores.Find(id);
            db.Profesores.Remove(profesor);
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
