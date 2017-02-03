using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaInscripcionCursos.Models.ModeloCursos;
using SistemaInscripcionCursos.Models;

namespace SistemaInscripcionCursos.Controllers
{
    public class EstudiantesController : Controller
    {
        private ContextoDB db = new ContextoDB();

        // GET: Estudiantes
        public ActionResult Index()
        {
            var estudiantes = db.Estudiantes.Include(e => e.Carrera).Include(e => e.Universidad);
            return View(estudiantes.ToList());
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {

            var lista = db.Carreras.ToList();
            lista.Add(new Carrera {Id =  0, Nombre ="[Seleccione una carrera]"});
            

            ViewBag.CarreraId = new SelectList(lista.OrderBy(c => c.Nombre), "Id", "Nombre");
            ViewBag.UniversidadID = new SelectList(db.Universidades.OrderBy(u => u.Nombre), "Id", "Nombre");
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,UniversidadID,CarreraId,Email,Telefono,Celular")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Estudiantes.Add(estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarreraId = new SelectList(db.Carreras, "Id", "Nombre", estudiante.CarreraId);
            ViewBag.UniversidadID = new SelectList(db.Universidades, "Id", "Nombre", estudiante.UniversidadID);
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarreraId = new SelectList(db.Carreras, "Id", "Nombre", estudiante.CarreraId);
            ViewBag.UniversidadID = new SelectList(db.Universidades, "Id", "Nombre", estudiante.UniversidadID);
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,UniversidadID,CarreraId,Email,Telefono,Celular")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarreraId = new SelectList(db.Carreras, "Id", "Nombre", estudiante.CarreraId);
            ViewBag.UniversidadID = new SelectList(db.Universidades, "Id", "Nombre", estudiante.UniversidadID);
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudiante estudiante = db.Estudiantes.Find(id);
            db.Estudiantes.Remove(estudiante);
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

        public ActionResult InscribirCurso()
        {
            return View();
        }
    }
}
