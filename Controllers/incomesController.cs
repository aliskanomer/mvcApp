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
    public class incomesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: incomes
        public ActionResult Index()
        {
            var incomes = db.Incomes.OrderByDescending(i => i.incomeDate);
            return View(db.Incomes.ToList());
        }
        // GET: incomes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: incomes/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,incomeName,incomeAmount")] incomes incomes)
        {
            if (ModelState.IsValid)
            {
                incomes.incomeDate = DateTime.Now;
                db.Incomes.Add(incomes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incomes);
        }

        // GET: incomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incomes incomes = db.Incomes.Find(id);
            if (incomes == null)
            {
                return HttpNotFound();
            }
            return View(incomes);
        }

        // POST: incomes/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,incomeName,incomeAmount")] incomes incomes)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Incomes.Find(incomes.Id);
                if(entity != null)
                {
                    entity.incomeName = incomes.incomeName;
                    entity.incomeAmount = incomes.incomeAmount;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                //db.Entry(incomes).State = EntityState.Modified;
            }
            return View(incomes);
        }

        // GET: incomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incomes incomes = db.Incomes.Find(id);
            if (incomes == null)
            {
                return HttpNotFound();
            }
            return View(incomes);
        }

        // POST: incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            incomes incomes = db.Incomes.Find(id);
            db.Incomes.Remove(incomes);
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
