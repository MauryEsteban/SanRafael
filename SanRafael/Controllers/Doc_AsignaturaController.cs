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
    public class Doc_AsignaturaController : Controller
    {
        private SanRafaelContextDB db = new SanRafaelContextDB();

        // GET: Doc_Asignatura
        public ActionResult Index()
        {
            var doc_Asignatura = db.Doc_Asignatura.Include(d => d.Asignatura).Include(d => d.Tipo_Doc_Asignatura);
            return View(doc_Asignatura.ToList());
        }

        // GET: Doc_Asignatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doc_Asignatura doc_Asignatura = db.Doc_Asignatura.Find(id);
            if (doc_Asignatura == null)
            {
                return HttpNotFound();
            }
            return View(doc_Asignatura);
        }

        // GET: Doc_Asignatura/Create
        public ActionResult Create()
        {
            ViewBag.id_asignatura_fk = new SelectList(db.Asignaturas, "id_asignatura", "nombre_asignatura");
            ViewBag.id_tipo_doc_asignatura_fk = new SelectList(db.Tipo_Doc_Asignatura, "id_tipo_doc_asignatura", "nombre");
            return View();
        }

        // POST: Doc_Asignatura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_doc_asignatura,fecha,observacion,path,estado_eliminado,id_asignatura_fk,id_tipo_doc_asignatura_fk")] Doc_Asignatura doc_Asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Doc_Asignatura.Add(doc_Asignatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_asignatura_fk = new SelectList(db.Asignaturas, "id_asignatura", "nombre_asignatura", doc_Asignatura.id_asignatura_fk);
            ViewBag.id_tipo_doc_asignatura_fk = new SelectList(db.Tipo_Doc_Asignatura, "id_tipo_doc_asignatura", "nombre", doc_Asignatura.id_tipo_doc_asignatura_fk);
            return View(doc_Asignatura);
        }

        // GET: Doc_Asignatura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doc_Asignatura doc_Asignatura = db.Doc_Asignatura.Find(id);
            if (doc_Asignatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_asignatura_fk = new SelectList(db.Asignaturas, "id_asignatura", "nombre_asignatura", doc_Asignatura.id_asignatura_fk);
            ViewBag.id_tipo_doc_asignatura_fk = new SelectList(db.Tipo_Doc_Asignatura, "id_tipo_doc_asignatura", "nombre", doc_Asignatura.id_tipo_doc_asignatura_fk);
            return View(doc_Asignatura);
        }

        // POST: Doc_Asignatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_doc_asignatura,fecha,observacion,path,estado_eliminado,id_asignatura_fk,id_tipo_doc_asignatura_fk")] Doc_Asignatura doc_Asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doc_Asignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_asignatura_fk = new SelectList(db.Asignaturas, "id_asignatura", "nombre_asignatura", doc_Asignatura.id_asignatura_fk);
            ViewBag.id_tipo_doc_asignatura_fk = new SelectList(db.Tipo_Doc_Asignatura, "id_tipo_doc_asignatura", "nombre", doc_Asignatura.id_tipo_doc_asignatura_fk);
            return View(doc_Asignatura);
        }

        // GET: Doc_Asignatura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doc_Asignatura doc_Asignatura = db.Doc_Asignatura.Find(id);
            if (doc_Asignatura == null)
            {
                return HttpNotFound();
            }
            return View(doc_Asignatura);
        }

        // POST: Doc_Asignatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doc_Asignatura doc_Asignatura = db.Doc_Asignatura.Find(id);
            db.Doc_Asignatura.Remove(doc_Asignatura);
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
