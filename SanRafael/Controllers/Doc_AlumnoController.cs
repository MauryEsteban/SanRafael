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
    public class Doc_AlumnoController : Controller
    {
        private SanRafaelContextDB db = new SanRafaelContextDB();

        // GET: Doc_Alumno
        public ActionResult Index()
        {
            var doc_Alumno = db.Doc_Alumno.Include(d => d.Alumno).Include(d => d.Tipo_Doc_Alumno);
            return View(doc_Alumno.ToList());
        }

        // GET: Doc_Alumno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doc_Alumno doc_Alumno = db.Doc_Alumno.Find(id);
            if (doc_Alumno == null)
            {
                return HttpNotFound();
            }
            return View(doc_Alumno);
        }

        // GET: Doc_Alumno/Create
        public ActionResult Create()
        {
            ViewBag.rut_alumno_fk = new SelectList(db.Alumnoes, "rut_alumno", "nombres");
            ViewBag.id_tipo_doc_alumno_fk = new SelectList(db.Tipo_Doc_Alumno, "id_tipo_doc_alumno", "nombre");
            return View();
        }

        // POST: Doc_Alumno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_doc_alumno,fecha,observacion,path,estado_eliminado,rut_alumno_fk,id_tipo_doc_alumno_fk")] Doc_Alumno doc_Alumno)
        {
            if (ModelState.IsValid)
            {
                db.Doc_Alumno.Add(doc_Alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rut_alumno_fk = new SelectList(db.Alumnoes, "rut_alumno", "nombres", doc_Alumno.rut_alumno_fk);
            ViewBag.id_tipo_doc_alumno_fk = new SelectList(db.Tipo_Doc_Alumno, "id_tipo_doc_alumno", "nombre", doc_Alumno.id_tipo_doc_alumno_fk);
            return View(doc_Alumno);
        }

        // GET: Doc_Alumno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doc_Alumno doc_Alumno = db.Doc_Alumno.Find(id);
            if (doc_Alumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.rut_alumno_fk = new SelectList(db.Alumnoes, "rut_alumno", "nombres", doc_Alumno.rut_alumno_fk);
            ViewBag.id_tipo_doc_alumno_fk = new SelectList(db.Tipo_Doc_Alumno, "id_tipo_doc_alumno", "nombre", doc_Alumno.id_tipo_doc_alumno_fk);
            return View(doc_Alumno);
        }

        // POST: Doc_Alumno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_doc_alumno,fecha,observacion,path,estado_eliminado,rut_alumno_fk,id_tipo_doc_alumno_fk")] Doc_Alumno doc_Alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doc_Alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rut_alumno_fk = new SelectList(db.Alumnoes, "rut_alumno", "nombres", doc_Alumno.rut_alumno_fk);
            ViewBag.id_tipo_doc_alumno_fk = new SelectList(db.Tipo_Doc_Alumno, "id_tipo_doc_alumno", "nombre", doc_Alumno.id_tipo_doc_alumno_fk);
            return View(doc_Alumno);
        }

        // GET: Doc_Alumno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doc_Alumno doc_Alumno = db.Doc_Alumno.Find(id);
            if (doc_Alumno == null)
            {
                return HttpNotFound();
            }
            return View(doc_Alumno);
        }

        // POST: Doc_Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doc_Alumno doc_Alumno = db.Doc_Alumno.Find(id);
            db.Doc_Alumno.Remove(doc_Alumno);
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
