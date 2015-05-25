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
    public class Tipo_Doc_AsignaturaController : Controller
    {
        private SanRafaelContextDB db = new SanRafaelContextDB();

        // GET: Tipo_Doc_Asignatura
        public ActionResult Index()
        {
            return View(db.Tipo_Doc_Asignatura.ToList());
        }

        // GET: Tipo_Doc_Asignatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Doc_Asignatura tipo_Doc_Asignatura = db.Tipo_Doc_Asignatura.Find(id);
            if (tipo_Doc_Asignatura == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Doc_Asignatura);
        }

        // GET: Tipo_Doc_Asignatura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Doc_Asignatura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre")] Tipo_Doc_Asignatura tipo_Doc_Asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Doc_Asignatura.Add(tipo_Doc_Asignatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Doc_Asignatura);
        }

        // GET: Tipo_Doc_Asignatura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Doc_Asignatura tipo_Doc_Asignatura = db.Tipo_Doc_Asignatura.Find(id);
            if (tipo_Doc_Asignatura == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Doc_Asignatura);
        }

        // POST: Tipo_Doc_Asignatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_doc_asignatura,nombre")] Tipo_Doc_Asignatura tipo_Doc_Asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Doc_Asignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Doc_Asignatura);
        }

        // GET: Tipo_Doc_Asignatura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Doc_Asignatura tipo_Doc_Asignatura = db.Tipo_Doc_Asignatura.Find(id);
            if (tipo_Doc_Asignatura == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Doc_Asignatura);
        }

        // POST: Tipo_Doc_Asignatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Doc_Asignatura tipo_Doc_Asignatura = db.Tipo_Doc_Asignatura.Find(id);
            db.Tipo_Doc_Asignatura.Remove(tipo_Doc_Asignatura);
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
