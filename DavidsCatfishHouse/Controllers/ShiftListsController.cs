using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DavidsCatfishHouse.Models;

namespace DavidsCatfishHouse.Controllers
{
    public class ShiftListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShiftLists
        [Authorize]
        public ActionResult Index()
        {

            //TuesdayShiftList.TenToTwo.GetDisplayName();
            return View(db.ShiftLists.ToList());
        }

        // GET: ShiftLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftList shiftList = db.ShiftLists.Find(id);
            if (shiftList == null)
            {
                return HttpNotFound();
            }
            return View(shiftList);
        }

        // GET: ShiftLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShiftLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TuesdayShift,WednesdayShift,ThursdayShift,FridayShift,SaturdayShift")] ShiftList shiftList)
        {
            if (ModelState.IsValid)
            {
                db.ShiftLists.Add(shiftList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shiftList);
        }

        // GET: ShiftLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftList shiftList = db.ShiftLists.Find(id);
            if (shiftList == null)
            {
                return HttpNotFound();
            }
            return View(shiftList);
        }

        // POST: ShiftLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TuesdayShift,WednesdayShift,ThursdayShift,FridayShift,SaturdayShift")] ShiftList shiftList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shiftList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shiftList);
        }

        // GET: ShiftLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftList shiftList = db.ShiftLists.Find(id);
            if (shiftList == null)
            {
                return HttpNotFound();
            }
            return View(shiftList);
        }

        // POST: ShiftLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShiftList shiftList = db.ShiftLists.Find(id);
            db.ShiftLists.Remove(shiftList);
            
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
        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public JsonResult DeleteShift(int Id)
        //{
        //    var status = false;
        //    using (ApplicationDbContext dc = new ApplicationDbContext())
        //    {
        //        var v = dc.ShiftLists.Where(a => a.Id == Id).FirstOrDefault();
        //        if (v != null)
        //        {
        //            dc.ShiftLists.Remove(v);
        //            dc.SaveChanges();
        //            status = true;
        //        }
        //    }
        //    return new JsonResult { Data = new { status = status } };
        //}
        public ActionResult DeleteAll()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<ShiftList> query = context.ShiftLists.ToList();
            foreach (ShiftList q in query)
            {
                context.ShiftLists.Remove(q);
            }
            context.SaveChanges();
            return Json(new { Result = "Success", Message = "Saved Successfully" });
        }
    }
}
