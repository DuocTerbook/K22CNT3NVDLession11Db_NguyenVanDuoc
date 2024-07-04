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
    public class NvdProductsController : Controller
    {
        private K22CNT3_lession11DbEntities db = new K22CNT3_lession11DbEntities();

        // GET: NvdProducts
        public ActionResult NvdIndex()
        {
            var nvdProducts = db.NvdProducts.Include(n => n.NvdCategory);
            return View(nvdProducts.ToList());
        }

        // GET: NvdProducts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvdProduct nvdProduct = db.NvdProducts.Find(id);
            if (nvdProduct == null)
            {
                return HttpNotFound();
            }
            return View(nvdProduct);
        }

        // GET: NvdProducts/Create
        public ActionResult Create()
        {
            ViewBag.NvdCateID = new SelectList(db.NvdCategories, "NvdCateID", "NvdCateName");
            return View();
        }

        // POST: NvdProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NvdID2210900016,NvdProName,NvdQty,NvdPrice,NvdCateID,NvdActive")] NvdProduct nvdProduct)
        {
            if (ModelState.IsValid)
            {
                db.NvdProducts.Add(nvdProduct);
                db.SaveChanges();
                return RedirectToAction("NvdIndex");
            }

            ViewBag.NvdCateID = new SelectList(db.NvdCategories, "NvdCateID", "NvdCateName", nvdProduct.NvdCateID);
            return View(nvdProduct);
        }

        // GET: NvdProducts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvdProduct nvdProduct = db.NvdProducts.Find(id);
            if (nvdProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.NvdCateID = new SelectList(db.NvdCategories, "NvdCateID", "NvdCateName", nvdProduct.NvdCateID);
            return View(nvdProduct);
        }

        // POST: NvdProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NvdID2210900016,NvdProName,NvdQty,NvdPrice,NvdCateID,NvdActive")] NvdProduct nvdProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nvdProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NvdIndex");
            }
            ViewBag.NvdCateID = new SelectList(db.NvdCategories, "NvdCateID", "NvdCateName", nvdProduct.NvdCateID);
            return View(nvdProduct);
        }

        // GET: NvdProducts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvdProduct nvdProduct = db.NvdProducts.Find(id);
            if (nvdProduct == null)
            {
                return HttpNotFound();
            }
            return View(nvdProduct);
        }

        // POST: NvdProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NvdProduct nvdProduct = db.NvdProducts.Find(id);
            db.NvdProducts.Remove(nvdProduct);
            db.SaveChanges();
            return RedirectToAction("NvdIndex");
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
