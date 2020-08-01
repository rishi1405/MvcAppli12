using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAppli12.Models;

namespace MvcAppli12.Controllers
{
    public class HomeController : Controller
    {
        private hdfcDBContext db = new hdfcDBContext();

        //
        // GET: /Home/

        //[OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            //System.Threading.Thread.Sleep(3000);
            return View(db.Emploes.ToList());
        }

        [ChildActionOnly]
        [OutputCache(Duration = 10)]
        public string GetEmployeeCount()
        {
            return "Employee Count = " + db.Emploes.Count().ToString() + "@ " + DateTime.Now.ToString();
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Emplo emplo = db.Emploes.Find(id);
            if (emplo == null)
            {
                return HttpNotFound();
            }
            return View(emplo);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Emplo emplo)
        {
            if (ModelState.IsValid)
            {
                db.Emploes.Add(emplo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emplo);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Emplo emplo = db.Emploes.Find(id);
            if (emplo == null)
            {
                return HttpNotFound();
            }
            return View(emplo);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Emplo emplo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emplo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emplo);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Emplo emplo = db.Emploes.Find(id);
            if (emplo == null)
            {
                return HttpNotFound();
            }
            return View(emplo);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Emplo emplo = db.Emploes.Find(id);
            db.Emploes.Remove(emplo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}