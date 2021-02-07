using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using myBudget.Entity;

namespace myBudget.Controllers
{
    public class expencesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: expences
        public ActionResult Index()
        {
            var expences = db.Expences.OrderByDescending(i => i.expenceDate);
            return View(expences.ToList());
        }

        // GET: expences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: expences/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,expenceName,expenceAmount")] expences expences)
        {
            if (ModelState.IsValid)
            {
                expences.expenceDate = DateTime.Now;
                db.Expences.Add(expences);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expences);
        }

        // GET: expences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expences expences = db.Expences.Find(id);
            if (expences == null)
            {
                return HttpNotFound();
            }
            return View(expences);
        }

        // POST: expences/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,expenceName,expenceAmount,expenceDate")] expences expences)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Expences.Find(expences.Id);
                if (entity != null)
                {
                    entity.expenceName = expences.expenceName;
                    entity.expenceAmount = expences.expenceAmount;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(expences);
        }

        // GET: expences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expences expences = db.Expences.Find(id);
            if (expences == null)
            {
                return HttpNotFound();
            }
            return View(expences);
        }

        // POST: expences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            expences expences = db.Expences.Find(id);
            db.Expences.Remove(expences);
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
