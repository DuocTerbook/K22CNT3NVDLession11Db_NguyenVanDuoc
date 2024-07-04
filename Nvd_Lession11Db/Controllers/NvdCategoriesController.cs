using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nvd_Lession11Db.Models;

namespace Nvd_Lession11Db.Controllers
{
    public class NvdCategoriesController : Controller
    {
        private K22CNT3_lession11DbEntities db = new K22CNT3_lession11DbEntities();

        // GET: NvdCategories
        public ActionResult NvdIndex()
        {
            return View(db.NvdCategories.ToList());
        }

        // GET: NvdCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvdCategory nvdCategory = db.NvdCategories.Find(id);
            if (nvdCategory == null)
            {
                return HttpNotFound();
            }
            return View(nvdCategory);
        }

        // GET: NvdCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NvdCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NvdCateID,NvdCateName,NvdStatus")] NvdCategory nvdCategory)
        {
            if (ModelState.IsValid)
            {
                db.NvdCategories.Add(nvdCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nvdCategory);
        }

        // GET: NvdCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvdCategory nvdCategory = db.NvdCategories.Find(id);
            if (nvdCategory == null)
            {
                return HttpNotFound();
            }
            return View(nvdCategory);
        }

        // POST: NvdCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NvdCateID,NvdCateName,NvdStatus")] NvdCategory nvdCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nvdCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nvdCategory);
        }

        // GET: NvdCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvdCategory nvdCategory = db.NvdCategories.Find(id);
            if (nvdCategory == null)
            {
                return HttpNotFound();
            }
            return View(nvdCategory);
        }

        // POST: NvdCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NvdCategory nvdCategory = db.NvdCategories.Find(id);
            db.NvdCategories.Remove(nvdCategory);
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
