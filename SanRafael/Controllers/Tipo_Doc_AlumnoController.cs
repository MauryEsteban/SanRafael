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
    public class Tipo_Doc_AlumnoController : Controller
    {
        private SanRafaelContextDB db = new SanRafaelContextDB();

        // GET: Tipo_Doc_Alumno
        public ActionResult Index()
        {
            return View(db.Tipo_Doc_Alumno.ToList());
        }

        // GET: Tipo_Doc_Alumno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Doc_Alumno tipo_Doc_Alumno = db.Tipo_Doc_Alumno.Find(id);
            if (tipo_Doc_Alumno == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Doc_Alumno);
        }

        // GET: Tipo_Doc_Alumno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Doc_Alumno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre")] Tipo_Doc_Alumno tipo_Doc_Alumno)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Doc_Alumno.Add(tipo_Doc_Alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Doc_Alumno);
        }

        // GET: Tipo_Doc_Alumno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Doc_Alumno tipo_Doc_Alumno = db.Tipo_Doc_Alumno.Find(id);
            if (tipo_Doc_Alumno == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Doc_Alumno);
        }

        // POST: Tipo_Doc_Alumno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_doc_alumno,nombre")] Tipo_Doc_Alumno tipo_Doc_Alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Doc_Alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Doc_Alumno);
        }

        // GET: Tipo_Doc_Alumno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Doc_Alumno tipo_Doc_Alumno = db.Tipo_Doc_Alumno.Find(id);
            if (tipo_Doc_Alumno == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Doc_Alumno);
        }

        // POST: Tipo_Doc_Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Doc_Alumno tipo_Doc_Alumno = db.Tipo_Doc_Alumno.Find(id);
            db.Tipo_Doc_Alumno.Remove(tipo_Doc_Alumno);
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
