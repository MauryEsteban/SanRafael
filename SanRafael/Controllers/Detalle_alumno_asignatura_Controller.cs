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
    public class Detalle_alumno_asignatura_Controller : Controller
    {
        private SanRafaelContextDB db = new SanRafaelContextDB();

        // GET: Detalle_alumno_asignatura_
        public ActionResult Index()
        {
            var detalle_alumno_asignatura_ = db.Detalle_alumno_asignatura_.Include(d => d.Alumno).Include(d => d.Anio_Semestre).Include(d => d.Asignatura);
            return View(detalle_alumno_asignatura_.ToList());
        }

        // GET: Detalle_alumno_asignatura_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_alumno_asignatura_ detalle_alumno_asignatura_ = db.Detalle_alumno_asignatura_.Find(id);
            if (detalle_alumno_asignatura_ == null)
            {
                return HttpNotFound();
            }
            return View(detalle_alumno_asignatura_);
        }

        // GET: Detalle_alumno_asignatura_/Create
        public ActionResult Create()
        {
            ViewBag.rut_alumno_fk = new SelectList(db.Alumnoes, "rut_alumno", "nombres");
            ViewBag.id_anio_semestre_fk = new SelectList(db.Anio_Semestre, "id_anio_semestre", "id_anio_semestre");
            ViewBag.id_asignatura_fk = new SelectList(db.Asignaturas, "id_asignatura", "nombre_asignatura");
            return View();
        }

        // POST: Detalle_alumno_asignatura_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_dellate_alumno_asignatura,fecha_inicio,fecha_termino,rut_alumno_fk,id_asignatura_fk,id_anio_semestre_fk")] Detalle_alumno_asignatura_ detalle_alumno_asignatura_)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_alumno_asignatura_.Add(detalle_alumno_asignatura_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rut_alumno_fk = new SelectList(db.Alumnoes, "rut_alumno", "nombres", detalle_alumno_asignatura_.rut_alumno_fk);
            ViewBag.id_anio_semestre_fk = new SelectList(db.Anio_Semestre, "id_anio_semestre", "id_anio_semestre", detalle_alumno_asignatura_.id_anio_semestre_fk);
            ViewBag.id_asignatura_fk = new SelectList(db.Asignaturas, "id_asignatura", "nombre_asignatura", detalle_alumno_asignatura_.id_asignatura_fk);
            return View(detalle_alumno_asignatura_);
        }

        // GET: Detalle_alumno_asignatura_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_alumno_asignatura_ detalle_alumno_asignatura_ = db.Detalle_alumno_asignatura_.Find(id);
            if (detalle_alumno_asignatura_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.rut_alumno_fk = new SelectList(db.Alumnoes, "rut_alumno", "nombres", detalle_alumno_asignatura_.rut_alumno_fk);
            ViewBag.id_anio_semestre_fk = new SelectList(db.Anio_Semestre, "id_anio_semestre", "id_anio_semestre", detalle_alumno_asignatura_.id_anio_semestre_fk);
            ViewBag.id_asignatura_fk = new SelectList(db.Asignaturas, "id_asignatura", "nombre_asignatura", detalle_alumno_asignatura_.id_asignatura_fk);
            return View(detalle_alumno_asignatura_);
        }

        // POST: Detalle_alumno_asignatura_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_dellate_alumno_asignatura,fecha_inicio,fecha_termino,rut_alumno_fk,id_asignatura_fk,id_anio_semestre_fk")] Detalle_alumno_asignatura_ detalle_alumno_asignatura_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_alumno_asignatura_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rut_alumno_fk = new SelectList(db.Alumnoes, "rut_alumno", "nombres", detalle_alumno_asignatura_.rut_alumno_fk);
            ViewBag.id_anio_semestre_fk = new SelectList(db.Anio_Semestre, "id_anio_semestre", "id_anio_semestre", detalle_alumno_asignatura_.id_anio_semestre_fk);
            ViewBag.id_asignatura_fk = new SelectList(db.Asignaturas, "id_asignatura", "nombre_asignatura", detalle_alumno_asignatura_.id_asignatura_fk);
            return View(detalle_alumno_asignatura_);
        }

        // GET: Detalle_alumno_asignatura_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_alumno_asignatura_ detalle_alumno_asignatura_ = db.Detalle_alumno_asignatura_.Find(id);
            if (detalle_alumno_asignatura_ == null)
            {
                return HttpNotFound();
            }
            return View(detalle_alumno_asignatura_);
        }

        // POST: Detalle_alumno_asignatura_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_alumno_asignatura_ detalle_alumno_asignatura_ = db.Detalle_alumno_asignatura_.Find(id);
            db.Detalle_alumno_asignatura_.Remove(detalle_alumno_asignatura_);
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
