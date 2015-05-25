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
    public class Anio_SemestreController : Controller
    {
        private SanRafaelContextDB db = new SanRafaelContextDB();

        // GET: Anio_Semestre
        public ActionResult Index()
        {
            return View(db.Anio_Semestre.ToList());
        }

        // GET: Anio_Semestre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anio_Semestre anio_Semestre = db.Anio_Semestre.Find(id);
            if (anio_Semestre == null)
            {
                return HttpNotFound();
            }
            return View(anio_Semestre);
        }

        // GET: Anio_Semestre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anio_Semestre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "anio,semestre")] Anio_Semestre anio_Semestre)
        {
            if (ModelState.IsValid)
            {
                db.Anio_Semestre.Add(anio_Semestre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anio_Semestre);
        }

        // GET: Anio_Semestre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anio_Semestre anio_Semestre = db.Anio_Semestre.Find(id);
            if (anio_Semestre == null)
            {
                return HttpNotFound();
            }
            return View(anio_Semestre);
        }

        // POST: Anio_Semestre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_anio_semestre,anio,semestre")] Anio_Semestre anio_Semestre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anio_Semestre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anio_Semestre);
        }

        // GET: Anio_Semestre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anio_Semestre anio_Semestre = db.Anio_Semestre.Find(id);
            if (anio_Semestre == null)
            {
                return HttpNotFound();
            }
            return View(anio_Semestre);
        }

        // POST: Anio_Semestre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anio_Semestre anio_Semestre = db.Anio_Semestre.Find(id);
            db.Anio_Semestre.Remove(anio_Semestre);
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
