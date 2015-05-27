using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SanRafael.Models;

namespace SanRafael.Controllers
{
    public class DocentesController : Controller
    {
        private SanRafaelContextDB db = new SanRafaelContextDB();

        // GET: Docentes
        public ActionResult Index()
        {
            return View(db.Docentes.ToList());
        }

        // GET: Docentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // GET: Docentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Docentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rut_docente,nombres,apellidos,telefono,telefono2,direccion,especialidad,contrasena")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                if(db.Docentes.Find(docente.rut_docente) == null)
                {
                    docente.estado_eliminado = false;
                    db.Docentes.Add(docente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["docenteExiste"] = "El rut ingresado ya existe";
                }
                
            }

            return View(docente);
        }

        // GET: Docentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: Docentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rut_docente,nombres,apellidos,telefono,telefono2,direccion,especialidad,contrasena")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docente);
        }

        // GET: Docentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Docente docente = db.Docentes.Find(id);
            db.Docentes.Attach(docente);
            docente.estado_eliminado = true;
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
