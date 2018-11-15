using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace CimArk.Controllers
{
    public class PowerplantsController : Controller
    {
        private CimArkDevEntities db = new CimArkDevEntities();

        // GET: Powerplants
        public ActionResult Index()
        {
            var powerplants = db.Powerplants.Include(p => p.PowerType);
            return View(powerplants.ToList());
        }

        // GET: Powerplants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Powerplant powerplant = db.Powerplants.Find(id);
            if (powerplant == null)
            {
                return HttpNotFound();
            }
            return View(powerplant);
        }

        // GET: Powerplants/Create
        public ActionResult Create()
        {
            ViewBag.PowerTypeId = new SelectList(db.PowerTypes, "Id", "Name");
            return View();
        }

        // POST: Powerplants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,No_RPC,Power,PowerAvgYear,Launch,PostalCode,Streetname,Streetnumber,GPS_X,GPS_Y,PowerTypeId,City")] Powerplant powerplant)
        {
            if (ModelState.IsValid)
            {
                db.Powerplants.Add(powerplant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PowerTypeId = new SelectList(db.PowerTypes, "Id", "Name", powerplant.PowerTypeId);
            return View(powerplant);
        }

        // GET: Powerplants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Powerplant powerplant = db.Powerplants.Find(id);
            if (powerplant == null)
            {
                return HttpNotFound();
            }
            ViewBag.PowerTypeId = new SelectList(db.PowerTypes, "Id", "Name", powerplant.PowerTypeId);
            return View(powerplant);
        }

        // POST: Powerplants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,No_RPC,Power,PowerAvgYear,Launch,PostalCode,Streetname,Streetnumber,GPS_X,GPS_Y,PowerTypeId,City")] Powerplant powerplant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(powerplant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PowerTypeId = new SelectList(db.PowerTypes, "Id", "Name", powerplant.PowerTypeId);
            return View(powerplant);
        }

        // GET: Powerplants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Powerplant powerplant = db.Powerplants.Find(id);
            if (powerplant == null)
            {
                return HttpNotFound();
            }
            return View(powerplant);
        }

        // POST: Powerplants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Powerplant powerplant = db.Powerplants.Find(id);
            db.Powerplants.Remove(powerplant);
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
